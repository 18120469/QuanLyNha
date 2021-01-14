using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNha
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChuNha("2"));
            //Application.Run(new NhanVien("1"));
            //Application.Run(new admin("1"));
            //Application.Run(new KhachHang("1"));
        }
    }

    
}
