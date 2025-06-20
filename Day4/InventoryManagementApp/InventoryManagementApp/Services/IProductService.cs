﻿using InventoryManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
