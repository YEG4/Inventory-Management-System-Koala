﻿using KoalaInventoryManagement.Models;

namespace KoalaInventoryManagement.ViewModels.Products
{
    public class AllProductsViewModel
    {
        //public List<Product> Products { get; set; } = new List<Product>();
        //public List<WareHouse> WareHouses { get; set; } = new List<WareHouse>();
        //public List<WareHouseProduct> WareHouseProducts { get; set; } = new List<WareHouseProduct>();

        public List<ProductViewModel>? FilteredProducts { get; set; }
        public List<ProductViewModel>? UnFilteredProducts { get; set; }

        public int SelectedWareHouse { get; set; }
        public int SelectedProduct { get; set; }
    }
}
