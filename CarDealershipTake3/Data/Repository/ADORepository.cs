using Data.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class ADORepository : ICarDealershipRepository
    {
        public void AddMake(VMake make)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddMake";

                cmd.Parameters.AddWithValue("@Make", make.Make);
                cmd.Parameters.AddWithValue("@AddedBy", make.AddedBy);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddModel(VModel model)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddModel";

                cmd.Parameters.AddWithValue("@Make", model.MakdId);
                cmd.Parameters.AddWithValue("@AddedBy", model.AddedBy);
                cmd.Parameters.AddWithValue("@Model", model.Model);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddSpecial(Special special)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddSpecial";

                cmd.Parameters.AddWithValue("@Description", special.Description);
                cmd.Parameters.AddWithValue("@Title", special.Title);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddVehicle";
                cmd.Parameters.AddWithValue("@Milage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                if (vehicle.PicturePath != null)
                {
                    cmd.Parameters.AddWithValue("@PicturePath", vehicle.PicturePath);
                }
                else { cmd.Parameters.AddWithValue("@PicturePath", ""); }
                cmd.Parameters.AddWithValue("@IsManual", vehicle.IsManual);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.Model);
                cmd.Parameters.AddWithValue("@InteriorColor", vehicle.InteriorColor);
                cmd.Parameters.AddWithValue("@ExteriorColor", vehicle.ExteriorColor);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddSale(SalesInformation sale)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddSale";
                cmd.Parameters.AddWithValue("@Name", sale.Name);
                cmd.Parameters.AddWithValue("@Email", sale.Email);
                cmd.Parameters.AddWithValue("@Phone", sale.Phone);
                cmd.Parameters.AddWithValue("@Street1", sale.Street1);
                if (sale.Street2 != null)
                {
                    cmd.Parameters.AddWithValue("@Street2", sale.Street2);
                }
                else { cmd.Parameters.AddWithValue("@Street2", ""); }
                cmd.Parameters.AddWithValue("@City", sale.City);
                cmd.Parameters.AddWithValue("@StateId", sale.StateId);
                cmd.Parameters.AddWithValue("@ZipCode", sale.Zipcode);
                cmd.Parameters.AddWithValue("@PurchasePrice", sale.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", sale.PurchaseType);
                cmd.Parameters.AddWithValue("@SoldBy", sale.SoldBy);
                cmd.Parameters.AddWithValue("@InventoryNumber", sale.InventoryNumber);
 
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteSepcial(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteSpecial";

                cmd.Parameters.AddWithValue("@SpecialId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteVehicle(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteVehicle";

                cmd.Parameters.AddWithValue("@InventroyNumber", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Vehicle> GetAllAvailableVehicles()
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllAvailableVehicles";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles;
        }

        public List<SalesInformation> GetAllSalesInformation()
        {
            List<SalesInformation> _salesInformation = new List<SalesInformation>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllSalesInformation";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesInformation currentRow = new SalesInformation();

                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Email = dr["CustomerEmail"].ToString();
                        currentRow.Phone = dr["Phone"].ToString();
                        currentRow.Street1 = dr["Street1"].ToString();
                        currentRow.Street2 = dr["Street2"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.StateId = dr["StateId"].ToString();
                        currentRow.Zipcode = dr["Zipcode"].ToString();
                        currentRow.PurchasePrice = (int)dr["PurchasePrice"];
                        currentRow.SoldBy = dr["Email"].ToString();
                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];
                        currentRow.PurchaseType = dr["PurchaseType"].ToString();
                        currentRow.PurchaseDate = (DateTime)dr["PurchaseDate"];
                        _salesInformation.Add(currentRow);
                    }
                }
            }
            return _salesInformation;
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllVehicles";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles;
        }

        public List<Body> GetBodys()
        {
            List<Body> _bodys = new List<Body>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetBodyStyles";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Body currentRow = new Body();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.BodyId = (int)dr["BodyId"];
                        _bodys.Add(currentRow);
                    }
                }
            }
            return _bodys;
        }



        

        public List<Vehicle> GetByPrice(int minPrice, int maxPrice)
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetByPrice";
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles;
        }

        public List<Exterior> GetExteriors()
        {
            List<Exterior> _exteriors = new List<Exterior>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetExterior";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Exterior currentRow = new Exterior();
                        currentRow.Color = dr["ExteriorColor"].ToString();
                        currentRow.ColorId = (int)dr["ExteriorColorId"];
                        _exteriors.Add(currentRow);
                    }
                }
            }
            return _exteriors;
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetFeatured";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles;
        }

        public List<Interior> GetInterior()
        {
            List<Interior> _interiors = new List<Interior>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetInterior";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interior currentRow = new Interior();
                        currentRow.Color = dr["InteriorColor"].ToString();
                        currentRow.ColorId = (int)dr["InteriorColorID"];
                        _interiors.Add(currentRow);
                    }
                }
            }
            return _interiors;
        }
        public List<Inventory> GetInventory()
        {
            List<Inventory> _inventory = new List<Inventory>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetInventory";
                


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Inventory currentRow = new Inventory();

                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.Count = (int)dr["NumberInStock"];
                        currentRow.StockValue = (int)dr["TotalValue"];
                        currentRow.Make = dr["Make"].ToString();

                        _inventory.Add(currentRow);
                    }
                }
            }
            return _inventory;
        }

        public List<VMake> GetMakes()
        {
            List<VMake> _vMakes = new List<VMake>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMakes";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VMake currentRow = new VMake();
 
   
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.AddedBy = dr["AddedBy"].ToString();
                      //  currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        _vMakes.Add(currentRow);
                    }
                }
            }
            return _vMakes;
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            List<PurchaseType> _type = new List<PurchaseType>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPurchaseTypes";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();


                        currentRow.Type = dr["PurchaseType"].ToString();
                        currentRow.Id = (int)dr["PurchaseTypeId"];
                        _type.Add(currentRow);
                    }
                }
            }
            return _type;
        }

        public List<VModel> GetModels()
        {
            List<VModel> _vModels = new List<VModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetModels";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VModel currentRow = new VModel();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];
                        _vModels.Add(currentRow);
                    }
                }
            }
            return _vModels;
        }

        public List<VModel> GetModelsByMake(int id)
        {
            List<VModel> _vModels = new List<VModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetModelsByMake";
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VModel currentRow = new VModel();
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];
                        _vModels.Add(currentRow);
                    }
                }
            }
            return _vModels;
        }


        public List<Vehicle> GetNewVehicles(string filteredBy)
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetNewVehicles";
                cmd.Parameters.AddWithValue("@FilteredBy", filteredBy);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles;
        }

        public List<SalesReport> GetSalesByDate(DateTime startDate, DateTime endDate, string user)
        {
            List<SalesReport> _Sales = new List<SalesReport>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetSalesByDate";
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@User", user);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReport currentRow = new SalesReport();

                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.ValueOfSales = (int)dr["ValueOfSales"];
                        currentRow.TotalVehicles = (int)dr["TotalSold"];
                        

                        _Sales.Add(currentRow);
                    }
                }
            }
            return _Sales;
        }

        public List<Special> GetSpecails()
        {
            List<Special> _specials = new List<Special>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetSpecials";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.SpecialId = (int)dr["SpecialId"];

                        _specials.Add(currentRow);
                    }
                }
            }
            return _specials; 
        }

        public List<Vehicle> GetUsedVehicles(string filteredBy)
        {
            List<Vehicle> _vehicles = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUsedVehicles";
                cmd.Parameters.AddWithValue("@FilteredBy", filteredBy);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles; ;
        }
        public Vehicle GetVehicle(int id)
        {
            Vehicle vehicle = new Vehicle();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVehicle";

                cmd.Parameters.AddWithValue("@InventoryNumber", id);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        vehicle = currentRow;
                    }
                }
            }
            return vehicle;
        }


        public List<Vehicle> SearchVehicles(int startDate, int endDate, int minPrice, int maxPrice, bool isNew, string searchTerm)
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchVehicles";
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@Condition", isNew);
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles;
        }



        public List<Vehicle> SalesSearchVehicles(int startDate, int endDate, int minPrice, int maxPrice, string searchTerm)
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SalesSearchVehicles";
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();

                        currentRow.InventoryNumber = (int)dr["InventoryNumber"];

                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.Description = dr["VehicleDescription"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsManual = (bool)dr["IsManualTransmision"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.PicturePath = dr["PicturePath"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        _vehicles.Add(currentRow);
                    }
                }
            }
            return _vehicles;
        }

        public int GetNextInventoryNumber()
        {
            int nextID = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetNextInventoryNumber", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nextID = (int)reader["NextInventoryNumber"];
                    }
                }
            }

            return nextID;
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateVehicle";

                cmd.Parameters.AddWithValue("@ModelId", vehicle.Model);
                cmd.Parameters.AddWithValue("@InventoryNumber", vehicle.InventoryNumber);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@IsManualTransmision", vehicle.IsManual);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.Description);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@InteriorColor", vehicle.InteriorColor);
                cmd.Parameters.AddWithValue("@ExteriorColor", vehicle.ExteriorColor);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                if (vehicle.PicturePath != null)
                {
                    cmd.Parameters.AddWithValue("@PicturePath", vehicle.PicturePath);
                }
                else { cmd.Parameters.AddWithValue("@PicturePath", ""); }
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
