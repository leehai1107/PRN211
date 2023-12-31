﻿using BussinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO categoryDAO = new CategoryDAO();

        public List<Category> GetCategories() => categoryDAO.GetCategories();

        public Category GetCategory(int id) => categoryDAO.GetCategory(id);
    }
}
