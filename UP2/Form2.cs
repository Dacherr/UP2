using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace UP2
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection = null;
        bool See = true;
        private int _countTries = 0;

        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.MaxLength = 50;
            textBox2.UseSystemPasswordChar = true;
            panel1.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Malina"].ConnectionString);
            sqlConnection.Open();
            string login = textBox1.Text;
            string password = textBox2.Text;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string queryClient = $" SELECT * FROM Читатели WHERE login = '{login}' and password = '{password}';";

            SqlCommand command = new SqlCommand(queryClient, sqlConnection);

            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(Table);

            bool успешныйВход = Table.Rows.Count == 1;

            // Запись в историю входа
            ЗаписатьИсториюВхода(login, успешныйВход);

            if (успешныйВход)
            {
                string userFullName = Table.Rows[0]["ФИО_читателя"].ToString();
                MessageBox.Show($"Вы успешно зашли, {userFullName}", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form5 form5 = new Form5();
                this.Hide();
                form5.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Неверно введен пароль", "Ошибка входа");
                textBox1.Text = "";
                textBox2.Text = "";
                _countTries++;
                panel1.Visible = true;
            }


        }
        private void ЗаписатьИсториюВхода(string login, bool успешныйВход)
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                string query = "INSERT INTO LoginHistory  (TimeStamp, Username, Success) VALUES (@Время, @Логин, @УспешныйВход)";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Время", DateTime.Now.TimeOfDay);
                    sqlCommand.Parameters.AddWithValue("@Логин", login);
                    sqlCommand.Parameters.AddWithValue("@УспешныйВход", успешныйВход);

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (See)
                button2.BackgroundImage = new Bitmap(Properties.Resources.Глаз2);
            else

                button2.BackgroundImage = new Bitmap(Properties.Resources.Глаз1);
            See = !See;
            textBox2.UseSystemPasswordChar = See;

        }

        private Bitmap drawImage(string txt, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush solid = new SolidBrush(Color.White);
            g.FillRectangle(solid, 0, 0, bmp.Width, bmp.Height);
            Font font = new Font("MS Reference Sans Serif", 30);
            solid = new SolidBrush(Color.Blue);
            g.DrawString(txt, font, solid, bmp.Width / 2 - (txt.Length / 2) * font.Size,
                (bmp.Height / 2) - font.Size);

            int count = 0;
            Random rd = new Random();
            while (count < 1000)
            {
                solid = new SolidBrush(Color.YellowGreen);
                g.FillEllipse(solid, rd.Next(0, bmp.Width), rd.Next(0, bmp.Height), 4, 2);
                count++;
            }
            count = 0;
            while (count < 25)
            {
                g.DrawLine(new Pen(Color.Pink), rd.Next(0, bmp.Width), rd.Next(0, bmp.Height),
                    rd.Next(0, bmp.Width), rd.Next(0, bmp.Height));
                count++;
            }
            return bmp;
        }

        private string captchText;

     

        public String randString()
        {
            Random rd = new Random();
            int num = rd.Next(10000, 99999);
            string text = md5(num.ToString());
            text = text.ToUpper();
            text = text.Substring(0, 6);
            return text;
        }
        private void Reset()
        {
            captchText = this.randString();
            textBox3.Text = "";
            pictureBox1.BackgroundImage = drawImage(captchText, pictureBox1.Width, pictureBox1.Height);
        }

        public static string md5(String data)
        {
            return BitConverter.ToString(encryptData(data)).Replace(" — ", "").ToLower();
        }

        public static byte[] encryptData(String data)
        {
            MD5CryptoServiceProvider mD5Crypto = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding utf8 = new UTF8Encoding();
            hashedBytes = mD5Crypto.ComputeHash(utf8.GetBytes(data));
            return hashedBytes;
        }

       
        private void button3_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == captchText)
            {
                MessageBox.Show("Капча верна, теперь введите заново логин и пароль", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _countTries = 0;
                return;
            }
            _countTries++;
            switch (_countTries)
            {
                case 2:
                    textBox3.Text = "";
                    MessageBox.Show("Не верно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    timer1.Interval = 180000;
                    timer1.Start();
                    panel1.Enabled = false;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    break;

                  
                case 3:
                    MessageBox.Show("Перезапуск приложения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    break;
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            Reset();
            panel1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Show();
        }
    }
}

