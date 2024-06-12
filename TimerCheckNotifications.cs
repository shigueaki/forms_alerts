using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace WinformsAlert
{
    public class TimerCheckNotifications
    {
        readonly FrmAlert frmAlert = new();
        public static Timer timer = new()
        {
            Enabled = true,
            Interval = 50,
        };

        public TimerCheckNotifications()
        {
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Global.allFormsOpen.Count < 5 && Global.allNotifications.Count > 0)
            {
                frmAlert.Alert(Global.allNotifications[0].Item1, Global.allNotifications[0].Item2);
                Global.allNotifications.Remove(Global.allNotifications[0]);
            }
        }
    }
}
