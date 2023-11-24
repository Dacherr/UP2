using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using static UP2.Form5;
using System.Linq;

namespace UP2
{
    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = null;
        private int selectedRow;
        private List<Instance> selectedInstances;

        public Form4(List<Instance> selectedInstances)
        {
            InitializeComponent();
            this.selectedInstances = selectedInstances;

            dataGridView1.Columns.Add("IdBook", "IdBook");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("FirstAuthor", "FirstAuthor");
            dataGridView1.Columns.Add("PublishingHouse", "PublishingHouse");
            dataGridView1.Columns.Add("PlacePublication", "PlacePublication");
            dataGridView1.Columns.Add("YearPublication", "YearPublication");
            dataGridView1.Columns.Add("NumberPages", "NumberPages");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("ThemeCode", "ThemeCode");

            // Используйте selectedInstances для заполнения DataGridView
            foreach (var instance in this.selectedInstances)
            {
                // Логика добавления данных в DataGridView
                dataGridView1.Rows.Add(
                    instance.IdBook,
                    instance.Name,
                    instance.FirstAuthor,
                    instance.PublishingHouse,
                    instance.PlacePublication, // Добавлено
                    instance.YearPublication,
                    instance.NumberPages,
                    instance.Price,
                    instance.ThemeCode);
            }
        }

        public Form4()
        {
            InitializeComponent();
            InitializeSqlConnection();

            // Определение столбцов для DataGridView
            dataGridView1.Columns.Add("Инвентарный_номер", "Инвентарный номер");
            dataGridView1.Columns.Add("Количество_экземпляров", "Количество экземпляров");
            dataGridView1.Columns.Add("Дата_выдачи", "Дата выдачи");
            dataGridView1.Columns.Add("id_книги", "ID книги");
        }

        private void InitializeSqlConnection()
        {
           
         
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Malina"].ConnectionString);
            //if (sqlConnection.State != ConnectionState.Open)
            //    sqlConnection.Open();

            //RefreshDataGridData(dataGridView1);
        }

        private void RefreshDataGridData(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            string queryString =
                "SELECT [Инвентарный_номер ],[Количество_экземпляров ],[Дата_выдачи ]  ,[id_книги ]  " +
                "FROM [Экземпляры] ";

            using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReadSingleRowData(dataGridView, reader);
                    }
                }
            }
        }

        private void ReadSingleRowData(DataGridView dataGridView, SqlDataReader reader)
        {
            dataGridView.Rows.Add(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.IsDBNull(2) ? null : (object)reader.GetDateTime(2),
                reader.GetInt32(3));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оформлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox2.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создаем список для хранения строк, которые нужно удалить
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            // Добавляем в список строки, которые нужно удалить
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                rowsToDelete.Add(row);
            }

            // Удаляем строки из DataGridView
            foreach (DataGridViewRow rowToDelete in rowsToDelete)
            {
                dataGridView1.Rows.Remove(rowToDelete);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            
            this.Hide();
            form.ShowDialog();
      
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
   
            this.Hide();
            form1.ShowDialog();
               }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            UpdateBookCount();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateBookCount();
        }
        private void UpdateBookCount()
        {
            textBox2.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Count(row => !row.IsNewRow)).ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            int readerId;
            if (int.TryParse(textBox4.Text, out readerId))
            {
                try
                {
                    // Проверяем, что sqlConnection не равно null
                    if (sqlConnection == null)
                    {
                        MessageBox.Show("Отсутствует подключение к базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Открываем соединение
                    if (sqlConnection.State != ConnectionState.Open)
                        sqlConnection.Open();

                    string queryString =
                        "SELECT * " +
                        "FROM Читатели " +
                        "WHERE [id_читательского_билета] = @id_читательского_билета";

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id_читательского_билета", readerId);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox3.Text = reader["ФИО_Читателя"].ToString();
                                textBox5.Text = reader["Номер_телефона"].ToString();
                                textBox6.Text = reader["Дата_рождения"].ToString();
                            }
                            else
                            {
                                textBox3.Text = string.Empty;
                                textBox5.Text = string.Empty;
                                textBox6.Text = string.Empty;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Всегда закрываем соединение после использования
                    if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                        sqlConnection.Close();
                }
            }
            else
            {
                // Очищаем текстовые поля, если введенный ID не является числом
                textBox3.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                // Очищайте остальные поля аналогичным образом
            }
        }
    }
}
