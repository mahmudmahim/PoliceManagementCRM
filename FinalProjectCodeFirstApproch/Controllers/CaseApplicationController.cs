using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using FinalProjectCodeFirstApproch.Models.Victim_Management;
using FinalProjectCodeFirstApproch.Models.ViewModels;
using System.Net;
using NuGet.Versioning;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseApplicationController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CaseApplicationController(PoliceStationManagementDbContext dbContext, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("getCrimeTypes")]
        public async Task<IActionResult> GetCrimeTypes()
        {
            try
            {
                var crimeTypes = await _dbContext.CrimeTypes.ToListAsync();
                return Ok(crimeTypes);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCases()
        {
            try
            {
                // Get all cases from the database 
                var cases = await _dbContext.VictimsCaseApplies
                    .Include(v => v.CrimeType)
                    .Include(v => v.SuspectInfos)
                    .Include(v => v.WitnessInfos)
                    .Select(v => new CaseApplicationViewModel
                    {
                        // Mapping victim database entities to view model
                        VictimName = v.Name,
                        VictimAge = v.Age,
                        VictimGender = v.Gender,
                        Address = v.Address,
                        Profession = v.Profession,
                        PhoneNo = v.PhoneNo,
                        Nationality = v.Nationality,
                        MaritalStatus = v.MaritalStatus,
                        Nid = (long)v.Nid,
                        CrimeSpot = v.CrimeSpot,
                        CrimeDescription = v.CrimeDescription,
                        CrimeTypeName = v.CrimeType.CrimeName,

                        // Mapping suspect database entities to view model
                        SuspectName = v.SuspectInfos.FirstOrDefault().Name,
                        SuspectAge = v.SuspectInfos.FirstOrDefault().Age,
                        SuspectAddress = v.SuspectInfos.FirstOrDefault().Address,
                        SuspectGender = v.SuspectInfos.FirstOrDefault().Gender,
                        SuspectPhoneNo = v.SuspectInfos.FirstOrDefault().PhoneNo,
                        SuspectDescription = v.SuspectInfos.FirstOrDefault().Description,

                        // Mapping witness database entities to view model
                        WitnessName = v.WitnessInfos.FirstOrDefault().Name,
                        WitnessAge = v.WitnessInfos.FirstOrDefault().Age,
                        WitnessGender = v.WitnessInfos.FirstOrDefault().Gender,
                        WitnessAddress = v.WitnessInfos.FirstOrDefault().Address,
                        WitnessPhoneNo = v.WitnessInfos.FirstOrDefault().PhoneNo,
                        WitnessProfession = v.WitnessInfos.FirstOrDefault().Profession,
                        WitnessNationality = v.WitnessInfos.FirstOrDefault().Nationality,


                    }).ToListAsync();

                return Ok(cases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaseById(int id)
        {
            try
            {
                // Implement logic to get a case by ID from the database
                var victimCase = await _dbContext.VictimsCaseApplies
                    .Include(v => v.CrimeType)
                    .Include(v => v.SuspectInfos)
                    .Include(v => v.WitnessInfos)
                    .FirstOrDefaultAsync(v => v.VictimCaseApplyId == id);

                if (victimCase == null)
                {
                    return NotFound();
                }

                var caseViewModel = new CaseApplicationViewModel
                {
                    // Mapping VictimCaseApply properties
                    VictimName = victimCase.Name,
                    VictimAge = victimCase.Age,
                    VictimGender = victimCase.Gender,
                    Address = victimCase.Address,
                    Profession = victimCase.Profession,
                    PhoneNo = victimCase.PhoneNo,
                    Nationality = victimCase.Nationality,
                    MaritalStatus = victimCase.MaritalStatus,
                    Nid = (long)victimCase.Nid,
                    CrimeSpot = victimCase.CrimeSpot,
                    CrimeDescription = victimCase.CrimeDescription,
                    CrimeTypeName = victimCase.CrimeType.CrimeName,

                    // Mapping SuspectInfo properties
                    SuspectName = victimCase.SuspectInfos.FirstOrDefault()?.Name,
                    SuspectAge = victimCase.SuspectInfos.FirstOrDefault()?.Age,
                    SuspectAddress = victimCase.SuspectInfos.FirstOrDefault()?.Address,
                    SuspectGender = victimCase.SuspectInfos.FirstOrDefault()?.Gender,
                    SuspectPhoneNo = victimCase.SuspectInfos.FirstOrDefault()?.PhoneNo,
                    SuspectDescription = victimCase.SuspectInfos.FirstOrDefault()?.Description,


                    // Mapping WitnessInfo properties
                    WitnessName = victimCase.WitnessInfos.FirstOrDefault()?.Name,
                    WitnessAge = victimCase.WitnessInfos.FirstOrDefault()?.Age,
                    WitnessGender = victimCase.WitnessInfos.FirstOrDefault()?.Gender,
                    WitnessAddress = victimCase.WitnessInfos.FirstOrDefault()?.Address,
                    WitnessPhoneNo = victimCase.WitnessInfos.FirstOrDefault()?.PhoneNo,
                    WitnessProfession = victimCase.WitnessInfos.FirstOrDefault()?.Profession,
                    WitnessNationality = victimCase.WitnessInfos.FirstOrDefault()?.Nationality
                };

                return Ok(caseViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCase([FromForm] CaseApplicationViewModel formData)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var victimPicturePath = await SaveFileAsync(formData.VictimPictureFile);
                    var suspectPicturePath = await SaveFileAsync(formData.SuspectPictureFile);
                    var witnessPicturePath = await SaveFileAsync(formData.WitnessPictureFile);

                    CrimeType crimeType = new CrimeType()
                    {
                        CrimeName = formData.CrimeTypeName
                    };

                    _dbContext.CrimeTypes.Add(crimeType);
                    await _dbContext.SaveChangesAsync();


                    var victimCase = new VictimCaseApply
                    {
                        Name = formData.VictimName,
                        Age = formData.VictimAge,
                        Gender = formData.VictimGender,
                        Address = formData.Address,
                        Profession = formData.Profession,
                        PhoneNo = formData.PhoneNo,
                        Nationality = formData.Nationality,
                        MaritalStatus = formData.MaritalStatus,
                        Nid = formData.Nid,
                        CrimeSpot = formData.CrimeSpot,
                        CrimeDescription = formData.CrimeDescription,
                        Picture = victimPicturePath,
                        CrimeTypeId = crimeType.CrimeTypeId
                    };
                    _dbContext.VictimsCaseApplies.Add(victimCase);
                    await _dbContext.SaveChangesAsync();



                    var suspectInfo = new SuspectInfo
                    {
                        Name = formData.SuspectName,
                        Age = formData.SuspectAge,
                        Gender = formData.SuspectGender,
                        Address = formData.Address,
                        PhoneNo = formData.PhoneNo,
                        Description = formData.SuspectDescription,
                        Picture = suspectPicturePath,
                        VictimCaseApplyId = victimCase.VictimCaseApplyId
                    };

                    var witnessInfo = new WitnessInfo
                    {
                        Name = formData.WitnessName,
                        Age = formData.WitnessAge,
                        Gender = formData.WitnessGender,
                        Address = formData.WitnessAddress,
                        PhoneNo = formData.WitnessPhoneNo,
                        Profession = formData.WitnessProfession,
                        Nationality = formData.WitnessNationality,
                        Picture = witnessPicturePath,
                        VictimCaseApplyId = victimCase.VictimCaseApplyId
                    };

                    _dbContext.SuspectInfos.Add(suspectInfo);
                    _dbContext.WitnessInfos.Add(witnessInfo);

                    await _dbContext.SaveChangesAsync(); 

                    transaction.Commit();
                    return Ok("Case created successfully");
                }
                catch (Exception ex)
                {
                    //Rollback the transaction if any exceptions occures
                    transaction.Rollback();
                    return StatusCode(500, "Internal server error");
                }
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCase(int id, [FromForm] CaseApplicationViewModel formData)
        //{
        //    using (var transaction = _dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var existingVictimCase = await _dbContext.VictimsCaseApplies
        //                .Include(vc => vc.SuspectInfos)
        //                .Include(vc => vc.WitnessInfos)
        //                .FirstOrDefaultAsync(vc => vc.VictimCaseApplyId == id);

        //            if (existingVictimCase == null)
        //            {
        //                return NotFound("Case not found");
        //            }
        //            if (formData.CrimeTypeName != null)
        //            {
        //                var crimeType = _dbContext.CrimeTypes.FirstOrDefault(ct => ct.CrimeName == formData.CrimeTypeName)
        //                    ?? new CrimeType { CrimeName = formData.CrimeTypeName };

        //                existingVictimCase.CrimeType = crimeType;
        //            }

        //            _dbContext.Entry(existingVictimCase.CrimeType).State = EntityState.Modified;

        //            var victimPicturePath = await SaveFileAsync(formData.VictimPictureFile);
        //            var suspectPicturePath = await SaveFileAsync(formData.SuspectPictureFile);
        //            var witnessPicturePath = await SaveFileAsync(formData.WitnessPictureFile);

        //            existingVictimCase.Name = formData.VictimName;
        //            existingVictimCase.Age = formData.VictimAge;
        //            existingVictimCase.Gender = formData.VictimGender;
        //            existingVictimCase.Address = formData.Address;
        //            existingVictimCase.Nid =    formData.Nid;
        //            existingVictimCase.Profession = formData.Profession;
        //            existingVictimCase.PhoneNo = formData.PhoneNo;
        //            existingVictimCase.CrimeSpot = formData.CrimeSpot;
        //            existingVictimCase.CrimeDescription = formData.CrimeDescription;
        //            //existingVictimCase.CrimeType.CrimeName = formData.CrimeTypeName;

        //            // Update other victim case properties as needed

        //             // Update crime type name

        //            var suspectInfo = existingVictimCase.SuspectInfos.FirstOrDefault(s=>s.SuspectInfoId == id);

        //            suspectInfo.Name = formData.SuspectName;
        //            suspectInfo.Age = formData.SuspectAge;
        //            suspectInfo.Gender = formData.SuspectGender;
        //            suspectInfo.Address = formData.SuspectAddress;
        //            suspectInfo.PhoneNo = formData.SuspectPhoneNo;
        //            suspectInfo.Description = formData.SuspectDescription;
        //            // Update other suspect info properties as needed

        //            var witnessInfo = existingVictimCase.WitnessInfos.FirstOrDefault(w => w.WitnessInfoId == id);


        //            witnessInfo.Name = formData.WitnessName;
        //            witnessInfo.Age = formData.WitnessAge;
        //            witnessInfo.Gender = formData.WitnessGender;
        //            witnessInfo.Address = formData.WitnessAddress;
        //            witnessInfo.Profession = formData.WitnessProfession;
        //            witnessInfo.Nationality = formData.WitnessNationality;
        //            // Update other witness info properties as needed

        //            if (!string.IsNullOrEmpty(victimPicturePath))
        //            {
        //                existingVictimCase.Picture = victimPicturePath;
        //            }

        //            if (!string.IsNullOrEmpty(suspectPicturePath))
        //            {
        //                suspectInfo.Picture = suspectPicturePath;
        //            }

        //            if (!string.IsNullOrEmpty(witnessPicturePath))
        //            {
        //                witnessInfo.Picture = witnessPicturePath;
        //            }

        //            // Use EntityState.Modified or Update() method to mark entities as modified
        //            _dbContext.Entry(existingVictimCase).State = EntityState.Modified;
        //            _dbContext.Entry(existingVictimCase.SuspectInfos).State = EntityState.Modified;
        //            _dbContext.Entry(existingVictimCase.WitnessInfos).State = EntityState.Modified;

        //            await _dbContext.SaveChangesAsync();

        //            transaction.Commit();
        //            return Ok("Case updated successfully");
        //        }
        //        catch (Exception ex)
        //        {
        //            //Rollback the transaction if any exceptions occur
        //            transaction.Rollback();
        //            return StatusCode(500, "Internal server error");
        //        }
        //    }
        //}


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateCases(int id, [FromForm] CaseApplicationViewModel formData)
        {
            try
            {
                //var existingCase = await _dbContext.VictimsCaseApplies.FindAsync(id);

                var existingVictimCase = await _dbContext.VictimsCaseApplies
                        .Include(vc => vc.SuspectInfos)
                        .Include(vc => vc.WitnessInfos)
                        .FirstOrDefaultAsync(vc => vc.VictimCaseApplyId == id);

                if (existingVictimCase == null)
                {
                    return NotFound("Case not found");
                }

                formData.VictimName = existingVictimCase.Name;
                formData.VictimAge = existingVictimCase.Age;
                formData.VictimGender = existingVictimCase.Gender;
                formData.Address = existingVictimCase.Address;
                formData.Profession = existingVictimCase.Profession;
                formData.PhoneNo = existingVictimCase.PhoneNo;
                formData.Nationality = existingVictimCase.Nationality;
                formData.MaritalStatus = existingVictimCase.MaritalStatus;
                formData.Nid = existingVictimCase.Nid;
                formData.CrimeSpot = existingVictimCase.CrimeSpot;
                formData.CrimeDescription = existingVictimCase.CrimeDescription;



                if (formData.CrimeTypeName != null)
                {
                    var crimeType = _dbContext.CrimeTypes.FirstOrDefault(ct => ct.CrimeName == formData.CrimeTypeName)
                        ?? new CrimeType { CrimeName = formData.CrimeTypeName };

                    existingVictimCase.CrimeType = crimeType;
                }
                _dbContext.Entry(existingVictimCase).State = EntityState.Modified;
                //_dbContext.VictimsCaseApplies.Update(existingCase);

                // Update SuspectInfo
                var existingSuspect = await _dbContext.SuspectInfos.FindAsync(id);

                if (id != existingSuspect.SuspectInfoId)
                {
                    return BadRequest();
                }

                if (existingSuspect != null)
                {
                    formData.SuspectName = existingSuspect.Name;
                    formData.SuspectAge = existingSuspect.Age;
                    formData.SuspectGender = existingSuspect.Gender;
                    formData.Address = existingSuspect.Address;
                    formData.PhoneNo = existingSuspect.PhoneNo;
                    formData.SuspectDescription = existingSuspect.Description;

                    //    Update SuspectInfo picture if a new file is provided
                    if (formData.SuspectPictureFile != null)
                    {
                        existingSuspect.Picture = await SaveFileAsync(formData.SuspectPictureFile);
                    }
                }
                _dbContext.Entry(existingSuspect).State = EntityState.Modified;
                //_dbContext.SuspectInfos.Update(existingSuspect);

                // Update WitnessInfo
                var existingWitness = await _dbContext.WitnessInfos.FindAsync(id);

                if (id != existingWitness.WitnessInfoId)
                {
                    return BadRequest();
                }

                if (existingWitness != null)
                {
                    formData.WitnessName = existingWitness.Name;
                    formData.WitnessAge = existingWitness.Age;
                    formData.WitnessGender = existingWitness.Gender;
                    formData.WitnessAddress = existingWitness.Address;
                    formData.WitnessPhoneNo = existingWitness.PhoneNo;
                    formData.WitnessProfession = existingWitness.Profession;
                    formData.WitnessNationality = existingWitness.Nationality;

                    //Update WitnessInfo picture if a new file is provided
                    if (formData.WitnessPictureFile != null)
                    {
                        existingWitness.Picture = await SaveFileAsync(formData.WitnessPictureFile);
                    }
                }

                _dbContext.Entry(existingWitness).State = EntityState.Modified;
                //_dbContext.WitnessInfos.Update(existingWitness);
                await _dbContext.SaveChangesAsync();

                return Ok("Case updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            try
            {
                var victimCaseDelete = await _dbContext.VictimsCaseApplies.FindAsync(id);
                if (victimCaseDelete == null)
                {
                    return NotFound("Victim Case Not Found");
                }
                _dbContext.VictimsCaseApplies.Remove(victimCaseDelete);
                await _dbContext.SaveChangesAsync();

                return Ok("Case deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
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
            // Validate file extension
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
