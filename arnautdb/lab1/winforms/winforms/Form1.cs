using System.Data;
using System.Data.SqlClient;

namespace winforms
{
    public partial class Form1 : Form
    {
        //Server=localhost\SQLEXPRESS02;Database=master;Trusted_Connection=True;

        private const string connectionString = "data source=WINDOWS-39KKRST\\SQLEXPRESS02;initial catalog=NorthWind;trusted_connection=true";
        private readonly string[] tableNames = {
            "[Categories]",
            "[CustomerCustomerDemo]",
            "[CustomerDemographics]",
            "[Customers]",
            "[Employees]",
            "[EmployeeTerritories]",
            "[Order Details]",
            "[Orders]",
            "[Products]",
            "[Region]",
            "[Shippers]",
            "[Suppliers]",
            "[Territories]"
        };

        private readonly string[] validCommands = {
            "select",
            "insert",
            "update",
            "delete"
        };

        private DataGridView _dataGridView;
        private TextBox _textBox;
        private Panel _panel;
        private ComboBox _tableNamesComboBox;
        private ComboBox _validCommandsComboBox;


        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            // GenerateCommand(null, null);
            // LoadData();
        }

        private void InitializeDataGridView()
        {
            _panel = new Panel { Dock = DockStyle.Fill };
            Controls.Add(_panel);

            _textBox = new TextBox { Dock = DockStyle.Top };
            _textBox.KeyDown += TextBox_KeyDown;
            _panel.Controls.Add(_textBox);

            _validCommandsComboBox = new ComboBox { Dock = DockStyle.Top, DataSource = validCommands };
            _validCommandsComboBox.SelectedIndexChanged += GenerateCommand;
            _panel.Controls.Add(_validCommandsComboBox);

            _tableNamesComboBox = new ComboBox { Dock = DockStyle.Top, DataSource = tableNames };
            _tableNamesComboBox.SelectedIndexChanged += GenerateCommand;
            _panel.Controls.Add(_tableNamesComboBox);

            _dataGridView = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = true };
            _panel.Controls.Add(_dataGridView);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        private void GenerateCommand(object sender, EventArgs e)
        {
            string tableName = _tableNamesComboBox.SelectedItem.ToString();
            string command = _validCommandsComboBox.SelectedItem.ToString();

            _textBox.Text = InternalGenerateCommand(tableName, command);
        }

        private string InternalGenerateCommand(string tableName, string command) {
            switch (command) {
                case "select":
                    return $"select * from {tableName}";
                case "insert":
                    return $"insert into {tableName} values (1, 'test')";
                case "update":
                    return $"update {tableName} set name = 'test' where id = 1";
                case "delete":
                    return $"delete from {tableName} where id = 1";
            }

            return "";
        }


        private void LoadData(string sql = null)
        {
            if (sql == null)
                sql = _textBox.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.FieldCount == 0)
                            {
                                LoadData(InternalGenerateCommand(_tableNamesComboBox.SelectedItem.ToString(), "select"));
                            }
                            else
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);
                                _dataGridView.DataSource = dataTable;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }
    }
}