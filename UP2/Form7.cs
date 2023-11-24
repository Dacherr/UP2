using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace UP2
{
    public partial class Form7 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form7()
        {
            InitializeComponent();
            InitializeSqlConnection();
        }

        private void InitializeSqlConnection()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Malina"].ConnectionString);
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "malinaDataSet2.LoginHistory". При необходимости она может быть перемещена или удалена.
            this.loginHistoryTableAdapter.Fill(this.malinaDataSet2.LoginHistory);
            ShowLoginHistory();

        }
        private void ShowLoginHistory()
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                string query = "SELECT * FROM LoginHistory ORDER BY TimeStamp DESC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
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

    




    private void button1_Click(object sender, EventArgs e)
        {
            ShowLoginHistory();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Show();
        }
    }
}

