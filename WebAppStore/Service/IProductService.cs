using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Data;
using WebAppStore.Data.Models;
using WebAppStore.Models;

namespace WebAppStore.Services
{
    public class IProductService
    {
        public class ProductService : IProductService
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly IWebHostEnvironment _environment;

            public ProductService(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment environment)
            {
                _context = context;
                _mapper = mapper;
                _environment = environment;
            }

            public async Task<List<ProductDto>> GetAllAsync()
            {
                var result = await _context.ProductsInfo
                    .Include(p => p.Category)
                    .ToListAsync();

                return _mapper.Map<List<ProductDto>>(result);
            }

            public async Task<ProductDto> GetByIdAsync(int id)
            {
                var product = await _context.ProductsInfo
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(c => c.Id == id);

                return _mapper.Map<ProductDto>(product);
            }

            public async Task CreateAsync(ProductDto product)
            {
                var productToAdd = _mapper.Map<ProductsInfo>(product);
                if (product.ImageFile != null)
                {
                    using MemoryStream ms = new MemoryStream();
                    await product.ImageFile.CopyToAsync(ms);
                    productToAdd.ImageContent = ms.ToArray();
                    productToAdd.ImageMimeType = product.ImageFile.ContentType;
                }
                _context.ProductsInfo.Add(productToAdd);
                await _context.SaveChangesAsync();
                product.Id = productToAdd.Id;
            }

            public async Task UpdateAsync(int id, ProductDto product)
            {
                var productToEdit = _mapper.Map<ProductsInfo>(product);

                _context.Attach(new ProductsInfo() { Id = id })
                    .CurrentValues.SetValues(productToEdit);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var productToDelete = await _context.ProductsInfo
                    .FirstOrDefaultAsync(c => c.Id == id);
                _context.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }

            public async Task<bool> ExistAsync(int id)
            {
                return await _context.ProductsInfo.AnyAsync(c => c.Id == id);
            }

            public async Task<FileModel> UploadFileToFileSystem(IFormFile formfile)
            {
                var result = new FileModel();
                if (formfile == null)
                {
                    return result;
                }
                result.OriginalFileName = formfile.FileName;
                result.FileName = Path.GetRandomFileName() + Path.GetExtension(formfile.FileName);
                result.DatabaseValue = Path.Combine("Uploads", result.FileName);
                result.WwwRootPath = Path.Combine(_environment.WebRootPath, result.DatabaseValue);

                //Create upload directory if not exists
                var uploadsDir = Path.Combine(_environment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsDir))
                {
                    Directory.CreateDirectory(uploadsDir);
                }

                using FileStream fs = new FileStream(result.WwwRootPath, FileMode.Create, FileAccess.Write);
                await formfile.CopyToAsync(fs);

                return result;
            }
        }
    }
}
