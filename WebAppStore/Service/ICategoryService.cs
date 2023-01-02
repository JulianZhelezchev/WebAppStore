using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Models;

namespace WebAppStore.Services
{
    public interface ICategoryService
    {     
            Task CreateAsync(CategoryDto category);
            Task DeleteAsync(int id);
            Task<List<CategoryDto>> GetAllAsync();
            Task<CategoryDto> GetByIdAsync(int id);
            Task UpdateAsync(int id, CategoryDto category);
            Task<bool> ExistAsync(int id);
        
    }
}
