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
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;

namespace UP2
{
    public partial class Form6 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form6()
        {
            InitializeComponent();
            InitializeSqlConnection();
        }
        private void InitializeSqlConnection()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Malina"].ConnectionString);
        }
        private void Form6_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка открытости соединения
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                // SQL-запрос INSERT для добавления новой книги
                string insertQuery =
                    "INSERT INTO Книги (id_книги, Название, Первый_автор, Издательство, Место_издания, Год_издания, " +
                    "Количество_страниц, Цена, Код_темы) " +
                    "VALUES (@id_книги, @Название, @Первый_автор, @Издательство, @Место_издания, @Год_издания, " +
                    "@Количество_страниц, @Цена, @Код_темы)";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                {
                    // Параметризированные значения из текстовых полей
                    sqlCommand.Parameters.AddWithValue("@id_книги", textBox1.Text);
                    sqlCommand.Parameters.AddWithValue("@Название", textBox2.Text);
                    sqlCommand.Parameters.AddWithValue("@Первый_автор", textBox3.Text);
                    sqlCommand.Parameters.AddWithValue("@Издательство", textBox4.Text);
                    sqlCommand.Parameters.AddWithValue("@Место_издания", textBox5.Text);
                    sqlCommand.Parameters.AddWithValue("@Год_издания", textBox6.Text);
                    sqlCommand.Parameters.AddWithValue("@Количество_страниц", textBox7.Text);
                    sqlCommand.Parameters.AddWithValue("@Цена", textBox8.Text);
                    sqlCommand.Parameters.AddWithValue("@Код_темы", textBox9.Text);

                    // Выполнение SQL-запроса
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Данные успешно сохранены в базе данных.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Всегда закрываем соединение после использования
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
