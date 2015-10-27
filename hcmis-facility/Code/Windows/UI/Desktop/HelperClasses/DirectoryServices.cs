using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.DirectoryService;
using DosageForm = BLL.DosageForm;
using Items = BLL.Items;
using Product = BLL.Product;
using Region = BLL.Region;
using Supplier = BLL.Supplier;
using Unit = BLL.Unit;
using Woreda = BLL.Woreda;
using Zone = BLL.Zone;
using ABC = BLL.ABC;
using System.ServiceModel;
using Stores = BLL.Stores;

namespace PharmInventory.HelperClasses
{
    static class DirectoryServices
    {
        private static string userName = "hcmishe";
        private static string password = "hcmishe";
        public static void RefreshFromDirectoryServices()
        {
            DirectoryService.Service1SoapClient soapClient = new Service1SoapClient();
            BasicHttpBinding binding = (BasicHttpBinding)soapClient.Endpoint.Binding;
            binding.MaxReceivedMessageSize = binding.ReaderQuotas.MaxArrayLength = binding.ReaderQuotas.MaxStringContentLength = 630000000;


            int notFound = 0;
            int exactNameNotFound = 0;
            int different = 0;
            int similar = 0;
            long lastVersion = soapClient.GetLastVersion(userName, password);

            GeneralInfo generalInfo = new GeneralInfo();
            generalInfo.LoadAll();
            int? previousVersion = null;
            if (!generalInfo.IsColumnNull("HospitalContact"))
            {
                try
                {
                    previousVersion = int.Parse(generalInfo.HospitalContact);
                }
                catch
                {
                    previousVersion = null;
                }
            }

           // RefreshAdminUnits(soapClient, previousVersion);
            RefreshUnits(soapClient, previousVersion);
            RefreshVEN(soapClient, previousVersion);
            RefreshABC(soapClient, previousVersion);
            // //RefreshSuppliers(soapClient, previousVersion);
            RefreshDosageForms(soapClient, previousVersion);

            RefreshTypes(soapClient, previousVersion);
            //RefreshDrugCategory(soapClient, previousVersion);
            //RefreshSupplyCategory(soapClient, previousVersion);
            //RefreshDrugSubCategory(soapClient, previousVersion);

            //// RefreshPrograms(soapClient,previousVersion);
            RefreshProducts(soapClient, previousVersion);
            // //SaveItemList(soapClient.GetSupplyItems(userName, password, previousVersion, null));

            RefreshItems(soapClient, previousVersion, 1);
            RefreshItems(soapClient, previousVersion, 2);

            //RefreshItemUnits(soapClient, 0);

                //RefreshDrugItemCategory(soapClient, previousVersion);

                //RefreshItemSupplyCategory(soapClient, previousVersion);

          

            generalInfo.HospitalContact = lastVersion.ToString();
            generalInfo.Save();
        }

        private static void RefreshItemUnits(Service1SoapClient soapClient, int? previousVersion)
        {
            List<ItemUnitWithUnitDetail> list = soapClient.GetItemUnitsWithUnitDetail(userName, password,previousVersion, null);
            var iu = new BLL.ItemUnit();
            foreach (ItemUnitWithUnitDetail v in list)
            {
                iu.LoadByPrimaryKey(v.ID);
                if(iu.RowCount==0)
                {
                    iu.AddNew();
                }
                if(v.ID != 0)
                iu.ID = v.ID;
                if (v.ItemID != null && v.Text!=null)
                {

                    var itm = new Items(); 
                    iu.ItemID = itm.LoadByMappingID(v.ItemID.Value);
                }
                else
                {
                    continue;
                }
                    iu.QtyPerUnit = v.QtyPerUnit;
                    iu.Text = v.Text;
                    iu.Save();
            }

        }

        

        private static void RefreshABC(Service1SoapClient soapClient, int? previousVersion)
        {
            List<DirectoryService.ABC> list = soapClient.GetABCs(userName, password, previousVersion, null);
            
            BLL.ABC bv = new BLL.ABC();
            foreach (PharmInventory.DirectoryService.ABC v in list)
            {
                // try to load by primary key
                bv.LoadByPrimaryKey(v.ID.Value);

                // if the entry doesn't exist, create it
                if (bv.RowCount == 0)
                {
                    bv.AddNew();
                }
                // populate the contents of v on the to the database list
                if (v.ID.HasValue)
                    bv.ID = v.ID.Value;
                if (v.Value != "" && v.Value != null)
                    bv.Value = v.Value;
                if (v.Description != "" && v.Description != null)
                    bv.Description = v.Description;

                bv.Save();
            }
        }

        private static void RefreshVEN(Service1SoapClient soapClient, int? previousVersion)
        {
            List<DirectoryService.VEN> list = soapClient.GetVENs(userName, password, previousVersion, null);
            BLL.VEN bv = new BLL.VEN();
            foreach (PharmInventory.DirectoryService.VEN v in list)
            {
                // try to load by primary key
                bv.LoadByPrimaryKey(v.ID.Value);

                // if the entry doesn't exist, create it
                if (bv.RowCount == 0)
                {
                    bv.AddNew();
                }
                // populate the contents of v on the to the database list
                if (v.ID.HasValue)
                    bv.ID = v.ID.Value;
                if (v.Value != "" && v.Value != null)
                    bv.Value = v.Value;
                if (v.Description != "" && v.Description != null)
                    bv.Description = v.Description;
                //if( v.IsDeleted.HasValue )
                //     bv.IsDeleted = v.IsDeleted.Value;
                //if( v.UpdateTime.HasValue )
                //     bv.UpdateTime = v.UpdateTime.Value;

                bv.Save();
            }
        }

        private static void RefreshTypes(Service1SoapClient soapClient, int? previousVersion)
        {
            List<DirectoryService.CommodityType> dsCommodityTypeList = soapClient.GetCommodityTypes(userName, password, previousVersion, null);
            BLL.Type localCommodityType = new BLL.Type();

            foreach (var dsCommodityType in dsCommodityTypeList)
            {
                localCommodityType.LoadByPrimaryKey(int.Parse(dsCommodityType.ID.Value.ToString()));
                if (localCommodityType.RowCount > 0)
                {
                    if (dsCommodityType.Name != localCommodityType.Name)
                    {
                        localCommodityType.ID = dsCommodityType.ID.Value;
                        localCommodityType.Name = dsCommodityType.Name;
                        localCommodityType.Save();
                    }
                }
                else
                {
                    localCommodityType.FlushData();
                    localCommodityType.AddNew();
                    localCommodityType.ID = dsCommodityType.ID.Value;
                    localCommodityType.Name = dsCommodityType.Name;
                    localCommodityType.Save();
                    XtraMessageBox.Show("Added " + dsCommodityType.Name);
                }
            }
        }

