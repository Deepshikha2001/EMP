using EMP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMP.Controllers
{
    public class EMPController : Controller
    {
        private readonly Employeecontext context;

        public EMPController(Employeecontext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employee.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if(ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Salary = model.Salary,
                };
                context.Employee.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Saved SuccessFully!";
                return RedirectToAction("Index");
            }
            else { TempData[ "message"] = "Empty Field Can't Submit";
                return View(model); 
            }

        }
        public IActionResult Edit(int id)
        {
            var emp = context.Employee.FirstOrDefault(x => x.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary
            };
           
            return View(result);
        }
        [HttpPost] 
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary

            };
            context.Employee.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Updated SuccessFully!";

            return RedirectToAction("Index");    
        }
        public IActionResult Delete(int id)
        {
            var emp = context.Employee.FirstOrDefault(x => x.Id == id);
            context.Employee.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";

            return RedirectToAction("Index");
        }
    }
}
