using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICarDealershipRepository
    {
        List<Special> GetSpecails();
        void AddSpecial(Special special);
        void DeleteSepcial(int id);

        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetAllAvailableVehicles();
        List<Vehicle> GetNewVehicles(string filteredBy);
        List<Vehicle> GetUsedVehicles(string filteredBy);
        List<Vehicle> GetFeaturedVehicles();
        List<Vehicle> SearchVehicles(int startDate, int endDate, int minPrice, int maxPrice, bool isNew, string searchTerm);
        List<Vehicle> SalesSearchVehicles(int startDate, int endDate, int minPrice, int maxPrice,string searchTerm);
        //List<Vehicle> GetFiltered(string FilterBy);
        List<Vehicle> GetByPrice(int minPrice, int maxPrice);
        Vehicle GetVehicle(int id);
        void AddVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int id);
        int GetNextInventoryNumber();

        List<Body> GetBodys();
        List<Interior> GetInterior();
        List<Exterior> GetExteriors();

        List<PurchaseType> GetPurchaseTypes();

        void AddMake(VMake make);
        List<VMake> GetMakes();

        List<VModel> GetModelsByMake(int id);
        void AddModel(VModel model);
        List<VModel> GetModels();

        List<Inventory> GetInventory();

        void AddSale(SalesInformation sales);
        List<SalesInformation> GetAllSalesInformation();
        List<SalesReport> GetSalesByDate(DateTime startDate, DateTime endDate, string user);

        //not sure if the user functions like add delete user will be put in here by me
        //or if they have already been implimented by MVC
    }
}
