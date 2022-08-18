using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using BUsineesLogicLayer.Interfaces;
using BUsineesLogicLayer.Reposatories;
using PL.Models;
using AutoMapper;
using PL.Helper;
using Microsoft.AspNetCore.Authorization;

namespace PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue)) {
                var mappedEmps = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeModel>>(await UnitOfWork.EmployeeReposatory.GetAll());
                return View(mappedEmps);
            }
            else
            {

                var mappedEmps = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeModel>>(await UnitOfWork.EmployeeReposatory.SearchEmployee(SearchValue));
                return View(mappedEmps);

            }
        }

        public IActionResult Create()
        {
            ViewBag.Department = UnitOfWork.DepartmentReposatory.GetAll();

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(EmployeeModel employee)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                employee.ImageName = DocumentSettings.UploadFile(employee.Image, "images");
                var mappedEmployee = Mapper.Map<EmployeeModel, Employee>(employee);

                await UnitOfWork.EmployeeReposatory.Add(mappedEmployee);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Department = UnitOfWork.DepartmentReposatory.GetAll();


            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {

            return await Details(id, "edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int? id, EmployeeModel employee)
        {
            if (id != employee.Id)

                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmployee = Mapper.Map<EmployeeModel, Employee>(employee);

                    await UnitOfWork.EmployeeReposatory.Update(mappedEmployee);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    return View(employee);

                }

            }
            ViewBag.Departments = UnitOfWork.DepartmentReposatory.GetAll();

            return View(employee);

        }

        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();

           var employee= await UnitOfWork.EmployeeReposatory.Get(id);
            if (employee == null)
                return NotFound();

            var mappedEmployee = Mapper.Map<Employee, EmployeeModel>(employee);


            return View(ViewName, mappedEmployee);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");


        }
        [HttpPost]
        public async Task< IActionResult> Delete([FromRoute] int? id, EmployeeModel employee)
        {
            if (id != employee.Id)
                return BadRequest();

            try
            {
                var mappedEmployee = Mapper.Map< EmployeeModel, Employee>(employee);
                DocumentSettings.DeletImage(employee.ImageName, "images");

                await UnitOfWork.EmployeeReposatory.Delete(mappedEmployee);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(employee);

            }

        }
  
       

        

    }
}