        private static void RefreshDrugItemCategory(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.DrugItemSubCategory> dsDrugItemSubCategorysList = soapClient.GetDrugItemSubCategory(userName, password, lastVersionNumber, null);
            BLL.ProductsCategory localDrugItemSubCategory = new ProductsCategory();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsDrugItemSubCategory in dsDrugItemSubCategorysList)
            {
                if (dsDrugItemSubCategory.SubCategoryID.HasValue)
                    Console.WriteLine(dsDrugItemSubCategory.SubCategoryID.Value);
                localDrugItemSubCategory.LoadByPrimaryKey(int.Parse(dsDrugItemSubCategory.ID.Value.ToString()));
                if (localDrugItemSubCategory.RowCount > 0)
                {
                    if (dsDrugItemSubCategory.SubCategoryID.HasValue)
                    {
                        Console.Write(localDrugItemSubCategory.SubCategoryID);
                        if (dsDrugItemSubCategory.SubCategoryID.Value == localDrugItemSubCategory.SubCategoryID &&
                            dsDrugItemSubCategory.ItemId.Value == localDrugItemSubCategory.ItemId)
                        {
                            similar++;
                        }

                        else //Needs more consideration
                        {
                            different = HandleDifferentDrugItemSubCategories(dsDrugItemSubCategory,
                                                                             localDrugItemSubCategory, different);
                        }
                    }
                }
                else
                {
                    different = HandleDifferentDrugItemSubCategories(dsDrugItemSubCategory, localDrugItemSubCategory, different);
                }
            }
            //XtraMessageBox.Show("Drug Category\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static int HandleDifferentDrugItemSubCategories(DrugItemSubCategory dsDrugItemSubCategory, ProductsCategory localDrugItemSubCategory, int different)
        {
            Console.WriteLine("Not Found!");

            localDrugItemSubCategory.AddNew();

            BLL.Items itm = new Items();
            if (dsDrugItemSubCategory.ItemId.HasValue)
            {
                if (itm.LoadByMappingID(dsDrugItemSubCategory.ItemId.Value) != -1)
                    localDrugItemSubCategory.ItemId = itm.ID;
                else
                {
                    return different;
                }
            }

            ABC comp = new ABC();

            if (!dsDrugItemSubCategory.SubCategoryID.HasValue)
                return -1;

            comp.LoadQuery(string.Format("Select * from ProductsCategory WHERE SubCategoryID = {0} and ItemId={1}", dsDrugItemSubCategory.SubCategoryID.Value, itm.ID));
            if (comp.RowCount > 0)//The mapping already exists. We are not going to save the newly created entry
                return different;

            different++;
            localDrugItemSubCategory.SubCategoryID = dsDrugItemSubCategory.SubCategoryID.Value;

            localDrugItemSubCategory.Save();
            return different;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soapClient"></param>
        /// <param name="lastVersionNumber"></param>
        /// <param name="DrugsOrSuppliesMode">1- Drugs, 2-Supplies</param>
        private static void RefreshItems(Service1SoapClient soapClient, int? lastVersionNumber, int DrugsOrSuppliesMode)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.Items> dsItemsList = new List<DirectoryService.Items>();
            if (DrugsOrSuppliesMode == 1)
            {
                dsItemsList = soapClient.GetDrugItems(userName, password, 0, null);
            }
            else if (DrugsOrSuppliesMode == 2)
            {
                dsItemsList = soapClient.GetSupplyItems(userName, password, 0, null);
            }

            BLL.Items localItem = new Items();

            similar = 0;
            different = 0;
            exactNameNotFound = 0;
            notFound = 0;

            foreach (var dsItem in dsItemsList)
            {
                Console.WriteLine(dsItem.StockCode);

                //First search by mapping ID.
                localItem.LoadByMappingID(dsItem.ID.Value);
                if (localItem.RowCount > 0)//Item already mapped.
                {
                    FillItemAttributes(dsItem, ref localItem);
                }

                else
                {
                    localItem.LoadByPrimaryKey(int.Parse(dsItem.ID.Value.ToString()));
                    if (localItem.RowCount > 0 && localItem.IsMapped == false)
                    //if (localItem.RowCount > 0)
                    {
                        Console.Write(localItem);
                        //if (dsItem.StockCode == localItem.StockCode && dsItem.Strength==localItem.Strength && dsItem.DosageFormID == localItem.DosageFormID && dsItem.UnitID == localItem.UnitID && dsItem.VEN == localItem.VEN && dsItem.ABC==localItem.ABC && dsItem.IsDeleted=localItem.IsDiscontinued && dsItem.EDL==localItem.EDL && )

                        try
                        {
                            if (dsItem.IINID == localItem.IINID && (dsItem.DosageFormID == null ? true : dsItem.DosageFormID == localItem.DosageFormID) &&
                                (!string.IsNullOrEmpty(dsItem.Strength) && dsItem.Strength.Replace(" ", "") == localItem.Strength.Replace(" ", "")))
                            {
                                similar++;
                                //localItem.Code = dsItem.ID.Value.ToString(); //We use the CODE field as the mapping field
                                //localItem.Save();
                                FillItemAttributes(dsItem, ref localItem);
                            }
                            else
                            {
                                different++;
                                exactNameNotFound = HandleDifferentItems(exactNameNotFound, ref notFound, dsItem, localItem);
                            }
                        }
                        catch
                        {
                            different++;
                            exactNameNotFound = HandleDifferentItems(exactNameNotFound, ref notFound, dsItem, localItem);

                        }





                    }
                    else
                    {
                        Console.WriteLine("Not Found!");
                        different++;

                        exactNameNotFound = HandleDifferentItems(exactNameNotFound, ref notFound, dsItem, localItem);
                    }
                }
            }
            //XtraMessageBox.Show("Items\nSimilar Items: " + similar + "\nDifferent Items: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static void RefreshProducts(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.Product> dsProductsList = soapClient.GetProducts(userName, password, lastVersionNumber, null);
            BLL.Product localProduct = new Product();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsProduct in dsProductsList)
            {
                Console.WriteLine(dsProduct.Name);
                //First search by mapping ID.
                localProduct.LoadByMappingID(dsProduct.ID.Value);
                if (localProduct.RowCount > 0)//Product already mapped.
                {
                    FillProductAttributes(dsProduct, localProduct);
                }

                else//Product is not mapped.  We need to do searching
                {
                    localProduct.LoadByPrimaryKey(int.Parse(dsProduct.ID.Value.ToString()));
                    if (localProduct.RowCount > 0 && localProduct.IsMapped == false)
                    {
                        Console.Write(localProduct.IIN);
                        if (dsProduct.Name.Replace(" ", "") == localProduct.IIN.Replace(" ", ""))
                        {
                            similar++;
                            //localProduct.ATC = dsProduct.ID.Value.ToString();
                            //localProduct.Save();
                            FillProductAttributes(dsProduct, localProduct);
                        }

                        else
                        {
                            different++;
                            exactNameNotFound = HandleDifferentProducts(exactNameNotFound, ref notFound, dsProduct,
                                                                        localProduct);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Found!");
                        different++;
                        exactNameNotFound = HandleDifferentProducts(exactNameNotFound, ref notFound, dsProduct,
                                                                    localProduct);
                    }

                }


            }
            //XtraMessageBox.Show("Products\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static void RefreshPrograms(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.Program> dsProgramssList = soapClient.GetPrograms(userName, password, lastVersionNumber, null);
            BLL.Programs localPrograms = new Programs();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsPrograms in dsProgramssList)
            {
                Console.WriteLine(dsPrograms.Name);
                localPrograms.LoadByPrimaryKey(int.Parse(dsPrograms.ID.Value.ToString()));
                if (localPrograms.RowCount > 0)
                {
                    Console.Write(localPrograms.Name);
                    if (dsPrograms.Name.Replace(" ", "") == localPrograms.Name.Replace(" ", ""))
                    {
                        similar++;
                    }

                    else//Needs more consideration
                    {
                        different++;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found!");
                    different++;

                    ABC comp = new ABC();
                    comp.LoadQuery(string.Format("Select * from Programs WHERE Name = '{0}'", dsPrograms.Name));
                    if (comp.RowCount == 0)
                    {
                        exactNameNotFound++;
                        //ABC similarComp = new ABC();
                        //similarComp.LoadQuery(string.Format("Select * from Programs WHERE soundex(IIN)=soundex('{0}')", item.Name));
                        //if (similarComp.RowCount == 0)
                        //{
                        notFound++;

                        localPrograms.AddNew();
                        localPrograms.Name = dsPrograms.Name; //What about TypeID and Description
                        if (dsPrograms.Description != null) localPrograms.Description = dsPrograms.Description;
                        if (dsPrograms.ParentID.HasValue) localPrograms.ParentID = dsPrograms.ParentID.Value;
                        if (dsPrograms.ProgramCode != null) localPrograms.ProgramCode = dsPrograms.ProgramCode;
                        localPrograms.Save();
                        //}
                    }

                    else//It is found (No mapping done here though) - Assuming all the tables are similar
                    {
                        //localPrograms.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                        ////Do something here
                        //localPrograms.Save();
                    }
                }
            }
            //XtraMessageBox.Show("Programs\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static void RefreshDrugSubCategory(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.DrugSubCategory> dsDrugSubCategoryList = soapClient.GetDrugSubCategory(userName, password, lastVersionNumber, null);
            BLL.SubCategory localDrugSubCategory = new SubCategory();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsDrugSubCategory in dsDrugSubCategoryList)
            {
                Console.WriteLine(dsDrugSubCategory.SubCategoryName);
                localDrugSubCategory.LoadByPrimaryKey(int.Parse(dsDrugSubCategory.ID.Value.ToString()));
                if (localDrugSubCategory.RowCount > 0)
                {
                    Console.Write(localDrugSubCategory.SubCategoryName);
                    if (dsDrugSubCategory.SubCategoryName.Replace(" ", "") == localDrugSubCategory.SubCategoryName.Replace(" ", "") && dsDrugSubCategory.CategoryId == localDrugSubCategory.CategoryId)
                    {
                        similar++;
                    }

                    else//Needs more consideration
                    {
                        different++;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found!");
                    different++;

                    ABC comp = new ABC();
                    comp.LoadQuery(string.Format("Select * from SubCategory WHERE CategoryId = {0} and SubCategoryName = '{1}'", dsDrugSubCategory.CategoryId, dsDrugSubCategory.SubCategoryName));
                    if (comp.RowCount == 0)
                    {
                        exactNameNotFound++;
                        //ABC similarComp = new ABC();
                        //similarComp.LoadQuery(string.Format("Select * from DrugSubCategory WHERE soundex(IIN)=soundex('{0}')", item.Name));
                        //if (similarComp.RowCount == 0)
                        //{
                        notFound++;

                        localDrugSubCategory.AddNew();
                        if (dsDrugSubCategory.CategoryId.HasValue)
                            localDrugSubCategory.CategoryId = dsDrugSubCategory.CategoryId.Value;
                        if (dsDrugSubCategory.SubCategoryName != null)
                            localDrugSubCategory.SubCategoryName = dsDrugSubCategory.SubCategoryName;
                        if (dsDrugSubCategory.SubCategoryCode != null)
                            localDrugSubCategory.SubCategoryCode = dsDrugSubCategory.SubCategoryCode;
                        if (dsDrugSubCategory.Description != null)
                            localDrugSubCategory.Description = dsDrugSubCategory.Description;
                        if (dsDrugSubCategory.ParentID.HasValue)
                            localDrugSubCategory.ParentID = dsDrugSubCategory.ParentID.Value;
                        localDrugSubCategory.Save();
                        //}
                    }

                    else//It is found (No mapping done here though) - Assuming all the tables are similar
                    {
                        //localDrugSubCategory.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                        ////Do something here
                        //localDrugSubCategory.Save();
                    }
                }
            }
            //XtraMessageBox.Show("Drug Sub Category\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static void RefreshItemSupplyCategory(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.ItemSupplyCategory> dsItemSupplyCategoryList = soapClient.GetItemSupplyCategories(userName, password, lastVersionNumber, null);
            BLL.ItemSupplyCategory localItemSupplyCategory = new BLL.ItemSupplyCategory();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsItemSupplyCategory in dsItemSupplyCategoryList)
            {
                Console.WriteLine(dsItemSupplyCategory.ItemID + "," + dsItemSupplyCategory.CategoryID);
                localItemSupplyCategory.LoadByPrimaryKey(int.Parse(dsItemSupplyCategory.ID.Value.ToString()));

                BLL.Items item = new Items();
                if (dsItemSupplyCategory.ItemID.HasValue)
                    item.LoadByMappingID(dsItemSupplyCategory.ItemID.Value);

                if (localItemSupplyCategory.RowCount > 0)
                {
                    //Console.Write(localItemSupplyCategory.ItemID + "," + localItemSupplyCategory.CategoryID);

                    if (dsItemSupplyCategory.CategoryID.HasValue)
                        localItemSupplyCategory.CategoryID = dsItemSupplyCategory.CategoryID.Value;
                    if (dsItemSupplyCategory.ItemID.HasValue)
                        localItemSupplyCategory.ItemID = item.ID;

                    localItemSupplyCategory.Save();

                    //if (localItemSupplyCategory.ItemID == item.ID && dsItemSupplyCategory.CategoryID.Value == localItemSupplyCategory.CategoryID)
                    //{
                    //    similar++;
                    //}

                    //else//Needs more consideration
                    //{
                    //    //localItemSupplyCategory.ItemID = item.ID;
                    //    //localItemSupplyCategory.CategoryID = dsItemSupplyCategory.CategoryID.Value;
                    //    //localItemSupplyCategory.Save();
                    //    HandleDifferentItemSupplyCategory(ref different, ref exactNameNotFound, ref notFound, localItemSupplyCategory, dsItemSupplyCategory, item);
                    //}
                }
                else
                {
                    //HandleDifferentItemSupplyCategory(ref different, ref exactNameNotFound, ref notFound, localItemSupplyCategory, dsItemSupplyCategory, item);
                    localItemSupplyCategory.AddNew();
                    localItemSupplyCategory.ID = dsItemSupplyCategory.ID.Value;
                    if (dsItemSupplyCategory.CategoryID.HasValue)
                        localItemSupplyCategory.CategoryID = dsItemSupplyCategory.CategoryID.Value;
                    if (dsItemSupplyCategory.ItemID.HasValue)
                        localItemSupplyCategory.ItemID = item.ID;

                    localItemSupplyCategory.Save();
                }
            }
            //XtraMessageBox.Show("Drug Sub Category\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static void HandleDifferentItemSupplyCategory(ref int different, ref int exactNameNotFound, ref int notFound, BLL.ItemSupplyCategory localItemSupplyCategory, DirectoryService.ItemSupplyCategory dsItemSupplyCategory, BLL.Items item)
        {
            Console.WriteLine("Not Found!");
            different++;

            ABC comp = new ABC();
            comp.LoadQuery(string.Format("Select * from ItemSupplyCategory WHERE ItemID = {0} and CategoryID = {1}", item.ID, dsItemSupplyCategory.CategoryID));
            if (comp.RowCount == 0)
            {
                exactNameNotFound++;
                //ABC similarComp = new ABC();
                //similarComp.LoadQuery(string.Format("Select * from DrugSubCategory WHERE soundex(IIN)=soundex('{0}')", item.Name));
                //if (similarComp.RowCount == 0)
                //{
                notFound++;

                localItemSupplyCategory.AddNew();
                localItemSupplyCategory.ID = dsItemSupplyCategory.ID.Value;
                if (dsItemSupplyCategory.CategoryID.HasValue)
                    localItemSupplyCategory.CategoryID = dsItemSupplyCategory.CategoryID.Value;
                if (dsItemSupplyCategory.ItemID.HasValue)
                    localItemSupplyCategory.ItemID = item.ID;

                localItemSupplyCategory.Save();
                //}
            }

            else//It is found (No mapping done here though) - Assuming all the tables are similar
            {
                //localDrugSubCategory.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                ////Do something here
                //localDrugSubCategory.Save();
            }
        }



