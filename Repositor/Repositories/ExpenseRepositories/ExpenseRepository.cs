﻿using AutoMapper;
using Model.EntityModels.ExpenseModels;
using ProjectContext.ProjectDbContext;
using Repository.BaseRepository;
using Repository.IRepositories.IExpenseRepositories;

namespace Repository.Repositories.ExpenseRepositories
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        private LabTestDbContext Context => Db as LabTestDbContext;
        private readonly IMapper _iMapper;
        public ExpenseRepository(LabTestDbContext db, IMapper iMapper) : base(db)
        {
            _iMapper = iMapper;
        }
    }
}
