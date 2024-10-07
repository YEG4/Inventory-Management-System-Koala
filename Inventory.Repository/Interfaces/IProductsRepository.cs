using KoalaInventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Interfaces
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAll(string includeProperties = "");
     
        IEnumerable<Product>? GetProductsBySupplier(int supplierId);
        IEnumerable<Product>? GetProductsByCategory(int CategoryId);

    }
}
