using EmployeeTask.DatabaseContext;
using EmployeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext dbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.dbContext = employeeDbContext;

        }
        public IActionResult Index()
        {
            var list = dbContext.Employees.Include(x => x.Persons).Include(x => x.Positions).Where(x => x.IsDisabled == false).ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            ViewBag.PositionId = new SelectList(dbContext.Positions.ToList(), "PositionId", "PositionName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            var emailexist = dbContext.Persons.Any(x => x.Email == model.Email);
            if (ModelState.IsValid && emailexist == false)
            {
                Person person = new Person();
                person.FirstName = model.FirstName;
                person.MiddleName = model.MiddleName;
                person.LastName = model.LastName;
                person.Email = model.Email;
                person.Address = model.Address;
                //data.Persons = person;
                dbContext.Persons.Add(person);
                dbContext.SaveChanges();

                var data = new Employee();
                data.PersonId = person.PersonId;
                data.PositionId = model.PositionId;
                data.Salary = model.Salary;
                data.StartDate = DateOnly.FromDateTime(model.StartDate);
                if (model.EndDate.HasValue)
                {
                    data.EndDate = DateOnly.FromDateTime(model.EndDate.Value);
                }
                data.EmployeeCode = model.EmployeeCode;
                data.IsDisabled = false;
                dbContext.Employees.Add(data);
                dbContext.SaveChanges();

                EmployeeJobHistory empJobHistory = new EmployeeJobHistory();
                empJobHistory.PositionId = model.PositionId;
                empJobHistory.EmployeeId = data.EmployeeId;
                empJobHistory.StartDate = model.EmployeeStartDate;
                if (model.EmployeeEndDate.HasValue)
                {
                    empJobHistory.EndDate = model.EmployeeEndDate.Value;
                }
                dbContext.EmployeeJobHistories.Add(empJobHistory);
                dbContext.SaveChanges();
            }
            else
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmployee(int id)
        {
            var data = dbContext.Employees.Include(x=>x.Persons).FirstOrDefault(x=>x.EmployeeId == id);
            ViewBag.PositionId = new SelectList(dbContext.Positions.ToList(), "PositionId", "PositionName", data?.PositionId);
            EmployeeModel employeeModel = new EmployeeModel()
            {
                EmployeeId = data.EmployeeId,
                Address = data.Persons.Address,
                FirstName = data.Persons.FirstName,
                MiddleName = data.Persons.MiddleName,
                LastName = data.Persons.LastName,
                Email = data.Persons.Email,
                Salary = data.Salary,
                EmployeeCode = data.EmployeeCode,
                PositionId = data.PositionId,
                
            };
            employeeModel.StartDate = new DateTime(data.StartDate.Year ,data.StartDate.Month , data.StartDate.Day);
            if (data.EndDate.HasValue)
            {
                var date = data.EndDate.Value;
                employeeModel.StartDate = new DateTime(date.Year, date.Month, date.Day);
            }
            return View(employeeModel);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeModel model)
        {
            try
            {
                var data = dbContext.Employees.Include(x => x.Persons).FirstOrDefault(x => x.EmployeeId == model.EmployeeId);
                data.Salary = model.Salary;
                data.StartDate = DateOnly.FromDateTime(model.StartDate);
                data.EndDate = DateOnly.FromDateTime(model.EndDate.Value);
                data.EmployeeCode = model.EmployeeCode;
                data.Persons.FirstName = model.FirstName;
                dbContext.Employees.Entry(data).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            var del = dbContext.Employees.Find(id);
            return View(del);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            var list = dbContext.Employees.Find(employee.EmployeeId);
            list.IsDisabled = true;
            dbContext.Employees.Entry(list).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ViewHistory(int id)
        {
            var data = dbContext.EmployeeJobHistories.Include(x => x.Positions).Where(x => x.EmployeeId == id).ToList();
            return View(data);
        }

        public IActionResult EditHistory(int id)
        {
            ViewBag.PositionId = new SelectList(dbContext.Positions.ToList(), "PositionId", "PositionName");
            var findEmployeeJob = dbContext.EmployeeJobHistories.Find(id);
            EmployeeHistoryVM empHistory = new EmployeeHistoryVM()
            {
                EmployeeJobHistoryId = findEmployeeJob.EmployeeJobHistoryId,
            };
            empHistory.StartDate = new DateTime(findEmployeeJob.StartDate.Year, findEmployeeJob.StartDate.Month, findEmployeeJob.StartDate.Day);
            empHistory.EndDate = new DateTime(findEmployeeJob.EndDate.Year, findEmployeeJob.EndDate.Month, findEmployeeJob.EndDate.Day);
            return View(empHistory);
        }
        [HttpPost]
        public IActionResult SaveHistory(EmployeeHistoryVM model)
        {
            var data = dbContext.EmployeeJobHistories.Find(model.EmployeeJobHistoryId);
            data.PositionId = model.PositionId;
            data.StartDate = DateOnly.FromDateTime(model.StartDate);
            data.EndDate = DateOnly.FromDateTime(model.EndDate);
            dbContext.EmployeeJobHistories.Entry(data).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("ViewHistory", new {id = data.EmployeeId });
        }

        public virtual IActionResult SearchitemList(string? email, long? employeecode)
        {
            List<Employee> list = new List<Employee>();
            try
            {
                list = dbContext.Employees.Include(x => x.Persons).Include(x => x.Positions).Where(x => x.IsDisabled == false).ToList();

                if (email == null)
                {
                    list = list.ToList();
                }
                else if (email != null)
                {
                    list = list.Where(x => x.Persons.Email == email).ToList();
                }
                else if (employeecode == null)
                {
                    list = list.ToList();
                }
                else if (employeecode != null)
                {
                    list = list.Where(x => x.EmployeeCode == employeecode).ToList();
                }

            }
            catch (Exception ex)
            {

            }
            return View("Index", list);
        }
    }
}
