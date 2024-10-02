using KoalaInventoryManagement.Models;

namespace KoalaInventoryManagement.BLL.Interfaces
{
    public interface IWareHousePrds
    {
        List<WareHouseProduct> GetAll();
        List<WareHouse>? GetProductWareHousesByPrdID(int productID);
        List<Product>? GetWareHouseProductsByWHID(int wareHouseID);

        bool AddItem(WareHouseProduct item);
        bool DeleteItem(int productID, int WareHouseID);
        bool UpdateItem(WareHouseProduct item);
    }
}
