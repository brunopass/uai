using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class Session
    {
        public static string _id;
        public delegate void delSession (bool isLogged);
        public static event delSession sessionListener;

        public static void join(string id)
        {
            _id = id;
            sessionListener(true);
        }

        public static void logout()
        {
            _id = null;
            sessionListener(false);
        }

    }
}
