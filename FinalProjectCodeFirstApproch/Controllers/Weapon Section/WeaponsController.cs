using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.Weapon_Management;

using FinalProjectCodeFirstApproch.Models.DTO.Weapon_Section;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public WeaponsController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WeaponInfo>>> GetWeapons()
        //{
        //  if (db.Weapons == null)
        //  {
        //      return NotFound();
        //  }
        //    return await db.Weapons.ToListAsync();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponInfo>>> GetWeapons()
        {
          if (db.Weapons == null)
          {
              return NotFound();
          }
          var weapons =await db.Weapons.Include(x=>x.Category).Include(x=>x.Owner)
                .Select(x=> new GetWeaponsDTO
                {
                    WeaponInfoId = x.WeaponInfoId,
                    Description= x.Description,
                    AcquisitionDate= x.AcquisitionDate,
                    Status= x.Status,
                    CategoryName=x.Category.CategoryName,
                    OwnerName=x.Owner.FirstName
                }).ToListAsync();
            return Ok(weapons);            
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<WeaponInfo>> GetWeaponInfo(int id)
        //{
        //  if (db.Weapons == null)
        //  {
        //      return NotFound();
        //  }
        //    var weaponInfo = await db.Weapons.FindAsync(id);

        //    if (weaponInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return weaponInfo;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponInfo>> GetWeaponInfo(int id)
        {
            if (db.Weapons == null)
            {
                return NotFound();
            }
            var weaponInfo = await db.Weapons.Include(x=>x.Category).Include(x=>x.Owner).FirstAsync(x=>x.WeaponInfoId==id);

            if (weaponInfo == null)
            {
                return NotFound();
            }
            var wepons = new GetWeaponsDTO()
            {
                WeaponInfoId= weaponInfo.WeaponInfoId,
                Description= weaponInfo.Description,
                AcquisitionDate = weaponInfo.AcquisitionDate,
                Status= weaponInfo.Status,
                CategoryName=weaponInfo.Category.CategoryName,
                OwnerName=weaponInfo.Owner.FirstName
            };
            return Ok(wepons);
        }

        [HttpPost]
        public async Task<ActionResult<WeaponInfo>> PostWeaponInfo([FromForm]WeaponInfoDTO model)
        {
            WeaponInfo weaponInfo = new WeaponInfo()
            {
                Description= model.Description,
                AcquisitionDate=model.AcquisitionDate,
                Status=model.Status,
                CategoryId=model.CategoryId,
                OwnerId=model.OwnerId
            };
            db.Weapons.Add(weaponInfo);
            await db.SaveChangesAsync();

            return Ok(weaponInfo);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponInfo(int id, [FromForm]WeaponInfoDTO model)
        {
            var weaponInfo = await db.Weapons.FindAsync(id);
            if (weaponInfo == null)
            {
                return NotFound();
            }
            weaponInfo.Description = model.Description;
            weaponInfo.AcquisitionDate = model.AcquisitionDate;
            weaponInfo.Status = model.Status;
            weaponInfo.CategoryId = model.CategoryId;
            weaponInfo.OwnerId = model.OwnerId;
            db.Weapons.Update(weaponInfo);
            await db.SaveChangesAsync();
            return Ok(weaponInfo);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponInfo(int id)
        {
            if (db.Weapons == null)
            {
                return NotFound();
            }
            var weaponInfo = await db.Weapons.FindAsync(id);
            if (weaponInfo == null)
            {
                return NotFound();
            }

            db.Weapons.Remove(weaponInfo);
            await db.SaveChangesAsync();

            return Ok("Succesfull Removed Weapon with id : " + weaponInfo.WeaponInfoId);
        }

    }
}
