using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace pruebaMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            MetodosSQL obj = new MetodosSQL();
            obj.nuevaTarifaCliente(2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 1.53, 1.87, 1.0,0,0,0,0,0,0,0,0);
            MessageBox.Show("Hecho");
         }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
