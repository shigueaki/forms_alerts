using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAlert
{
    public static class FormsHelper
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// O método ativa o formulário sem que ele tenha foco, e ele permanece sobrepondo as outras telas
        /// </summary>
        /// <param name="f">Formulário atual</param>
        public static void ShowTopmostNoFocus(Form f)
        {
            IntPtr activeWin = GetForegroundWindow();

            f.Show();
            f.BringToFront();
            f.TopMost = true;

            if (activeWin.ToInt32() > 0)
            {
                SetForegroundWindow(activeWin);
            }
        }
    }
}
