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
using static UP2.Form5;

namespace UP2
{
    public partial class Form5 : Form



    {
        public Form5()
        {
            InitializeComponent();
        }
        public class Instance
        {
            public int IdBook { get; set; }
            public string Name { get; set; }
            public string FirstAuthor { get; set; }
            public string PublishingHouse { get; set; }
            public string PlacePublication { get; set; }
            public int YearPublication { get; set; }
            public int NumberPages { get; set; }
            public decimal Price { get; set; }
            public string ThemeCode { get; set; }
        }
        public List<Instance> selectedInstances { get; private set; } = new List<Instance>();
        private void Form5_Load(object sender, EventArgs e)
        {
            this.тематические_каталогиTableAdapter.Fill(this.malinaDataSet1.Тематические_каталоги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "malinaDataSet1.Тематические_каталоги". При необходимости она может быть перемещена или удалена.
            this.тематические_каталогиTableAdapter.Fill(this.malinaDataSet1.Тематические_каталоги);
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Malina"].ConnectionString);
            sqlConnection.Open(); // открыли подключение к бд
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Книги", sqlConnection);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;

            // Проверяем, не является ли строка поиска пустой
            if (!string.IsNullOrEmpty(searchText))
            {
                // Применяем фильтр по части текста в любом месте столбца "Название"
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Название LIKE '%{searchText}%'";
            }
            else
            {
                // Если строка поиска пуста, сбрасываем фильтр
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Код_темы = 1 OR Код_темы = 2 OR Код_темы = 3";
                    break;

                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Код_темы = 1";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Код_темы = 2";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Код_темы = 3";
                    break;
                case 4:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    Instance instance = new Instance
                    {
                        IdBook = Convert.ToInt32(row.Cells[0].Value),
                        Name = row.Cells[1].Value.ToString(),
                        FirstAuthor = row.Cells[2].Value.ToString(),
                        PublishingHouse = row.Cells[3].Value.ToString(),
                        PlacePublication = row.Cells[4].Value.ToString(),
                        YearPublication = Convert.ToInt32(row.Cells[5].Value),
                        NumberPages = Convert.ToInt32(row.Cells[6].Value),
                        Price = Convert.ToDecimal(row.Cells[7].Value),
                        ThemeCode = row.Cells[8].Value.ToString()
                    };

                    selectedInstances.Add(instance);
                }
              
              
            }

            if (selectedInstances.Count == 0)
            {
                MessageBox.Show("Выберете книги из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                Form4 form = new Form4(selectedInstances);
              
                this.Hide();
                form.ShowDialog();
                this.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            this.Hide();
            form1.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Close();
            this.Hide();
            form6.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
