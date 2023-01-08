using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Context;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly PhoneBookContext _context;

        public ContactController(PhoneBookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}