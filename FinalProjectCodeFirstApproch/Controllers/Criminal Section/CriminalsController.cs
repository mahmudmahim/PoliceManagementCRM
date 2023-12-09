using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section;
using Microsoft.SqlServer.Server;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalsController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CriminalsController(PoliceStationManagementDbContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this._hostEnvironment = hostEnvironment;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CriminalInfo>>> GetCriminals()
        //{
        //    if (db.Criminals == null)
        //    {
        //        return NotFound();
        //    }
        //    return await db.Criminals.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CriminalInfo>>> GetCriminals()
        {
            if (db.Criminals == null)
            {
                return NotFound();
            }
            var criminal = await db.Criminals.Include(x => x.SuspectInfo)
                .Select(x => new GetCriminalDTO
                {
                    CriminalInfoId=x.CriminalInfoId,
                    Name=x.Name,
                    Age=x.Age,
                    Gender=x.Gender,
                    Picture=x.Picture,
                    Description=x.Description,
                    Status=x.Status,
                    CaseId=x.CaseId,
                    SuspectName=x.SuspectInfo.Name
                }).ToListAsync();
            return Ok(criminal);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<CriminalInfo>> GetCriminalInfo(int id)
        //{
        //    if (db.Criminals == null)
        //    {
        //        return NotFound();
        //    }
        //    var criminalInfo = await db.Criminals.FindAsync(id);

        //    if (criminalInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return criminalInfo;
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<CriminalInfo>> GetCriminalInfo(int id)
        {
            if (db.Criminals == null)
            {
                return NotFound();
            }
            var ci = await db.Criminals.Include(x=>x.SuspectInfo).FirstAsync(x=>x.CriminalInfoId==id);

            if (ci == null)
            {
                return NotFound();
            }
            var criminalInfo = new GetCriminalDTO()
            {
                CriminalInfoId=ci.CriminalInfoId,
                Name=ci.Name,
                Age=ci.Age,
                Gender =ci.Gender,
                Picture =ci.Picture,
                Description =ci.Description,
                Status=ci.Status,
                CaseId =ci.CaseId,
                SuspectName=ci.SuspectInfo.Name
            };
            return Ok(criminalInfo);
        }


        [HttpPost]
        public async Task<ActionResult<CriminalInfo>> PostCriminalInfo([FromForm] CriminalInfoDTO model)
        {
            CriminalInfo criminalInfo = new CriminalInfo()
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                Description = model.Description,
                Status = model.Status,
                CaseId = model.CaseId,
                SuspectId= model.SuspectId
            };
            if(model.PicturePath != null)
            {
                var criminalPicturePath = await SaveFileAsync(model.PicturePath);
                criminalInfo.Picture = criminalPicturePath;
            }
            db.Criminals.Add(criminalInfo);
            await db.SaveChangesAsync();
            return Ok(criminalInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriminalInfo(int id,[FromForm] CriminalInfoDTO model)
        {
            var criminalInfo = await db.Criminals.FindAsync(id);
            if (criminalInfo == null)
            {
                return BadRequest();
            }
            criminalInfo.Name = model.Name;
            criminalInfo.Age = model.Age;
            criminalInfo.Gender = model.Gender;
            criminalInfo.Description = model.Description;
            criminalInfo.Status = model.Status;
            criminalInfo.CaseId = model.CaseId;
            criminalInfo.SuspectId = model.SuspectId;
            if (model.PicturePath != null)
            {
                var criminalPicturePath = await SaveFileAsync(model.PicturePath);
                criminalInfo.Picture = criminalPicturePath;
            }
            db.Entry(criminalInfo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(criminalInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriminalInfo(int id)
        {
            if (db.Criminals == null)
            {
                return NotFound();
            }
            var criminalInfo = await db.Criminals.FindAsync(id);
            if (criminalInfo == null)
            {
                return NotFound();
            }
            db.Criminals.Remove(criminalInfo);
            await db.SaveChangesAsync();
            return Ok("Succesfully Removed Criminal information");
        }



        private async Task<string> SaveFileAsync(IFormFile file)
        {
            if (!IsValidFile(file))
            {
                throw new ArgumentException("Invalid file type or size.");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            if (!Directory.Exists(_hostEnvironment.WebRootPath + "\\Uploads\\"))
            {
                Directory.CreateDirectory(_hostEnvironment.WebRootPath + "\\Uploads\\");
            }

            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        private bool IsValidFile(IFormFile file)
        {

            var allowedFileTypes = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedFileTypes.Contains(fileExtension))
            {
                return false;
            }

            // Validate file size
            var maxFileSizeInBytes = 5 * 1024 * 1024; // 5 MB
            if (file.Length > maxFileSizeInBytes)
            {
                return false;
            }

            return true;
        }


    }
}
