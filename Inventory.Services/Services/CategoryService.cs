﻿
using Inventory.Data.Models;
using Inventory.Repository.Interfaces;
using Inventory.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services.Services
{
    public class CategoryService:ICategoryService
    {
        public IUnitOfWork _UnitOfWork;
        public CategoryService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        //for testing el mfrood bdl Category yb2a el viewmodel el matloob
        public Category GetbyId(int id)
        {
            return _UnitOfWork.Categories.GetbyId(id);
        }
        
    }
}
