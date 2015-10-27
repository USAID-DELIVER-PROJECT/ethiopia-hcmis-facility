using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.DAL;
using PharmInventory.ViewModels;

namespace PharmInventory.HelperClasses
{
    class CalculateAMC
    {
        private Boolean IsCalculatedToday()
        {
            AmcReportRepository _amcReportRepository = new AmcReportRepository();
            int count = _amcReportRepository.AllAmcReport().Where(amc => amc.LastIndexedTime.Value.Date == DateTime.Today.Date).Select(amc => amc.ID).Count();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BuildAMC(bool forceCalc = false)
        {
            if ((IsCalculatedToday()) && (forceCalc == false))
            {
                return;
            }

            StockoutRepository _repository = new StockoutRepository();
            StoreRepository _storerepository = new StoreRepository();
            GeneralInfoRepository _generalInfoRepository = new GeneralInfoRepository();
            ReceiveDocRepository _receiveDocRepository = new ReceiveDocRepository();
            AmcReportRepository _amcReportRepository = new AmcReportRepository();
            List<AMCViewModel> _datasource; 

            //clear AMC table before another build
            _amcReportRepository.DeleteAll();

            var generalinfo = _generalInfoRepository.AllGeneralInfos().First();
            var storeList = _storerepository.AllStores();
            foreach (var store in storeList)
            {
                var storeId = store.ID;
                var itemsrecieved = _receiveDocRepository.RecievedItems().Where(m => m.StoreID == storeId).Select(m => m.ItemID).Distinct();

                _datasource = new List<AMCViewModel>();
                var receiveDocs = _repository.AllItems().Where(m => itemsrecieved.Contains(m.ID)).ToList();
                double increment = 80.0 / Convert.ToDouble(receiveDocs.Count());

                IEnumerable<int?> unitid;
                if (VisibilitySetting.HandleUnits != 1)
                {
                    foreach (var item in receiveDocs)
                    {
                        unitid = _receiveDocRepository.RecievedItems().Where(m => m.ItemID == item.ID && m.StoreID == storeId).Select(m => m.UnitID).Distinct();
                        foreach (var i in unitid)
                        {
                            AMCViewModel.OptimizedCreate(item.ID, item.FullItemName, storeId, i.GetValueOrDefault(), generalinfo.AMCRange, DateTime.Today);
                        }
                    }
                }
                else
                {
                    foreach (var item in receiveDocs)
                    {
                        AMCViewModel.OptimizedCreate(item.ID, item.FullItemName, storeId, generalinfo.AMCRange, DateTime.Today);
                    }
                }
            }
        }
    }
}
