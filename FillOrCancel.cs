using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace WindowsFormsADOnet
{

    public partial class FillOrCancel : Form
    {
        // Storage for the order ID value.
        private int parsedOrderID;

        /// <summary>
        /// Verifies that an order ID is present and contains valid characters.
        /// </summary>
        private bool IsOrderIDValid()
        {
            // Check for input in the Order ID text box.
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Please specify the Order ID.");
                return false;
            }

            // Check for characters other than integers.
            else if (Regex.IsMatch(txtOrderID.Text, @"^\D*$"))
            {
                // Отображение сообщения и очистка ввода
                MessageBox.Show("Customer ID must contain only numbers.");
                txtOrderID.Clear();
                return false;
            }
            else
            {
                // Конвертация текста в text box в integer для отправки в бд
                parsedOrderID = Int32.Parse(txtOrderID.Text);
                return true;
            }
        }

        public FillOrCancel()
        {
            InitializeComponent();
        }

        private void BtnFindByOrderID_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    // Определение строки t-SQL запроса
                    const string sql = "SELECT * FROM Sales.Orders WHERE orderID = @orderID";

                    // Create a SqlCommand object.
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        // Определение параметра @orderID и установка его значения
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();

                            // Отправка запроса посредством вызова ExecuteReader().
                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                // Создание таблицы данных для удержания возвращенных значений
                                DataTable dataTable = new DataTable();

                                // Загрузка данных из SqlDataReader в таблицу данных
                                dataTable.Load(dataReader);

                                // Отображение данных их таблицы данных в data grid view
                                dgvCustomerOrders.DataSource = dataTable;

                                // Закрытие SqlDataReader.
                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("The requested order could not be loaded into the form.");
                        }
                        finally
                        {
                            // Закрытие соединенния
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                // Create the connection.
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    // Create the SqlCommand object and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspCancelOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add the order ID input parameter for the stored procedure.
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            // Open the connection.
                            connection.Open();

                            // Run the command to execute the stored procedure.
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("The cancel operation was not completed.");
                        }
                        finally
                        {
                            // Закрытие соединенния
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void BtnFillOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                // Create the connection.
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    // Create command and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspFillOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add the order ID input parameter for the stored procedure.
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        // Add the filled date input parameter for the stored procedure.
                        sqlCommand.Parameters.Add(new SqlParameter("@FilledDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@FilledDate"].Value = dtpFillDate.Value;

                        try
                        {
                            connection.Open();

                            // Execute the stored procedure.
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("The fill operation was not completed.");
                        }
                        finally
                        {
                            // Закрытие соединенния
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void BtnFinishUpdates_Click(object sender, EventArgs e) => Close();
    }
}
