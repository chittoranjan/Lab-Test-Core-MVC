﻿using Model.DataTablePaginationModels;
using Model.DtoModels.ExpenseDtoModels;
using Model.EntityModels.ExpenseModels;
using Service.IBaseService;
using System.Threading.Tasks;

namespace Service.IServices.IExpenseServices
{
    public interface IExpenseItemService : IBaseService<ExpenseItem>
    {
        Task<bool> AddAsync(ExpenseItemDto dto);
        Task<bool>UpdateAsync(ExpenseItemDto dto);
        new Task<ExpenseItemDto> GetByIdAsync(int id);
        ExpenseItemDto ConvertModelToDto(ExpenseItem model);
        Task<DataTablePagination<ExpenseItemSearchDto>> Search(DataTablePagination<ExpenseItemSearchDto> searchDto);
        Task<bool> DeleteAsync(int id);
    }
}
