using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace UP2
{
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection = null;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Malina"].ConnectionString);
            sqlConnection.Open(); //открыли подключение к бд

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection.Open();
            var id_читательского_билета = textBox6.Text;
            var ФИО_Читателя = textBox1.Text;
            var Номер_телефона = textBox2.Text;
            var Дата_рождения = textBox3.Text;
            var Логин = textBox4.Text;
            var Пароль = textBox5.Text;


            SqlCommand command = new SqlCommand(
               $"INSERT INTO [Читатели] ( id_читательского_билета, ФИО_Читателя, Номер_телефона, Дата_рождения,login,password) VALUES (@id_читательского_билета,@ФИО_Читателя, @Номер_телефона, @Дата_рождения, @login, @password)", sqlConnection);

            DateTime date = DateTime.Parse(textBox3.Text);
            command.Parameters.AddWithValue("id_читательского_билета", textBox6.Text);
            command.Parameters.AddWithValue("ФИО_Читателя", textBox1.Text);
            command.Parameters.AddWithValue("Номер_телефона", textBox2.Text);
            command.Parameters.AddWithValue("Дата_рождения", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("login", textBox4.Text);
            command.Parameters.AddWithValue("password", textBox5.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана!", "Успех");


            sqlConnection.Close();
            this.Close();

            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Show();


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) //  строчные буквы  разрешены
                return;
            if ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')) //  прописные буквы разрешены
                return;
            if (e.KeyChar == (char)Keys.Space) // пробел разрешён
                return;
            if (e.KeyChar == (char)Keys.Back)  // BackSpase разрешён
                return;
            e.KeyChar = '\0';	// остальные символы запрещены (игнорировать)
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "(*.jpg)|*.jpg";
            openFileDialog1.Filter = "Image Files (*.JPG; *.PNG|*.JPG; *.PNG|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    pictureBox2.Image = new Bitmap(openFileDialog1.FileName);


                    File.Copy(openFileDialog1.FileName, Path.Combine(@"E:\UP2\photo", Path.GetFileName(openFileDialog1.FileName)), true);


                    MessageBox.Show("Изображение успешно загружено в папку photo!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Произошла ошибка: Изображение не может быть загружено", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

