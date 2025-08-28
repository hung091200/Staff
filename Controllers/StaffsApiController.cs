using Job.Context;
using Job.Models;
using Job.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsApiController : ControllerBase
    {
        public readonly ApplicationDbContext dbContext;
        public StaffsApiController(ApplicationDbContext dbContext)
        {
            var staffs = dbContext.Staffs.Select(s => new
            {
                s.Id,
                s.FullName,
                s.Age,
                s.Gender,
                s.PhoneNumber,
                s.EmailAdress,
                s.Address,
                s.Department,
                s.Position
            }
            ).ToList();
        }
        [HttpGet]
        public IActionResult GetStaffs()
        {
            var staffs = dbContext.Staffs.ToList();
            return Ok(staffs);
        }
        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            var staff = dbContext.Staffs.Find(id);
            return Ok(staff);
        }

        [HttpPost]
        public IActionResult CreateStaff(AddStaffDto addStaffDto)
        {
            var staff = new Staff()
            {
                FullName = addStaffDto.FullName,
                Age = addStaffDto.Age,
                Gender = addStaffDto.Gender,
                PhoneNumber = addStaffDto.PhoneNumber,
                EmailAdress = addStaffDto.EmailAdress,
                Address = addStaffDto.Address,
                Department = addStaffDto.Department,
                Position = addStaffDto.Position,
            };
            dbContext.Staffs.Add(staff);
            dbContext.SaveChanges();
            return Ok(staff);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id) {
            var staff = dbContext.Staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            dbContext.Staffs.Remove(staff);
            dbContext.SaveChanges();
            return Ok(staff);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, UpdateStaffDto updateStaffDto)
        {
            var staff = dbContext.Staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }

            staff.FullName = updateStaffDto.FullName;
            staff.Age = updateStaffDto.Age;
            staff.Gender = updateStaffDto.Gender;
            staff.PhoneNumber = updateStaffDto.PhoneNumber;
            staff.EmailAdress = updateStaffDto.EmailAdress;
            staff.Address = updateStaffDto.Address;
            staff.Department = updateStaffDto.Department;
            staff.Position = updateStaffDto.Position;
            
            
            dbContext.SaveChanges();
            return Ok(staff);
        }
    }
}
