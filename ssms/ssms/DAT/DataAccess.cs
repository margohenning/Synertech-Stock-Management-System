using ssms;
using ssms.LTS;
using System;
using System.Collections.Generic;
using System.Linq;
using ssms.DAT;
using ssms.Properties;






namespace ssms.DAT
{
    public static class DataAccess
    {
        #region Antenna
        public static LTS.Antenna GetAntennaItemByID(int? AntennaID)
        {
            LTS.Antenna antenna = new LTS.Antenna();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    antenna = access.Antenna.Where(o => o.AntennaID == AntennaID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return antenna;
        }
        public static List<LTS.Antenna> GetAntenna()
        {
            List<LTS.Antenna> antenna = new List<LTS.Antenna>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    antenna = access.Antenna.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return antenna;
        }
        public static int AddAntenna(LTS.Antenna antenna)
        {
            int? AntennaID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertAntenna(antenna.AntennaNumber, antenna.ReaderID, antenna.RxPower, antenna.TxPower, ref AntennaID);
                }
            }
            catch (Exception ex)
            {
            }
            return AntennaID.Value;
        }
        public static bool RemoveAntenna(int AntennaID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteAntenna(AntennaID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateAntenna(LTS.Antenna antenna)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateAntenna(antenna.AntennaNumber, antenna.ReaderID, antenna.RxPower, antenna.TxPower, antenna.AntennaID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Barcode
        public static LTS.Barcode GetBarcodeItemByID(int? BarcodeID)
        {
            LTS.Barcode barcode = new LTS.Barcode();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    barcode = access.Barcode.Where(o => o.BarcodeID == BarcodeID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return barcode;
        }
        public static List<LTS.Barcode> GetBarcode()
        {
            List<LTS.Barcode> barcode = new List<LTS.Barcode>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    barcode = access.Barcode.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return barcode;
        }
        public static int AddBarcode(LTS.Barcode barcode)
        {
            int? BarcodeID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertBarcode(barcode.BarcodeNumber, ref BarcodeID);
                }
            }
            catch (Exception ex)
            {
            }
            return BarcodeID.Value;
        }
        public static bool RemoveBarcode(int BarcodeID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteBarcode(BarcodeID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateBarcode(LTS.Barcode barcode)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateBarcode(barcode.BarcodeNumber, barcode.BarcodeID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region BookOut
        public static LTS.BookOut GetBookOutItemByID(int? BookOutID)
        {
            LTS.BookOut bookOut = new LTS.BookOut();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    bookOut = access.BookOut.Where(o => o.BookOutID == BookOutID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return bookOut;
        }
        public static List<LTS.BookOut> GetBookOut()
        {
            List<LTS.BookOut> bookOut = new List<LTS.BookOut>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    bookOut = access.BookOut.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return bookOut;
        }
        public static int AddBookOut(LTS.BookOut bookOut)
        {
            int? BookOutID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertBookOut(bookOut.Date, bookOut.ItemID, bookOut.Project, bookOut.Reason, bookOut.UserID, ref BookOutID);
                }
            }
            catch (Exception ex)
            {
            }
            return BookOutID.Value;
        }
        public static bool RemoveBookOut(int BookOutID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteBookOut(BookOutID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateBookOut(LTS.BookOut bookOut)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateBookOut(bookOut.Date, bookOut.ItemID, bookOut.Project, bookOut.Reason, bookOut.UserID, bookOut.BookOutID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Brand
        public static LTS.Brand GetBrandItemByID(int? BrandID)
        {
            LTS.Brand brand = new LTS.Brand();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    brand = access.Brand.Where(o => o.BrandID == BrandID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return brand;
        }
        public static List<LTS.Brand> GetBrand()
        {
            List<LTS.Brand> brand = new List<LTS.Brand>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    brand = access.Brand.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return brand;
        }
        public static int AddBrand(LTS.Brand brand)
        {
            int? BrandID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertBrand(brand.BrandDescription, brand.BrandName, ref BrandID);
                }
            }
            catch (Exception ex)
            {
            }
            return BrandID.Value;
        }
        public static bool RemoveBrand(int BrandID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteBrand(BrandID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateBrand(LTS.Brand brand)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateBrand(brand.BrandDescription, brand.BrandName, brand.BrandID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Category
        public static LTS.Category GetCategoryItemByID(int? CategoryID)
        {
            LTS.Category category = new LTS.Category();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    category = access.Category.Where(o => o.CategoryID == CategoryID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return category;
        }
        public static List<LTS.Category> GetCategory()
        {
            List<LTS.Category> category = new List<LTS.Category>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    category = access.Category.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return category;
        }
        public static int AddCategory(LTS.Category category)
        {
            int? CategoryID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertCategory(category.CategoryDescription, category.CategoryName, ref CategoryID);
                }
            }
            catch (Exception ex)
            {
            }
            return CategoryID.Value;
        }
        public static bool RemoveCategory(int CategoryID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteCategory(CategoryID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateCategory(LTS.Category category)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateCategory(category.CategoryDescription, category.CategoryName, category.CategoryID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Item
        public static LTS.Item GetItemItemByID(int? ItemID)
        {
            LTS.Item item = new LTS.Item();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    item = access.Item.Where(o => o.ItemID == ItemID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }
        public static List<LTS.Item> GetItem()
        {
            List<LTS.Item> item = new List<LTS.Item>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    item = access.Item.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }
        public static int AddItem(LTS.Item item)
        {
            int? ItemID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertItem(item.ItemStatus, item.ProductID, item.StoreID, item.TagEPC, ref ItemID);
                }
            }
            catch (Exception ex)
            {
            }
            return ItemID.Value;
        }
        public static bool RemoveItem(int ItemID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteItem(ItemID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateItem(LTS.Item item)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateItem(item.ItemStatus, item.ProductID, item.StoreID, item.TagEPC, item.ItemID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Product
        public static LTS.Product GetProductItemByID(int? ProductID)
        {
            LTS.Product product = new LTS.Product();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    product = access.Product.Where(o => o.ProductID == ProductID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return product;
        }
        public static List<LTS.Product> GetProduct()
        {
            List<LTS.Product> product = new List<LTS.Product>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    product = access.Product.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return product;
        }
        public static int AddProduct(LTS.Product product)
        {
            int? ProductID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertProduct(product.BarcodeID, product.BrandID, product.CategoryID, product.ProductDescription, product.ProductName, ref ProductID);
                }
            }
            catch (Exception ex)
            {
            }
            return ProductID.Value;
        }
        public static bool RemoveProduct(int ProductID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteProduct(ProductID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateProduct(LTS.Product product)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateProduct(product.BarcodeID, product.BrandID, product.CategoryID, product.ProductDescription, product.ProductName, product.ProductID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Reader
        public static LTS.Reader GetReaderItemByID(int? ReaderID)
        {
            LTS.Reader reader = new LTS.Reader();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    reader = access.Reader.Where(o => o.ReaderID == ReaderID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return reader;
        }
        public static List<LTS.Reader> GetReader()
        {
            List<LTS.Reader> reader = new List<LTS.Reader>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    reader = access.Reader.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return reader;
        }
        public static int AddReader(LTS.Reader reader)
        {
            int? ReaderID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertReader(reader.IPaddress, reader.NumAntennas, reader.SettingsID, ref ReaderID);
                }
            }
            catch (Exception ex)
            {
            }
            return ReaderID.Value;
        }
        public static bool RemoveReader(int ReaderID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteReader(ReaderID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateReader(LTS.Reader reader)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateReader(reader.IPaddress, reader.NumAntennas, reader.SettingsID, reader.ReaderID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Settings
        public static LTS.Settings GetSettingsItemByID(int? SettingsID)
        {
            LTS.Settings settings = new LTS.Settings();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    settings = access.Settings.Where(o => o.SettingsID == SettingsID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return settings;
        }
        public static List<LTS.Settings> GetSettings()
        {
            List<LTS.Settings> settings = new List<LTS.Settings>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    settings = access.Settings.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return settings;
        }
        public static int AddSettings(LTS.Settings settings)
        {
            int? SettingsID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertSettings(settings.SettingsName, settings.SettingsSelect, settings.StoreID, ref SettingsID);
                }
            }
            catch (Exception ex)
            {
            }
            return SettingsID.Value;
        }
        public static bool RemoveSettings(int SettingsID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteSettings(SettingsID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateSettings(LTS.Settings settings)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateSettings(settings.SettingsName, settings.SettingsSelect, settings.StoreID, settings.SettingsID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region Store
        public static LTS.Store GetStoreItemByID(int? StoreID)
        {
            LTS.Store store = new LTS.Store();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    store = access.Store.Where(o => o.StoreID == StoreID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return store;
        }
        public static List<LTS.Store> GetStore()
        {
            List<LTS.Store> store = new List<LTS.Store>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    store = access.Store.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return store;
        }
        public static int AddStore(LTS.Store store)
        {
            int? StoreID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertStore(store.StoreLocation, store.StoreName, ref StoreID);
                }
            }
            catch (Exception ex)
            {
            }
            return StoreID.Value;
        }
        public static bool RemoveStore(int StoreID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteStore(StoreID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateStore(LTS.Store store)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateStore(store.StoreLocation, store.StoreName, store.StoreID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;
        #region User
        public static LTS.User GetUserItemByID(int? UserID)
        {
            LTS.User user = new LTS.User();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    user = access.User.Where(o => o.UserID == UserID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }
        public static List<LTS.User> GetUser()
        {
            List<LTS.User> user = new List<LTS.User>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    user = access.User.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }
        public static int AddUser(LTS.User user)
        {
            int? UserID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.InsertUser(user.UserActivated, user.UserAdmin, user.UserEmail, user.UserIdentityNumber, user.UserName, user.UserPassword, user.UserSurname, ref UserID);
                }
            }
            catch (Exception ex)
            {
            }
            return UserID.Value;
        }
        public static bool RemoveUser(int UserID)
        {
            bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.DeleteUser(UserID);
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
            }
            return deleted;
        }
        public static bool UpdateUser(LTS.User user)
        {
            bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
                    access.UpdateUser(user.UserActivated, user.UserAdmin, user.UserEmail, user.UserIdentityNumber, user.UserName, user.UserPassword, user.UserSurname, user.UserID);
                    completed = true;
                }

            }
            catch (Exception ex)
            {
                completed = false;
            }
            return completed;
        }
        #endregion;




























    }
}
