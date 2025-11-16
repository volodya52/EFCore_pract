using EFCorePract.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePract.Service
{
    public class BaseDBService
    {
        private BaseDBService()
        {
            context = new AppDbContext();
        }

        private static BaseDBService? instance;
        
        public static BaseDBService Instance
        {
            get
            {
                if(instance == null)
                    instance = new BaseDBService();
                return instance;
            }
        }

        private AppDbContext context;
        public AppDbContext Context => context;
    }
}
