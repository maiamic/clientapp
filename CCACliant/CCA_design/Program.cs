using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCA_design
{
    internal static class Program
    {
        public static TcpClient client { get; set; }
        public static NetworkStream stream { get; set; }
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            Application.Run(new WelcomForm());
        }
    }
}
