using Application.Database.IServices;
using DentalBussinesLogic.DTO;
using DentalDatabase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _users;
        public UserController(IRepository<User> users)
        {
            _users = users;
        }
        [HttpPost]
        public IActionResult Register(UserDTO userFromRequest)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = userFromRequest.FirstName,
                    LastName = userFromRequest.LastName,
                    Email = userFromRequest.Email,
                    Password = userFromRequest.Password,
                    Role = userFromRequest.Role
                };
                try
                {
                    _users.Add(user);
                }
                catch (Exception ex)
                {

                }
            }
          return RedirectToAction("AllUsers");
        }
        [HttpGet("/allusers")]
        public IActionResult AllUsers() 
        {
            ViewBag.users = _users.GetAll();
            return View();
        }
    }
}
