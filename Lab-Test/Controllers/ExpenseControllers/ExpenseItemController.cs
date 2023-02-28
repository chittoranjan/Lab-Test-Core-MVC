﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model.DtoModels.ExpenseDtoModels;
using Service.IServices.IExpenseServices;
using System.Threading.Tasks;
using Model.DataTableModels;

namespace Lab_Test.Controllers.ExpenseControllers
{
    public class ExpenseItemController : Controller
    {
        private readonly IExpenseItemService _iService;

        public ExpenseItemController(IExpenseItemService iService)
        {
            _iService = iService;
        }

        // GET: ExpenseItem
        public async Task<IActionResult> Index()
        {
            var data = await _iService.GetAllAsync();
            return View(data);
        }

        // GET: ExpenseItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var data = await _iService.GetByIdAsync(id ?? 0);
            if (data == null) return NotFound();
            return View(data);
        }

        // GET: ExpenseItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseItemDto dto)
        {
            if (!ModelState.IsValid) return null;
            var result = await _iService.AddAsync(dto);
            if (result) return RedirectToAction(nameof(Index));
            return View(dto);
        }

        // GET: ExpenseItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var data = await _iService.GetByIdAsync(id ?? 0);
            if (data == null) return NotFound();

            return View(data);
        }

        // POST: ExpenseItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExpenseItemDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return null;

            var result = await _iService.UpdateAsync(dto);
            if (result) return RedirectToAction(nameof(Index));
            return View(dto);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(DataTablePagination<ExpenseItemSearchDto, ExpenseItemSearchDto> searchVm = null)
        {
            searchVm ??= new DataTablePagination<ExpenseItemSearchDto, ExpenseItemSearchDto>();
            if (searchVm?.SearchModel == null) searchVm.SearchModel = new ExpenseItemSearchDto();
            var dataTable = await _iService.Search(searchVm);
            
            return Ok(dataTable);
        }

        // GET: ExpenseItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var data = await _iService.GetByIdAsync(id ?? 0);
            if (data == null) return NotFound();
            return View(data);
        }

        // POST: ExpenseItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _iService.DeleteAsync(id);
            if (result) return RedirectToAction(nameof(Index));

            var data = await _iService.GetByIdAsync(id);
            return View(data);
        }

        // [HttpGet("IsExpenseItemNameExist", Name = "IsExpenseItemNameExist")]
        // public async Task<IActionResult> IsExpItemCategoryNameExistAsync(string name, long id = 0)
        // {
        //     if (string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(name)) return BadRequest("Sorry, No Name Found!");
        //     var data = id > 0 ? await _iService.IsExistsAsync(c => c.Name.Equals(name) && c.Id != id) : await _iService.IsExistsAsync(c => c.Name.Equals(name));
        //     return Ok(data);
        // }
    }
}
