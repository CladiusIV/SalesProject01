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
    public partial class frmInv : Form
    {
        public frmInv()
        {
            InitializeComponent();
        }
        SQLiteConnection contableDB;
        string pathDB = Directory.GetCurrentDirectory();
        string fileDB = "\\ListaPrecios.db";
        

        private void button2_Click(object sender, EventArgs e) //Boton cancelar
        {
            this.Hide();
            this.comboBox2.Text = "";
            this.textBox1.Text = "";
            this.comboBox1.Text = "1";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.label6.Text = "";
            this.label7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) //Boton aceptar
        {
            this.AcceptButton = this.button1;
            if (!string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {                       
                        contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
                        contableDB.Open();

                        string sql = "INSERT INTO Inventario (Producto, Marca, Cantidad, PrecioC, PrecioU, PrecioTC, PrecioTV, Usuario) VALUES('" + comboBox2.Text + "', '" + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','0','0',(SELECT Usuario FROM UsuarioON))";
                        SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
                        cmd.ExecuteNonQuery();
                        contableDB.Close();

                        this.Hide();
                        this.label7.Text = "";
                        this.label6.Text = "";
                        this.label5.Text = "";
                        this.comboBox2.Text = "";                        
                        this.comboBox1.Text = "1";
                        this.textBox1.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("El campo del precio de venta esta vacio!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.label6.Text = "";
                        this.label7.Text = "*";
                    }
                }
                else
                {
                    MessageBox.Show("El campo del precio de costo esta vacio!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.label5.Text = "";
                    this.label6.Text = "*";
                }
            }
            else
            {
                MessageBox.Show("El campo del producto esta vacio!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label5.Text = "*";
            }
        }
    }
}
