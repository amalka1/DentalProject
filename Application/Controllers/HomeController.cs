﻿using Application.Database.IServices;
using Application.Models;
using DentalDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<User> _users;

        public HomeController(ILogger<HomeController> logger, IRepository<User> users)
        {
            _users = users;
            _logger = logger;
        }

        public IActionResult Index()
        {
         return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}