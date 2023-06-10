using EmployeeTask.DatabaseContext;
using EmployeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Controllers
{
    public class PersonController : Controller
    {
        private readonly EmployeeDbContext dbContext;

        public PersonController(EmployeeDbContext employeeDbContext) 
        {
            this.dbContext = employeeDbContext;
        }
        public IActionResult Index()
        {
            var data = dbContext.Persons.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            var data = new Person();
            data.FirstName = person.FirstName;
            data.MiddleName = person.MiddleName;
            data.LastName = person.LastName;
            data.Email = person.Email;
            data.Address = person.Address;
            dbContext.Add(data);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var data = dbContext.Persons.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            var data = dbContext.Persons.Find(person.PersonId);
            data.FirstName = person.FirstName;
            data.MiddleName = person.MiddleName;
            data.LastName = person.LastName;
            data.Email = person.Email;
            data.Address = person.Address;
            data.FirstName = person.FirstName;
            dbContext.Persons.Entry(data).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var del = dbContext.Persons.Find(id);
            dbContext.Persons.Remove(del);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
