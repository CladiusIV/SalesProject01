using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Contable0._2
{
    public partial class LoginForm : Form
    {
        SQLiteConnection contableDB;
        string pathDB = Directory.GetCurrentDirectory();
        string fileDB = "\\ListaPrecios.db";

        public LoginForm()
        {
            InitializeComponent();
        }        
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.AcceptButton = this.button1;
            contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
            contableDB.Open();
            string sql = "SELECT COUNT(*) FROM Usuarios WHERE Usuario LIKE ('" + this.textBox1.Text + "') AND Clave LIKE ('" + this.textBox2.Text + "')";
            SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
                        
            int count = Convert.ToInt32(cmd.ExecuteScalar());
                        
            if (count == 1)
            {
                string sql2 = "UPDATE UsuarioOn SET Usuario = '" + this.textBox1.Text + "'";                
                SQLiteCommand cmd2 = new SQLiteCommand(sql2, contableDB);
                cmd2.ExecuteNonQuery();
                DialogResult = DialogResult.OK; //On button click enter the mainform.
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta!","Error", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
            contableDB.Close();            
        }

    }
}
