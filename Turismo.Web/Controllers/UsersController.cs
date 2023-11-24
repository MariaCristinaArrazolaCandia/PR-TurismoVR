using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Turismo.Web.Data;
using Turismo.Web.db;
using Turismo.Web.Models;
using Turismo.Web.Models.DTO;


namespace Turismo.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly bdTurismoTiquipayaContext _context;

        public UsersController(bdTurismoTiquipayaContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7298/Turismo/PeopleControllercs/GetUsers");
                if (response.IsSuccessStatusCode)
                {
                    users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
                }
            }
            catch(Exception ex)
            {
                users = new List<UserDTO>();
            }
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Person)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            //ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "Gender");
            //ViewBag.RolId = new SelectList(_context.Rols.ToList(), "RolId", "Name");
            List<ComboDTO> roles = new List<ComboDTO>
            {
                new ComboDTO{ Id="A", Name="Administrador"},
                new ComboDTO{ Id="C", Name="Cliente"}
            };
            ViewBag.Rol = new SelectList(roles, "Id", "Name"); // Crea un SelectList para los roles
            List<ComboDTO> gender = new List<ComboDTO>
            {
                new ComboDTO{ Id="F", Name="Feminino"},
                new ComboDTO{ Id="M", Name="Masculino"}
            };
            ViewBag.Gender = new SelectList(gender, "Id", "Name"); // Crea un SelectList para los roles
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Turismo.Web.Models.UserDTO user)
        {
            if (ModelState.IsValid)
            {

                // HttpClient client = new HttpClient();
                // HttpResponseMessage response = await client.PostAsJsonAsync(
                //"api/products", product);
                // response.EnsureSuccessStatusCode();

                //_context.Add(user);
                //await _context.SaveChangesAsync();
                PersonDTO personDTO = new PersonDTO()
                {
                    UserID = 0,
                    Name = user.Name,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    Ci = user.Ci,
                    Email = user.Email,
                    Gender = user.Gender,
                    Password = user.Password,
                    Phone = user.Phone,
                    State = 1
                };

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync(
				"https://localhost:7298/Turismo/PeopleControllercs/CreateAdmin", personDTO);
                var estaado = response.EnsureSuccessStatusCode();
                if (estaado.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            //ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "Gender", user.PersonId);
            //ViewData["RolId"] = new SelectList(_context.Rols, "RolId", "Name", user.RolId);
            List<ComboDTO> roles = new List<ComboDTO>
            {
                new ComboDTO{ Id="A", Name="Administrador"},
                new ComboDTO{ Id="C", Name="Cliente"}
            };
            ViewBag.Rol = new SelectList(roles, "Id", "Name", user.Rol); // Crea un SelectList para los roles
            List<ComboDTO> gender = new List<ComboDTO>
            {
                new ComboDTO{ Id="F", Name="Feminino"},
                new ComboDTO{ Id="M", Name="Masculino"}
            };
            ViewBag.Gender = new SelectList(gender, "Id", "Name", user.Gender); // Crea un SelectList para los roles
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.Users == null)
            //{
            //    return NotFound();
            //}

            //var user = await _context.Users.FindAsync(id);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            UserDTO userDto = new UserDTO();
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7298/Turismo/PeopleControllercs/GetUser?personId=" + id);
                if (response.IsSuccessStatusCode)
                {
                    userDto = await response.Content.ReadFromJsonAsync<UserDTO>();
                }
            }
            catch (Exception ex)
            {
                userDto = new UserDTO();
            }

            List<ComboDTO> roles = new List<ComboDTO>
            {
                new ComboDTO{ Id="A", Name="Administrador"},
                new ComboDTO{ Id="C", Name="Cliente"}
            };
            ViewBag.Rol = new SelectList(roles, "Id", "Name", userDto?.Rol); // Crea un SelectList para los roles
            List<ComboDTO> gender = new List<ComboDTO>
            {
                new ComboDTO{ Id="F", Name="Feminino"},
                new ComboDTO{ Id="M", Name="Masculino"}
            };
            ViewBag.Gender = new SelectList(gender, "Id", "Name", userDto?.Gender);
            return View(userDto);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Turismo.Web.Models.UserDTO user)
        {
            if (ModelState.IsValid)
            {

                // HttpClient client = new HttpClient();
                // HttpResponseMessage response = await client.PostAsJsonAsync(
                //"api/products", product);
                // response.EnsureSuccessStatusCode();

                //_context.Add(user);
                //await _context.SaveChangesAsync();
                PersonDTO personDTO = new PersonDTO()
                {
                    PersonId = user.PersonId,
                    UserID = 0,
                    Name = user.Name,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    Ci = user.Ci,
                    Gender = user.Gender,
                    Phone = user.Phone,
                    Password = "***",
                    Email = user.Email,
                    State = 1
                };

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PutAsJsonAsync(
                "https://localhost:7298/Turismo/PeopleControllercs/EditPeople", personDTO);
                var estaado = response.EnsureSuccessStatusCode();
                if (estaado.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            //ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "Gender", user.PersonId);
            //ViewData["RolId"] = new SelectList(_context.Rols, "RolId", "Name", user.RolId);
            List<ComboDTO> roles = new List<ComboDTO>
            {
                new ComboDTO{ Id="A", Name="Administrador"},
                new ComboDTO{ Id="C", Name="Cliente"}
            };
            ViewBag.Rol = new SelectList(roles, "Id", "Name", user.Rol); // Crea un SelectList para los roles
            List<ComboDTO> gender = new List<ComboDTO>
            {
                new ComboDTO{ Id="F", Name="Feminino"},
                new ComboDTO{ Id="M", Name="Masculino"}
            };
            ViewBag.Gender = new SelectList(gender, "Id", "Name", user.Gender); // Crea un SelectList para los roles
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(
            "https://localhost:7298/Turismo/PeopleControllercs/DeletePeople?id=" + id, 1);
            var estaado = response.EnsureSuccessStatusCode();
            if (estaado.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'DataDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
