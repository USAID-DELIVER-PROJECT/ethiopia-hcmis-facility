using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
    public class GeneralInfoRepository
    {
        private StockoutEntities Context = new StockoutEntities();

        public List<GeneralInfo> AllGeneralInfos()
        {
            return Context.GenralInfos.ToList();
        }
    }
}
