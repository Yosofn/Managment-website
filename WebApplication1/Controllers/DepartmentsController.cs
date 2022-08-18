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
using AutoMapper;
using PL.Models;
using Microsoft.AspNetCore.Authorization;

namespace PL.Controllers
{

    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IMapper mapper;

        //public IDepartmentReposatory DepartmentReposatory { get; }
        public IUnitOfWork UnitOfWork { get;  }
        public DepartmentController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task <IActionResult> Index()
        {
            var mappedDepartment = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>((await UnitOfWork.DepartmentReposatory.GetAll()));

            return  View(mappedDepartment);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var mappeddepartment=mapper.Map<DepartmentViewModel,Department>(department);
               await UnitOfWork.DepartmentReposatory.Add(mappeddepartment);
                return RedirectToAction("Index");
            }
            return View(department);
        }
       
        public async Task <IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit([FromRoute] int? id, DepartmentViewModel department)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappeddepartment= mapper.Map<DepartmentViewModel,Department>(department);
                   await UnitOfWork.DepartmentReposatory.Update(mappeddepartment);
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return View(department);

                }

            }

            return View(department);

        }
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();

            var department = await UnitOfWork.DepartmentReposatory.Get(id);

            if (department == null)
                return NotFound();
            var mappeddepartment = mapper.Map<Department, DepartmentViewModel>(department);

            return View(ViewName, mappeddepartment);
        }
        public async Task <IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");


        }
        [HttpPost]
        public async Task <IActionResult> Delete([FromRoute] int? id, DepartmentViewModel department)
        {
            if (id != department.Id)
                return BadRequest();

            try
            {  var mappeddepartment=mapper.Map<DepartmentViewModel,Department>(department);
              await  UnitOfWork.DepartmentReposatory.Delete(mappeddepartment);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(department);

            }

        }
      

       
    }
}