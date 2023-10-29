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
        //This is to get the register View 
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        //This is to Register a user.
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
            //This orders the users from latest created.
            var user = _users.GetAll().OrderByDescending(a => a.Id);
            //Viewbag is used to pass the user variable to the view (in this case allusers.cshtml)
            ViewBag.users = user;
            return View();
        }
    }
}
