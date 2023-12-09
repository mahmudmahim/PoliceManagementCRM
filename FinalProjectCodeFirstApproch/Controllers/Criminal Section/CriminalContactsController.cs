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

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalContactsController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public CriminalContactsController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CriminalContact>>> GetCriminalContacts()
        //{
        //  if (db.CriminalContacts == null)
        //  {
        //      return NotFound();
        //  }
        //    return await db.CriminalContacts.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CriminalContact>>> GetCriminalContacts()
        {
            if (db.CriminalContacts == null)
            {
                return NotFound();
            }
            var criminalContacts = await db.CriminalContacts.Include(x=>x.CriminalInfo)
                .Select(x=>new GetCriminalContactDTO
                {
                    CriminalContactId=x.CriminalContactId,
                    ContactType=x.ContactType,
                    ContactInfo=x.ContactInfo,
                    Description=x.Description,
                    CriminalName=x.CriminalInfo.Name
                }).ToListAsync();
            return Ok(criminalContacts);
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<CriminalContact>> GetCriminalContact(int id)
        //{
        //  if (db.CriminalContacts == null)
        //  {
        //      return NotFound();
        //  }
        //    var criminalContact = await db.CriminalContacts.FindAsync(id);

        //    if (criminalContact == null)
        //    {
        //        return NotFound();
        //    }

        //    return criminalContact;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<CriminalContact>> GetCriminalContact(int id)
        {
            if (db.CriminalContacts == null)
            {
                return NotFound();
            }
            var cc = await db.CriminalContacts.Include(x=>x.CriminalInfo).FirstAsync(x=>x.CriminalContactId==id);

            if (cc == null)
            {
                return NotFound();
            }
            var criminalContact = new GetCriminalContactDTO()
            {
                CriminalContactId=cc.CriminalContactId,
                ContactType=cc.ContactType,
                ContactInfo=cc.ContactInfo,
                Description=cc.Description,
                CriminalName=cc.CriminalInfo.Name
            };
            return Ok(criminalContact);
        }

        [HttpPost]
        public async Task<ActionResult<CriminalContact>> PostCriminalContact([FromForm]CriminalContactDTO model)
        {
            CriminalContact criminalContact = new CriminalContact()
            {
                ContactType = model.ContactType,
                ContactInfo = model.ContactInfo,
                Description = model.Description,
                CriminalId = model.CriminalId
            };
            db.CriminalContacts.Add(criminalContact);
            await db.SaveChangesAsync();

            return Ok(criminalContact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriminalContact(int id, [FromForm]CriminalContactDTO model)
        {
            var criminalContact = await db.CriminalContacts.FindAsync(id);
            if (criminalContact == null)
            {
                return BadRequest();
            }
            criminalContact.ContactType = model.ContactType;
            criminalContact.ContactInfo = model.ContactInfo;
            criminalContact.Description = model.Description;
            criminalContact.CriminalId = model.CriminalId;

            db.Entry(criminalContact).State = EntityState.Modified;

            await db.SaveChangesAsync();
            return Ok(criminalContact);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriminalContact(int id)
        {

            var criminalContact = await db.CriminalContacts.FindAsync(id);
            if (criminalContact == null)
            {
                return NotFound();
            }

            db.CriminalContacts.Remove(criminalContact);
            await db.SaveChangesAsync();

            return Ok("Succesfully Deleted");
        }

    }
}
