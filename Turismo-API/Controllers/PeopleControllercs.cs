using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Turismo_API.Data;
using Turismo_API.Models;
using Turismo_API.Models.Custom;
using Turismo_API.Services.Interfaces;

namespace Turismo_API.Controllers
{
    [Route("Turismo/[controller]")]
    [ApiController]
    public class PeopleControllercs : Controller
    {
        private readonly BdTurismoTiquipayaContext _context;
        private readonly ILoginService _loginService;
        private readonly IPersonRegisterService _personRegisterService;

        public PeopleControllercs(ILoginService loginService , IPersonRegisterService personRegisterService,BdTurismoTiquipayaContext context)
        {
            _loginService = loginService;
            _personRegisterService = personRegisterService;
            _context = context;
        }

        [HttpPost]
        [Route("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody]PersonDTO person)
        {
            User user = new User();
            if (person != null)
            {
                try
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            await _context.People.AddAsync((Person)person);
                            await _context.SaveChangesAsync();

                            user.PersonId = person.PersonId;
                            user.Email = person.Email;
                            user.UserName = _loginService.GenerateUserName(person.Name, person.LastName, person.Email, person.Ci);
                            user.Password = _loginService.EncryptPassword(person.Password);
                            user.Rol = "A";

                            await _context.Users.AddAsync(user);
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();

                            await _personRegisterService.RegisterPersonRegister(person.PersonId, person.UserID);
                            await _personRegisterService.SendEmail(user.UserName, person.Email);

                            return Ok();
                        }
                        catch(Exception ex)
                        {
                            await transaction.RollbackAsync();
                        }
                    }
                }
                catch(Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(PersonDTO person)
        {
            User user = new User();
            if (person != null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        await _context.People.AddAsync((Person)person);
                        await _context.SaveChangesAsync();

                        user.PersonId = person.PersonId;
                        user.Email = person.Email;
                        user.UserName = _loginService.GenerateUserName(person.Name, person.LastName, person.Email, person.Ci);
                        user.Password = _loginService.EncryptPassword(person.Password);
                        user.Rol = "C";

                        await _context.Users.AddAsync(user);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        await _personRegisterService.RegisterPersonRegister(person.PersonId, person.UserID);
                        await _personRegisterService.SendEmail(user.UserName, person.Email);

                        return Ok();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                    }
                }
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAdmins")]
        public async Task<IActionResult> GetAdmins()
        {
            //return Ok(_context.People.Where(x => x.User.Rol == "A"));
            return Ok(_context.People);
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var data = _context.People.Select(x => new UserDTO { 
                PersonId = x.PersonId,
                Name = x.Name, 
                FirstName=x.FirstName, 
                LastName=x.LastName,
                Address=x.Address, 
                BirthDate = x.BirthDate,
                Ci = x.Ci,
                Email = x.User.Email,
                Gender = x.Gender,
                Rol = x.User.Rol,
                Password="",
                Phone = x.Phone,
                State = x.State==1?"Activo" : "Inactivo",
                UserName = x.User.UserName
            }).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(int personId)
        {
            var data = _context.People.Where(x => x.PersonId == personId).Select(x => new UserDTO
            {
                PersonId = x.PersonId,
                Name = x.Name,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                BirthDate = x.BirthDate,
                Ci = x.Ci,
                Email = x.User.Email,
                Gender = x.Gender,
                Rol = x.User.Rol,
                Password = "",
                Phone = x.Phone,
                State = x.State == 1 ? "Activo" : "Inactivo",
                UserName = x.User.UserName
            }).FirstOrDefault();
            return Ok(data);
        }

        [HttpPut]
        [Route("EditPeople")]
        public async Task<IActionResult> EditPeople(PersonDTO person)
        {
            if(!PersonExists(person.PersonId))
                return NotFound();

            try
            {
                _context.Entry(person).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("DeletePeople")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            if (!PersonExists(id))
                return NotFound();

            var person = await _context.People.FindAsync(id);
            if(person == null)
                return NotFound();
            try
            {
                person.State = 0;
                _context.Entry(person).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }

    }
}
