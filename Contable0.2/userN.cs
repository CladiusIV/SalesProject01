using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Contable0._2
{
    class userN : frmUser
    {
        SQLiteConnection contableDB;
        string pathDB = Directory.GetCurrentDirectory();
        string fileDB = "\\ListaPrecios.db";

        public void dataUsuarios()
        {
            contableDB = new SQLiteConnection("Data Source=" + pathDB + fileDB + ";");
            contableDB.Open();

            string sql = "SELECT * FROM UsuarioOn";            
            SQLiteCommand cmd = new SQLiteCommand(sql, contableDB);
            SQLiteDataReader read = cmd.ExecuteReader();


            while (read.Read())
            {
                textBox3.Text = (read["Usuario"].ToString());

            }

            string sql2 = "SELECT * FROM Usuarios WHERE Usuario = '" + textBox3.Text + "'";
            
            SQLiteCommand cmd2 = new SQLiteCommand(sql2, contableDB);
            SQLiteDataReader read2 = cmd2.ExecuteReader();
            while (read2.Read())
            {
                textBox1.Text = (read2["Nombre"].ToString());
                textBox2.Text = (read2["Apellido"].ToString());
                textBox3.Text = (read2["Usuario"].ToString());
                textBox4.Text = (read2["Clave"].ToString());
                textBox6.Text = (read2["Fecha"].ToString());
            }

            contableDB.Close();
        }
    }
}
