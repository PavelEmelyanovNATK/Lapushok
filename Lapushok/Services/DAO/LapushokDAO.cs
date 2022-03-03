using Lapushok.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lapushok.Services.DAO
{
    class LapushokDAO
    {
        private static LapushokDBEntities _dao;

        public static LapushokDBEntities Context
        {
            get
            {
                if (_dao is null)
                    Refresh();

                return _dao;
            }
        }

        public static void Refresh()
        {
            _dao = new LapushokDBEntities();
        }
    }
}
