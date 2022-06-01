using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerOffice
{
    class Program
    {
        public static Thread KeyboardReader = null;
        public static Thread Loader = null;
        //public static EMode emode

        public enum EMode
        {
            criticalCrash,
            starting,
            setup,
            
        }
        static void Main(string[] args)
        {
        }
    }
}
