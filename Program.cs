using System;
using System.Windows.Forms;
using LifeFlowBBMS.UI;

namespace LifeFlowBBMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}