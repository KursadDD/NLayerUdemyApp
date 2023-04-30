﻿using NLayer.Core.Models;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomeResponseDto<CategoryWithProductsDto>>GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
