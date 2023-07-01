using EmployeeTask.DatabaseContext;
using EmployeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Controllers
{
    public class PositionController : Controller
    {
        private readonly EmployeeDbContext dbContext;

        public PositionController(EmployeeDbContext employeeDbContext) 
        {
            this.dbContext = employeeDbContext;
        }
        public IActionResult Index()
        {
            var data = dbContext.Positions.OrderBy(x => x.PositionName).ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Position position)
        {
            var data = new Position();
            data.PositionName = position.PositionName;
            dbContext.Add(data);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var data = dbContext.Positions.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Position position)
        {
            var data = dbContext.Positions.Find(position.PositionId);
            data.PositionName = position.PositionName;
            dbContext.Positions.Entry(data).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var del = dbContext.Positions.Find(id);
            dbContext.Positions.Remove(del);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