        private static void RefreshDrugCategory(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.DrugCategory> dsDrugCategorysList = soapClient.GetDrugCategory(userName, password, lastVersionNumber, null);
            BLL.Category localDrugCategory = new Category();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsDrugCategory in dsDrugCategorysList)
            {
                Console.WriteLine(dsDrugCategory.CategoryName);
                localDrugCategory.LoadByPrimaryKey(int.Parse(dsDrugCategory.ID.Value.ToString()));
                if (localDrugCategory.RowCount > 0)
                {
                    Console.Write(localDrugCategory.CategoryName);
                    if (dsDrugCategory.CategoryName != null && dsDrugCategory.CategoryName.Replace(" ", "") == localDrugCategory.CategoryName.Replace(" ", ""))
                    {
                        similar++;
                    }

                    else//Needs more consideration
                    {
                        different++;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found!");
                    different++;

                    ABC comp = new ABC();

                    comp.LoadQuery(string.Format("Select * from DrugCategory WHERE CategoryName = '{0}'", dsDrugCategory.CategoryName));
                    if (comp.RowCount == 0)
                    {
                        exactNameNotFound++;
                        //ABC similarComp = new ABC();
                        //similarComp.LoadQuery(string.Format("Select * from DrugCategory WHERE soundex(IIN)=soundex('{0}')", item.Name));
                        //if (similarComp.RowCount == 0)
                        //{
                        notFound++;

                        localDrugCategory.AddNew();
                        localDrugCategory.ID = dsDrugCategory.ID.Value;
                        if (dsDrugCategory.CategoryName != null)
                        localDrugCategory.CategoryName = dsDrugCategory.CategoryName;
                        if (dsDrugCategory.CategoryCode != null)
                            localDrugCategory.CategoryCode = dsDrugCategory.CategoryCode;
                        //if (dsDrugCategory.Description != null)
                        //    localDrugCategory.Description = dsDrugCategory.Description;
                        localDrugCategory.Save();
                        //}
                    }

                    else//It is found (No mapping done here though) - Assuming all the tables are similar
                    {
                        //localDrugCategory.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                        ////Do something here
                        //localDrugCategory.Save();
                    }
                }
            }
            //XtraMessageBox.Show("Drug Category\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static void RefreshSupplyCategory(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.SupplyCategory> dsSupplyCategoryList = soapClient.GetSupplyCategories(userName, password, lastVersionNumber, null);
            BLL.SupplyCategory localSupplyCategory = new BLL.SupplyCategory();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsSupplyCategory in dsSupplyCategoryList)
            {
                Console.WriteLine(dsSupplyCategory.Name);
                localSupplyCategory.LoadByPrimaryKey(int.Parse(dsSupplyCategory.ID.Value.ToString()));
                if (localSupplyCategory.RowCount > 0)
                {
                    Console.Write(localSupplyCategory.Name);
                    if (dsSupplyCategory.Name.Replace(" ", "") == localSupplyCategory.Name.Replace(" ", ""))
                    {
                        similar++;
                    }

                    else//Needs more consideration
                    {
                        different++;
                    }
                }
                else
                {
                    localSupplyCategory.AddNew();
                    localSupplyCategory.Name = dsSupplyCategory.Name;
                    localSupplyCategory.ID = dsSupplyCategory.ID.Value;
                    if (dsSupplyCategory.ParentId.HasValue)
                        localSupplyCategory.ParentId = dsSupplyCategory.ParentId.Value;
                    localSupplyCategory.Save();

                    /*
                    Console.WriteLine("Not Found!");
                    different++;

                    ABC comp = new ABC();

                    comp.LoadQuery(string.Format("Select * from SupplyCategory WHERE Name = '{0}'", dsSupplyCategory.Name));
                    if (comp.RowCount == 0)
                    {
                        exactNameNotFound++;
                        //ABC similarComp = new ABC();
                        //similarComp.LoadQuery(string.Format("Select * from DrugCategory WHERE soundex(IIN)=soundex('{0}')", item.Name));
                        //if (similarComp.RowCount == 0)
                        //{
                        notFound++;

                        localSupplyCategory.AddNew();
                        localSupplyCategory.Name = dsSupplyCategory.Name;
                        localSupplyCategory.ID = dsSupplyCategory.ID.Value; //If it lets us save to the ID.  If not, schema modification needed.
                        if (dsSupplyCategory.ParentId.HasValue)
                            localSupplyCategory.ParentId = dsSupplyCategory.ParentId.Value;
                        
                        localSupplyCategory.Code = dsSupplyCategory.ID.Value.ToString(); //The mapping done here too.  Just in case.
                        localSupplyCategory.Save();
                        //}
                    }

                    else//It is found (No mapping done here though) - Assuming all the tables are similar
                    {
                        //localDrugCategory.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                        ////Do something here
                        //localDrugCategory.Save();
                    }
                    */
                }
            }
            //XtraMessageBox.Show("Drug Category\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }
       
