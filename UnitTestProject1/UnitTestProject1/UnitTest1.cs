using Microsoft.VisualStudio.TestTools.UnitTesting;
using lib;
using System;
using System.Data;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private string connectionString = "DESKTOP-L9E1VNG\\SQLEXPRESS;Initial Catalog=Malina;Integrated Security=True";

        [TestMethod]
        public void OpenConnection()
        {
            Database db = new Database(connectionString);
            db.OpenConnection();
            Assert.AreEqual(ConnectionState.Open, db.GetConnection().State);
        }

        [TestMethod]
        public void CloseConnection()
        {
            Database db = new Database(connectionString);
            db.OpenConnection();
            db.CloseConnection();
            Assert.AreEqual(ConnectionState.Closed, db.GetConnection().State);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelectQueryToDataGridView()
        {
            var query = "SELECT * FROM test_dbo";
            var dgv = new DataGridView();
            var dataTable = Database.SelectQueryToDataGridView(connectionString, query, dgv);
            Assert.IsNotNull(dataTable);
            Assert.IsTrue(dataTable.Rows.Count > 0);
        }

        [TestMethod]
        public void RemoveDataFromDatabase()
        {
            var dgv = new DataGridView();
            var tableName = "test_dbo";
            var primaryKeyColumn = "Id";
            var primaryKeyValue = 1;
            var database = new Database(connectionString);
            database.RemoveDataFromDatabase(tableName, primaryKeyColumn, primaryKeyValue, dgv);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertQuery()
        {
            var birthDate = DateTime.Now.ToString("yyyy-MM-dd");

            var query = "INSERT INTO test_db (id_читательского_билета, ФИО_Читателя, Номер_телефона, Дата_рождения, Логин, Пароль) " +
                        "VALUES (@id_читательского_билета, @ФИО_Читателя, @Номер_телефона, @Дата_рождения, @Логин, @Пароль)";
            var parameters = new Parameter[]
            {
                new Parameter("@id_читательского_билета", "545454"),
                new Parameter("@ФИО_Читателя", "Федоров Федор Федорович"),
                new Parameter("@Номер_телефона", "89119876702"),
                new Parameter("@Дата_рождения", birthDate),
                new Parameter("@Логин", "Fedorr"),
                new Parameter("@Пароль", "Fedya")
            };

            Database.InsertQuery(connectionString, query, parameters);
        }
    }
}
