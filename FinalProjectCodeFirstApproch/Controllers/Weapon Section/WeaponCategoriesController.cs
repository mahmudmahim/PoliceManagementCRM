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
    public class WeaponCategoriesController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public WeaponCategoriesController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponCategory>>> GetWeaponCategories()
        {
          if (db.WeaponCategories == null)
          {
              return NotFound();
          }
            return await db.WeaponCategories.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponCategory>> GetWeaponCategory(int id)
        {
          if (db.WeaponCategories == null)
          {
              return NotFound();
          }
            var weaponCategory = await db.WeaponCategories.FindAsync(id);

            if (weaponCategory == null)
            {
                return NotFound();
            }

            return weaponCategory;
        }

        [HttpPost]
        public async Task<ActionResult<WeaponCategory>> PostWeaponCategory([FromForm]WeaponCategoryDTO model)
        {
            WeaponCategory weaponCategory = new WeaponCategory()
            {
                CategoryName= model.CategoryName,
                Description= model.Description,
            };
            db.WeaponCategories.Add(weaponCategory);
            await db.SaveChangesAsync();

            return Ok(weaponCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponCategory(int id,[FromForm]WeaponCategoryDTO model)
        {
            var weaponCategory = await db.WeaponCategories.FindAsync(id);
            if (weaponCategory == null)
            {
                return NotFound();
            }
            weaponCategory.CategoryName = model.CategoryName;
            weaponCategory.Description = model.Description;
            db.WeaponCategories.Update(weaponCategory);
            await db.SaveChangesAsync();
            return Ok(weaponCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponCategory(int id)
        {
            if (db.WeaponCategories == null)
            {
                return NotFound();
            }
            var weaponCategory = await db.WeaponCategories.FindAsync(id);
            if (weaponCategory == null)
            {
                return NotFound();
            }

            db.WeaponCategories.Remove(weaponCategory);
            await db.SaveChangesAsync();

            return Ok("Succesfull Removed Category : " + weaponCategory.CategoryName);
        }

        private bool WeaponCategoryExists(int id)
        {
            return (db.WeaponCategories?.Any(e => e.WeaponCategoryId == id)).GetValueOrDefault();
        }
    }
}
