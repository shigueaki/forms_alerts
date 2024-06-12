using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAlert
{
    public static class Global
    {
        public static List<string> allFormsOpen = [];

        public static List<Tuple<string, FrmAlert.EnmType>> allNotifications = [];

        private static TimerCheckNotifications timer = new();
    }
}
