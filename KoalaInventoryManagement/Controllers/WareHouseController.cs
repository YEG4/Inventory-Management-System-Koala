using KoalaInventoryManagement.BLL.Interfaces;
using KoalaInventoryManagement.Models;
using KoalaInventoryManagement.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace KoalaInventoryManagement.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly InventoryDBContext _context;
        private readonly IManager<WareHouse> _warehouseManager;
        private readonly IWareHousePrds _wareHousePrdsManager;

        public WareHouseController(InventoryDBContext context
            , IManager<WareHouse> warehouseManager
            , IWareHousePrds wareHousePrdsManager)
        {
            _context = context;
            _warehouseManager = warehouseManager;
            _wareHousePrdsManager = wareHousePrdsManager;
        }

        public IActionResult Index()
        {
            return View(_warehouseManager.GetAll());
        }
    }
}
