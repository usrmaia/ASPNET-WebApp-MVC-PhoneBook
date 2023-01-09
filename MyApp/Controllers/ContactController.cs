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
        
        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)  return NotFound();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var getContact = _context.Contacts.Find(contact.Id);

            getContact.Name = contact.Name;
            getContact.PhoneNumber = contact.PhoneNumber;
            getContact.Active = contact.Active;

            _context.Contacts.Update(getContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)  return NotFound();
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)  return NotFound();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var getContact = _context.Contacts.Find(contact.Id);

            _context.Contacts.Remove(getContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}