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


namespace filmArsiv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "Server =localhost; Database=film_arsiv;Uid = root; Pwd='';";

        void VeriGetir()
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();
                string sorgu = "SELECT * FROM filmler";
                MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable tablo = new DataTable();

                adapter.Fill(tablo);

                dgvFilmler.DataSource = tablo;
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormElestiriler formElestiriler= new FormElestiriler();
            formElestiriler.ShowDialog();
        }
    }
}
