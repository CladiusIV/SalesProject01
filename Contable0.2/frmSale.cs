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
    public partial class frmSale : Form
    {
        
        public frmSale()
        {
            InitializeComponent();
            contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
            contableDB.Open();

            string sql = "SELECT * FROM Inventario";
            SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
            SQLiteDataReader read = cmd.ExecuteReader();
            while (read.Read()) //Lee y carga en lista los productos. TODO: cargarlo en vector teniendo en cuenta el cod prod.
            {
                comboBox2.Items.Add((string)read["Producto"]);
            }

            contableDB.Close();
        }

        SQLiteConnection contableDB;
        string pathDB = Directory.GetCurrentDirectory();
        string fileDB = "\\ListaPrecios.db";

        private void button1_Click(object sender, EventArgs e) //Boton Aceptar
        {
            this.AcceptButton = this.button1;
            if (!string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
                    contableDB.Open();

                    string sql = "INSERT INTO CajaDiaria (Producto, Marca, Cantidad, Precio, Usuario) VALUES ('" + comboBox2.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "',(SELECT Usuario FROM UsuarioON))";
                    SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
                    cmd.ExecuteNonQuery();

                    //string sql2 = "INSERT INTO CajaDiaria (Usuario) Values ()"; 
                    //TODO: restar la cantidad vendida con la cant del inventario mediante vector, teniendo en cuenta cod prod.

                    contableDB.Close();                    
                    
                    this.Hide();
                    comboBox2.Text = "";
                    textBox1.Text = "";
                    comboBox1.Text = "1";
                    textBox2.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                }
                else
                {
                    MessageBox.Show("El campo del precio esta vacio!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label5.Text = "";
                    label6.Text = "*";
                }
            }
            else
            {
                MessageBox.Show("El campo del producto esta vacio!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label5.Text = "*";
            }
        }
        
        private void button2_Click(object sender, EventArgs e) // Boton Cancelar
        {
            this.Hide();
            comboBox2.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "1";
            textBox2.Text = "";
            label5.Text = "";
            label6.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //Cuando cambia el valor del cbox insertar los valores de la linea en los txtbox..
        {
            //TODO: llenar los campos con datos del vector, teniendo en cuenta el cod prod.
            //comboBox2.SelectedIndex = comboBox2.Items.IndexOf(comboBox2);
        }

        
    }
}
