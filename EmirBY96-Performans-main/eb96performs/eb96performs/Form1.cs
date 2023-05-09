using System.Data;
using System.Data.SQLite;
using System.Numerics;

namespace eb96performs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void listele()
        {
            SQLiteConnection baglanti =
                new SQLiteConnection
                ("Data Source=E:\\Projelerim\\otopark.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter da =
                new SQLiteDataAdapter("SELECT * FROM otopark", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "otopark");
            dataGridView1.DataSource = ds.Tables["otopark"];
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plaka = textBox1.Text;
            string giris = textBox2.Text;
            string cikis = textBox3.Text;
            string fiyat = textBox4.Text;
            SQLiteConnection baglanti =
                new SQLiteConnection
                ("Data Source=E:\\Projelerim\\otopark.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO  otopark values('" + plaka + "','" + giris + "','" + cikis + "','" + fiyat + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string plaka = textBox1.Text;
            SQLiteConnection baglanti =
                new SQLiteConnection
                ("Data Source=E:\\Projelerim\\otopark.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM otopark WHERE plaka='" + plaka + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string plaka = textBox1.Text;
            string giris = textBox2.Text;
            string cikis = textBox3.Text;
            string fiyat = textBox4.Text;
            SQLiteConnection baglanti =
                new SQLiteConnection
                ("Data Source=E:\\Projelerim\\otopark.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText = "update otopark set fiyat='" + textBox4.Text + "',cikis='" + textBox3.Text + "',plaka='" + textBox1.Text + "',giris='" + textBox2.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}