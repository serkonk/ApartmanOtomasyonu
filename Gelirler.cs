using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartamanOtomasyonu
{
    public partial class Gelirler : Form
    {
        public Gelirler()
        {
            InitializeComponent();
        }
        SqlHelper seko = new SqlHelper();

        private void button1_Click(object sender, EventArgs e)
        {
            int daireno =  Convert.ToInt32(comboBox1.Text);
            int para = (int) numericUpDown1.Value;
            DateTime yeni = dateTimePicker1.Value;

            SqlParameter p1 = new SqlParameter("Daireno",daireno);
            SqlParameter p2 = new SqlParameter("Para", para);
            SqlParameter p3 = new SqlParameter("Tarih", yeni);

            seko.ExecuteProc("aidat",p1,p2,p3);

        }

        private void Gelirler_Load(object sender, EventArgs e)
        {
            DataTable serkan = seko.GetTable("select*from [Aidat Ödemesi]");
            foreach (DataRow liste in serkan.Rows)
            {
                listBox1.Items.Add(liste["Daireno"]).ToString();
                listBox2.Items.Add(liste["Para"]).ToString();
                listBox3.Items.Add(liste["Tarih"]).ToString();
            }
        }
    }
}