        private static void FillDosageFormAttributes(DirectoryService.DosageForm dsDosageForm, DosageForm localDosageForm)
        {
            localDosageForm.Form = dsDosageForm.Form;
            
            //localDosageForm.TypeID = int.Parse(dsDosageForm.TypeID.Value.ToString());
            
            if (dsDosageForm.ID.HasValue) 
                localDosageForm.Description = dsDosageForm.ID.Value.ToString(); //Mapping done here
            localDosageForm.Save();
        }

        private static void RefreshDosageForms(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.DosageForm> dsDosageFormsList = soapClient.GetDosageForms(userName, password, lastVersionNumber, null);
            BLL.DosageForm localDosageForm = new DosageForm();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsDosageForm in dsDosageFormsList)
            {
                Console.WriteLine(dsDosageForm.Form);
                localDosageForm.LoadByMappingID(int.Parse(dsDosageForm.ID.Value.ToString())); //.LoadByPrimaryKey(int.Parse(dsDosageForm.ID.Value.ToString()));
                if (localDosageForm.RowCount > 0)//Dosage Form already mapped.
                {
                    FillDosageFormAttributes(dsDosageForm, localDosageForm);
                }

                else//Dosage Form is not mapped.  We need to do searching
                {
                    localDosageForm.LoadByPrimaryKey(int.Parse(dsDosageForm.ID.Value.ToString()));
                    if (localDosageForm.RowCount > 0 && localDosageForm.IsMapped == false)
                    {
                        Console.Write(localDosageForm.Form);
                        if (dsDosageForm.Form.Replace(" ", "") == localDosageForm.Form.Replace(" ", ""))
                        {
                            similar++;
                            FillDosageFormAttributes(dsDosageForm, localDosageForm);
                        }

                        else //Needs more consideration
                        {
                            different++;
                            HandleDifferentDosageForms(dsDosageForm, localDosageForm);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Not Found!");
                        different++;
                        HandleDifferentDosageForms(dsDosageForm, localDosageForm);
                    }
                }
            }
            //XtraMessageBox.Show("Dosage Forms\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
            
        }

