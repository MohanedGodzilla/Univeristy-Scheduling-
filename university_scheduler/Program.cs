using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using university_scheduler.Model;

namespace university_scheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                List<Reservation> reservationsList = Reservation.getAll();
                if (reservationsList.Count > 0)
                    Application.Run(new HomeScreenWithTable());
                else
                    Application.Run(new NoScheduleHome());
            } catch (Exception ex) {
                
            }
        }
    }
}
