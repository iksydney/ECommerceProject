﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IProductTypeRepository
    {
        Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
        Task<ProductType> GetProductTypeById(int id);
    }
}
