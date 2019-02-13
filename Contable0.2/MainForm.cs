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
    public partial class MainForm : Form
    {
        frmSale frmVenta = new frmSale();
        frmInv frmInventario = new frmInv();
        frmUser frmUsuario = new frmUser();
        userN usuarios = new userN();

        SQLiteConnection contableDB;
        string pathDB = Directory.GetCurrentDirectory();
        string fileDB = "\\ListaPrecios.db";

        public MainForm()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            
        }        
                
        private void button1_Click(object sender, EventArgs e) // Boton registrar venta..
        {
            frmVenta.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Mostrar lista
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
            contableDB.Open();

            string sql = "SELECT * FROM Cajadiaria ORDER BY Id DESC LIMIT 30";
            SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
            SQLiteDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("Id")),
                    read.GetValue(read.GetOrdinal("Producto")),
                    read.GetValue(read.GetOrdinal("Marca")),
                    read.GetValue(read.GetOrdinal("Cantidad")),
                    read.GetValue(read.GetOrdinal("Precio")),
                    read.GetValue(read.GetOrdinal("Fecha")),
                    read.GetValue(read.GetOrdinal("Usuario")),
                });
            }
            contableDB.Close();
        }

        private void button3_Click(object sender, EventArgs e) // Boton limpiar
        {
            //TODO: convertirlo en "completar venta" y mediante un acumulador hacer la suma de la venta de un cliente.
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este programa fue creado por Claudio Lopez\nContacto: Claudiolopez04@hotmail.com\nTel: 3512794093 (Argentina)", "Info", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e) // Boton buscar.
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
            contableDB.Open();

            //string sql = "SELECT * FROM CajaDiaria WHERE '" + this.comboBox1.SelectedItem.ToString() + "' LIKE '%" + this.textBox1.Text + "%' ORDER BY Id DESC"; //Revisar
            string sql = "SELECT * FROM CajaDiaria WHERE Producto LIKE '%" + this.textBox1.Text + "%' ORDER BY Id DESC"; //Funciona, con dato estatico sin el combobos.
            SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
            SQLiteDataReader read = cmd.ExecuteReader();

            //MessageBox.Show(sql.ToString());
            //MessageBox.Show(comboBox1.Text);

            while (read.Read())
            {
                dataGridView1.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("Id")),
                    read.GetValue(read.GetOrdinal("Producto")),
                    read.GetValue(read.GetOrdinal("Marca")),
                    read.GetValue(read.GetOrdinal("Cantidad")),
                    read.GetValue(read.GetOrdinal("Precio")),
                    read.GetValue(read.GetOrdinal("Fecha")),
                    read.GetValue(read.GetOrdinal("Usuario")),
                });
            }
            contableDB.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmInventario.Show();
        }

        private void button6_Click(object sender, EventArgs e) //Mostrar lista inventario
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
            contableDB.Open();

            string sql = "SELECT * FROM Inventario ORDER BY Producto";
            SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
            SQLiteDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                dataGridView2.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("Cod")),
                    read.GetValue(read.GetOrdinal("Producto")),
                    read.GetValue(read.GetOrdinal("Marca")),
                    read.GetValue(read.GetOrdinal("Cantidad")),
                    read.GetValue(read.GetOrdinal("PrecioC")),
                    read.GetValue(read.GetOrdinal("PrecioU")),
                    read.GetValue(read.GetOrdinal("PrecioTC")),
                    read.GetValue(read.GetOrdinal("PrecioTV")),
                    read.GetValue(read.GetOrdinal("Fecha")),
                    read.GetValue(read.GetOrdinal("Usuario")),
                });
            }
            contableDB.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                        
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) //Opciones usuario
        {
            frmUsuario.Show();            
            usuarios.dataUsuarios();
        }
    }
}
