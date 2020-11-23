using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Logs
    {
        public void createLog(string description)
        {
            try
            {
                Data.Logs logs = new Data.Logs();
                logs.newLog(description);
            }catch
            {
               
            }
        }
    }
}
