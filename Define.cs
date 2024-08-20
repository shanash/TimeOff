using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TimeOff
{
    internal class Define
    {
        public static readonly string Version = "0.9.0";
        public static readonly TimeSpan WorkingTime = new TimeSpan(7, 30, 0);
        public static readonly TimeSpan LunchTime = new TimeSpan(1, 0, 0);
        public static readonly TimeSpan DinnerTime = new TimeSpan(1, 0, 0);
        public static readonly TimeSpan LeaveEarlyTime = new TimeSpan(3, 45, 0);
    }
}
