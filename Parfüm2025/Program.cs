using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parfüm2025
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         // Application.Run(new frmpafümAnsicht());
       
           //Application.Run(new frmMitarbeiterListe());
       
            Application.Run(new frmLogginScreen());
            // Application.Run(new frmKundeListe());
            //Application.Run(new frmMainScreen());
            //Application.Run(new frmUserListe());
           //Application.Run(new frmEinkaufsDatenListe());
           //Application.Run(new frmVerkaufsDatenListe());
           //Application.Run(new frmDruckvorschau());
            //Application.Run(new frmLizenzEigabeBildschirm());
        }
    }
}
