using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contable0._2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult resultado; //Call the login form
            using (var loginForm = new LoginForm())
                resultado = loginForm.ShowDialog();
            if (resultado == DialogResult.OK)
            {            
                Application.Run(new MainForm()); //Login Successful
            }
        }
    }
}
