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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        SQLiteConnection contableDB;
        string pathDB = Directory.GetCurrentDirectory();
        string fileDB = "\\ListaPrecios.db";

        private void button1_Click(object sender, EventArgs e) //Boton aceptar
        {
            this.AcceptButton = this.button1;
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
                    contableDB.Open();

                    string sql = "UPDATE Usuarios SET Nombre = '" + textBox1.Text + "', SET Apellido= '" + textBox2.Text + "', SET Clave = '" + textBox4.Text + "'";
                    SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
                    cmd.ExecuteNonQuery();
                    contableDB.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Boton cancelar
        {
            this.Hide();            
            this.textBox1.Text = "";            
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.label5.Text = "";
            this.label7.Text = "";
        }

        
    }
}
