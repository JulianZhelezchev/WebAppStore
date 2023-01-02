using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Data.Models;
using WebAppStore.Models;

namespace WebAppStore.AutoMapper
{

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CategoryDto, Categories>()
                .ReverseMap();

            CreateMap<ProductDto, ProductsInfo>()
                .ReverseMap();
        }
    }

}