        private static void HandleDifferentDosageForms(DirectoryService.DosageForm dsDosageForm, DosageForm localDosageForm)
        {
            ABC comp = new ABC();
            comp.LoadQuery(string.Format("Select * from DosageForm WHERE Form = '{0}'", dsDosageForm.Form));

            if (comp.RowCount == 0)
            {
                localDosageForm.AddNew();
                FillDosageFormAttributes(dsDosageForm, localDosageForm);
            }

            else//It is found
            {
                localDosageForm.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                
                FillDosageFormAttributes(dsDosageForm, localDosageForm);
            }
        }

        private static void RefreshSuppliers(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.Supplier> dsSuppliersList = soapClient.GetSuppliers(userName, password, lastVersionNumber, null);
            BLL.Supplier localSupplier = new Supplier();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsSupplier in dsSuppliersList)
            {
                Console.WriteLine(dsSupplier.CompanyName);
                localSupplier.LoadByPrimaryKey(int.Parse(dsSupplier.ID.Value.ToString()));
                if (localSupplier.RowCount > 0)
                {
                    Console.Write(localSupplier.CompanyName);
                    if (dsSupplier.CompanyName.Replace(" ", "") == localSupplier.CompanyName.Replace(" ", ""))
                    {
                        similar++;
                    }

                    else//Needs more consideration
                    {
                        different++;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found!");
                    different++;

                    ABC comp = new ABC();
                    comp.LoadQuery(string.Format("Select * from Supplier WHERE CompanyName = '{0}'", dsSupplier.CompanyName));
                    if (comp.RowCount == 0)
                    {
                        exactNameNotFound++;
                        //ABC similarComp = new ABC();
                        //similarComp.LoadQuery(string.Format("Select * from Supplier WHERE soundex(IIN)=soundex('{0}')", item.Name));
                        //if (similarComp.RowCount == 0)
                        //{
                        notFound++;

                        localSupplier.AddNew();
                        localSupplier.CompanyName = dsSupplier.CompanyName; //What about TypeID and Description
                        if (dsSupplier.Address != null) localSupplier.Address = dsSupplier.Address;
                        if (dsSupplier.Telephone != null) localSupplier.Telephone = dsSupplier.Telephone;
                        if (dsSupplier.ContactPerson != null) localSupplier.ContactPerson = dsSupplier.ContactPerson;
                        if (dsSupplier.Mobile != null) localSupplier.Mobile = dsSupplier.Mobile;
                        if (dsSupplier.CompanyInfo != null) localSupplier.CompanyInfo = dsSupplier.CompanyInfo;
                        if (dsSupplier.IsActive.HasValue) localSupplier.IsActive = dsSupplier.IsActive.Value;
                        if (dsSupplier.Email != null) localSupplier.Email = dsSupplier.Email;
                        localSupplier.Save();
                        //}
                    }

                    else//It is found (No mapping done here though) - Assuming all the tables are similar
                    {
                        //localSupplier.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                        ////Do something here
                        //localSupplier.Save();
                    }
                }
            }
            //XtraMessageBox.Show("Suppliers\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static void RefreshUnits(Service1SoapClient soapClient, int? lastVersionNumber)
        {
            int similar;
            int different;
            int exactNameNotFound;
            int notFound;
            List<DirectoryService.UnitTbl> dsUnitsList = soapClient.GetUnits(userName, password, lastVersionNumber, null);
            BLL.Unit localUnit = new Unit();
            similar = 0; different = 0; exactNameNotFound = 0; notFound = 0;
            foreach (var dsUnit in dsUnitsList)
            {
                Console.WriteLine(dsUnit.Name);
                localUnit.LoadByPrimaryKey(int.Parse(dsUnit.ID.ToString()));
                if (localUnit.RowCount > 0)
                {
                    Console.Write(localUnit.Unit);
                    if (dsUnit.Name.Replace(" ", "") == localUnit.Unit.Replace(" ", ""))
                    {
                        similar++;
                        localUnit.MappingID = dsUnit.ID; //They still need to be mapped.
                        localUnit.Save();
                    }

                    else//Needs to be mapped.
                    {
                        different++;
                        localUnit.MappingID = dsUnit.ID;
                        localUnit.Save();
                        different = HandleDifferentUnits(dsUnit, localUnit, different, exactNameNotFound, notFound);
                    }
                }
                else
                {
                    different = HandleDifferentUnits(dsUnit, localUnit, different, exactNameNotFound, notFound);
                }
            }
            //XtraMessageBox.Show("Units\nSimilar: " + similar + "\nDifferent: " + different + "\nExact Name not found:" + exactNameNotFound + "\nNot Found:" + notFound);
        }

        private static int HandleDifferentUnits(DirectoryService.UnitTbl dsUnit, Unit localUnit, int different, int exactNameNotFound, int notFound)
        {
            Console.WriteLine("Not Found!");
            different++;
            BLL.ABC comp = new ABC();
            comp.LoadQuery(string.Format("Select * from Unit WHERE Unit = '{0}'", dsUnit.Name));
            if (comp.RowCount == 0)
            {
                exactNameNotFound++;
                //ABC similarComp = new ABC();
                //similarComp.LoadQuery(string.Format("Select * from Unit WHERE soundex(IIN)=soundex('{0}')", item.Name));
                //if (similarComp.RowCount == 0)
                //{
                notFound++;

                localUnit.AddNew();
                localUnit.Unit = dsUnit.Name;
                localUnit.MappingID = dsUnit.ID;
                localUnit.Save();
                //}
            }

            else//It is found - Perform Mapping.
            {
                localUnit.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                localUnit.MappingID = dsUnit.ID;
                localUnit.Save();
            }
            return different;
        }


        //private static void RefreshAdminUnits(Service1SoapClient soapClient, int? lastVersionNumber)
        //{
        //    BLL.GeneralInfo gInfo = new GeneralInfo();
        //    if (lastVersionNumber.HasValue)
        //        return;

        //    BLL.Woreda localWoreda = new Woreda();
        //    BLL.Zone localZone = new Zone();
        //    BLL.Region localRegion = new Region();
        //    localWoreda.LoadAll();
        //    localWoreda.DeleteAll();
        //    localWoreda.Save();

        //    localZone.LoadAll();
        //    localZone.DeleteAll();
        //    localZone.Save();

        //    localRegion.LoadAll();
        //    localRegion.DeleteAll();
        //    localRegion.Save();

        //    //List<DirectoryService.Region> dsRegionsList = soapClient.GetRegions(userName, password,null, null);
        //    List<DirectoryService.Region> dsRegionsList = soapClient.GetRegions(userName, password, lastVersionNumber, null);

        //    foreach (var dsRegion in dsRegionsList)
        //    {
        //        string insertQuery =
        //            string.Format(
        //                "SET IDENTITY_INSERT [dbo].[Region] ON INSERT Region(ID,RegionName,RegionCode) Values ({0},'{1}',{2}) SET IDENTITY_INSERT [dbo].[Region] OFF",
        //                dsRegion.ID.Value, dsRegion.RegionName, dsRegion.RegionCode ?? "'NULL'");
        //        ABC queryRunner = new ABC();
        //        queryRunner.LoadQuery(insertQuery);
        //        //localRegion.AddNew();
        //        //localRegion.RegionName = dsRegion.RegionName;
        //        //if(dsRegion.RegionCode!=null) localRegion.RegionCode = dsRegion.RegionCode;
        //        //localRegion.Save();
        //    }

        //    List<DirectoryService.Zone> dsZonesList = soapClient.GetZones(userName, password, lastVersionNumber, null);

        //    foreach (var dsZone in dsZonesList)
        //    {
        //        string insertQuery =
        //            string.Format("SET IDENTITY_INSERT [dbo].[Zone] ON INSERT Zone(ID,ZoneName,ZoneCode,RegionId) Values ({0},'{1}',{2},{3}) SET IDENTITY_INSERT [dbo].[Zone] OFF",
        //                          dsZone.ID.Value, dsZone.ZoneName, dsZone.ZoneCode ?? "'NULL'", dsZone.RegionId.Value);
        //        ABC queryRunner = new ABC();
        //        queryRunner.LoadQuery(insertQuery);

        //        //localZone.AddNew();

        //        //localZone.ID = dsZone.ID.Value;
        //        //localZone.ZoneName = dsZone.ZoneName;
        //        //if (dsZone.RegionId.HasValue) localZone.RegionId = dsZone.RegionId.Value;
        //        //if (dsZone.ZoneCode != null) localZone.ZoneCode = dsZone.ZoneCode;
        //        //localZone.Save();
        //    }

        //    List<DirectoryService.Woreda> dsWoredasList = soapClient.GetWoredas(userName, password, lastVersionNumber, null);

        //    foreach (var dsWoreda in dsWoredasList)
        //    {
        //        string insertQuery =
        //            string.Format("SET IDENTITY_INSERT [dbo].[Woreda] ON INSERT Woreda(ID,WoredaName,WoredaCode,ZoneId) Values ({0},'{1}',{2},{3}) SET IDENTITY_INSERT [dbo].[Woreda] OFF",
        //                          dsWoreda.ID.Value, dsWoreda.WoredaName, dsWoreda.WoredaCode ?? "'NULL'", dsWoreda.ZoneID.Value);
        //        ABC queryRunner = new ABC();
        //        queryRunner.LoadQuery(insertQuery);

        //        //localWoreda.AddNew();
        //        //localWoreda.ID = dsWoreda.ID.Value;
        //        //localWoreda.WoredaName = dsWoreda.WoredaName;
        //        //if (dsWoreda.ZoneID.HasValue) localWoreda.ZoneID = dsWoreda.ZoneID.Value;
        //        //if (dsWoreda.WoredaCode != null) localWoreda.WoredaCode = dsWoreda.WoredaCode;
        //        //localWoreda.Save();
        //    }
        //}

        private static int HandleDifferentItems(int exactNameNotFound, ref int notFound, DirectoryService.Items dsItem, Items localItem)
        {
            BLL.Product product = new Product();
            BLL.DosageForm dosageForm = new DosageForm();

            product.LoadByMappingID(dsItem.IINID.Value);
            
            ABC comp = new ABC();
            if (dsItem.Strength != null && dsItem.DosageFormID != null) //This is a drugItem
            {
                //string query = string.Format("Select * from Items WHERE IINID = {0} and DosageFormID={1} and Strength='{2}'",
                //                  dsItem.IINID, dsItem.DosageFormID, dsItem.Strength.Replace("'", "''"));
                dosageForm.LoadByMappingID(dsItem.DosageFormID.Value);
                string query = string.Format("Select * from Items WHERE IINID = {0} and DosageFormID={1} and Strength='{2}'",
                                  product.ID, dosageForm.ID, dsItem.Strength.Replace("'", "''"));
                comp.LoadQuery(query);
            }
            else
            {
                if (dsItem.DosageFormID.HasValue)
                    dosageForm.LoadByMappingID(dsItem.DosageFormID.Value);

                string dosageFormParam = dsItem.DosageFormID.HasValue ? string.Format(" and DosageFormID={0} ", dosageForm.ID) : "";
                string strengthParam = !string.IsNullOrEmpty(dsItem.Strength) ? string.Format(" and Strength='{0}' ", dsItem.Strength.Replace("'", "''")) : "";
                //comp.LoadQuery(string.Format("Select * from Items WHERE IINID = {0} {1}{2}", dsItem.IINID, dosageFormParam, strengthParam));
                comp.LoadQuery(string.Format("Select * from Items WHERE IINID = {0} {1}{2}", product.ID, dosageFormParam,
                                             strengthParam));


            }

            if (comp.RowCount == 0)
            {
                exactNameNotFound++;
                //ABC similarComp = new ABC();
                //similarComp.LoadQuery(string.Format("Select * from Item WHERE soundex(IIN)=soundex('{0}')", item.Name));
                //if (similarComp.RowCount == 0)
                //{
                notFound++;

                localItem.AddNew();
                FillItemAttributes(dsItem, ref localItem);
                //}
            }

            else//It is found
            {
                localItem.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                //localItem.Code = dsItem.ID.Value.ToString();
                //localItem.Save();
                if (localItem.IsMapped && localItem.MappingID == dsItem.ID)
                {
                    FillItemAttributes(dsItem, ref localItem);
                }

                else if (localItem.IsMapped && localItem.MappingID != dsItem.ID)
                {
                    BLL.Items newlocalItem = new Items();
                    newlocalItem.AddNew();
                    FillItemAttributes(dsItem, ref newlocalItem);
                }

                else //Not mapped
                {
                    FillItemAttributes(dsItem, ref localItem);
                }
            }
            return exactNameNotFound;
        }

        /// <summary>
        /// When using the function, the localItem should have already been loaded
        /// </summary>
        /// <param name="dsItem"></param>
        /// <param name="localItem"></param>
        private static void FillItemAttributes(DirectoryService.Items dsItem, ref Items localItem)
        {
            if (dsItem.StockCode != null) localItem.StockCode = dsItem.StockCode;
            if (dsItem.Strength != null) localItem.Strength = dsItem.Strength;

            
            if (dsItem.DosageFormID.HasValue)
            {
                BLL.DosageForm dosageForm = new DosageForm();
                if (dosageForm.LoadByMappingID(dsItem.DosageFormID.Value) != -1)
                    localItem.DosageFormID = dosageForm.ID; //dsItem.DosageFormID.Value;
            }

            BLL.Unit unit = new Unit();
            if (unit.LoadByMappingID(dsItem.UnitID.Value) != -1) localItem.UnitID = unit.ID; //We put the ID of the mapped unit

            if (dsItem.VEN.HasValue && dsItem.VEN.Value != 0) localItem.VEN = dsItem.VEN.Value;
            if (dsItem.ABC.HasValue && dsItem.ABC.Value != 0) localItem.ABC = dsItem.ABC.Value;
            if (dsItem.IsDeleted.HasValue) localItem.IsDiscontinued = dsItem.IsDeleted.Value;
            if (dsItem.QtyPerPack.HasValue) localItem.Cost = dsItem.QtyPerPack.Value.ToString(); //We are using the Cost Column to store the Preferred Qty Per Pack for the item.
            if (dsItem.EDL.HasValue) localItem.EDL = dsItem.EDL.Value;
            if (dsItem.Pediatric.HasValue) localItem.Pediatric = dsItem.Pediatric.Value;
            //localItem.IsFree = true;
            //localItem.Refrigeratored = false;

            BLL.Product product = new Product();

            if (product.LoadByMappingID(dsItem.IINID.Value) != -1) localItem.IINID = product.ID;//We put the ID of the mapped product

            if (dsItem.NeedExpiryBatch.HasValue) localItem.NeedExpiryBatch = dsItem.NeedExpiryBatch.Value;
            if (dsItem.StockCodeDACA != null) localItem.StockCodeDACA = dsItem.StockCodeDACA;
            if (dsItem.NearExpiryTrigger.HasValue) localItem.NearExpiryTrigger = dsItem.NearExpiryTrigger.Value;
            //if (dsItem.StorageTypeID.HasValue) localItem.StorageTypeID = dsItem.StorageTypeID.Value;
            if (localItem.IsColumnNull("IsInHospitalList")) 
                localItem.IsInHospitalList = false; 
            else 
                localItem.IsInHospitalList = localItem.IsInHospitalList;

            localItem.Code = dsItem.ID.Value.ToString(); //Mapping done here.
            localItem.Save();
        }

        private static int HandleDifferentProducts(int exactNameNotFound, ref int notFound, DirectoryService.Product dsProduct, Product localProduct)
        {

            ABC comp = new ABC();
            string prodName = "";
            if (string.IsNullOrEmpty(dsProduct.Name))
                prodName = "";
            else
                prodName = dsProduct.Name.Replace("'", "''");
            comp.LoadQuery(string.Format("Select * from Product WHERE IIN = '{0}' and TypeID={1}",dsProduct.ID, dsProduct.TypeID));
            if (comp.RowCount == 0)
            {
                exactNameNotFound++;
                //ABC similarComp = new ABC();
                //similarComp.LoadQuery(string.Format("Select * from Product WHERE soundex(IIN)=soundex('{0}')", item.Name));
                //if (similarComp.RowCount == 0)
                //{
                notFound++;

                localProduct.AddNew();
                FillProductAttributes(dsProduct, localProduct);
                //}
            }

            else//It is found
            {
                localProduct.LoadByPrimaryKey(int.Parse(comp.GetColumn("ID").ToString()));
                //if (dsProduct.ID.HasValue) localProduct.ATC = dsProduct.ID.Value.ToString();
                //localProduct.Save();
                FillProductAttributes(dsProduct, localProduct);
            }
            return exactNameNotFound;

        }

        /// <summary>
        /// When using the function, the localProduct should have already been loaded.
        /// </summary>
        /// <param name="dsProduct"></param>
        /// <param name="localProduct"></param>
        private static void FillProductAttributes(DirectoryService.Product dsProduct, Product localProduct)
        {
            localProduct.IIN = dsProduct.Name;
            if (dsProduct.TypeID.HasValue)
            {
                localProduct.TypeID = int.Parse(dsProduct.TypeID.Value.ToString());
            }
            if (dsProduct.ID.HasValue) localProduct.ATC = dsProduct.ID.Value.ToString();
            localProduct.Save();
        }

        //-----------------------------------------------------------------------------------------------------------------------
        public static void SaveItemList(List<PharmInventory.DirectoryService.Items> list)
        {
            bool isNew = false;
            BLL.Items bv = new BLL.Items();
            foreach (PharmInventory.DirectoryService.Items v in list)
            {
                // try to load by primary key
                bv.LoadByPrimaryKey(v.ID.Value);

                // if the entry doesn't exist, create it
                if (bv.RowCount == 0)
                {
                    isNew = true;
                    bv.AddNew();
                    bv.IsFree = true;
                }
                // populate the contents of v on the to the database list
                if (v.ID.HasValue)
                    bv.ID = v.ID.Value;
                if (v.StockCode != "" && v.StockCode != null)
                    bv.StockCode = v.StockCode;

                if (v.Strength != "" && v.Strength != null)
                    bv.Strength = v.Strength;

                if (v.DosageFormID.HasValue)
                    bv.DosageFormID = v.DosageFormID.Value;
                if (v.UnitID.HasValue)
                    bv.UnitID = v.UnitID.Value;

                if (v.VEN.HasValue)
                    bv.VEN = v.VEN.Value;
                else
                    bv.VEN = 1;

                if (v.ABC.HasValue)
                    bv.ABC = v.ABC.Value;
                else
                    bv.ABC = 1;
                if (v.QtyPerPack.HasValue)
                    bv.Cost = v.QtyPerPack.Value.ToString();
                if (v.EDL.HasValue)
                    bv.EDL = v.EDL.Value;
                if (v.Pediatric.HasValue)
                    bv.Pediatric = v.Pediatric.Value;

                BLL.Product product = new Product();
                product.LoadByMappingID(v.IINID.Value);

                if (v.IINID.HasValue)
                    bv.IINID = product.ID; //v.IINID.Value;
                if (v.NeedExpiryBatch.HasValue)
                {
                    bv.NeedExpiryBatch = v.NeedExpiryBatch.Value;
                }
                else
                {
                    bv.NeedExpiryBatch = false;
                }

                if (v.Code != "" && v.Code != null)
                    bv.Code = v.Code;

                if (v.StockCodeDACA != "" && v.StockCodeDACA != null)
                    bv.StockCodeDACA = v.StockCodeDACA;

                if (v.NearExpiryTrigger.HasValue)
                    bv.NearExpiryTrigger = v.NearExpiryTrigger.Value;
                if (v.StorageTypeID.HasValue && isNew)
                    bv.StorageTypeID = v.StorageTypeID.Value;

                bv.Save();
            }


        }
    }
}
