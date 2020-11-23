using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data
{
    public class Logs
    {
        public void newLog(String description)
        {
            using(RoomyEntities roomy = new RoomyEntities())
            {
                Log log = new Log();
                log.id = Guid.NewGuid().ToString();
                log.time = new TimeSpan();
                log.description = description;
                roomy.Log.Add(log);
                roomy.SaveChanges();
            }
        }
    }
}
