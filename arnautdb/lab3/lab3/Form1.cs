using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lab3;

public partial class Form1 : Form
{
    private SqlConnection connection;
    private SqlDataAdapter adapter;
    private DataTable dataTable;
    private DataGridView dataGridView;
    private ComboBox comboBox;
    private Panel panel;
    private BindingSource bindingSource;

    public Form1()
    {
        InitializeComponent();
        panel = new Panel { Dock = DockStyle.Fill };
        Controls.Add(panel);

        comboBox = new ComboBox { Location = new Point(10, 10) };
        comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        panel.Controls.Add(comboBox);

        dataGridView = new DataGridView { Dock = DockStyle.Fill, Location = new Point(10, 40), AllowUserToAddRows = true, AllowUserToDeleteRows = true };
        dataGridView.CellValueChanged += (_,_) => UpdateAdapter();
        dataGridView.RowValidated += (_,_) => UpdateAdapter();
        panel.Controls.Add(dataGridView);

        string connectionString = @"data source=WINDOWS-39KKRST\SQLEXPRESS02;initial catalog=NorthWind;trusted_connection=true";
        connection = new SqlConnection(connectionString);
        adapter = new SqlDataAdapter("SELECT * FROM Categories", connection);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
        dataTable = new DataTable();
        adapter.Fill(dataTable);

        bindingSource = new BindingSource();
        bindingSource.DataSource = dataTable;
        dataGridView.DataSource = bindingSource;

        connection.Open();
        DataTable schema = connection.GetSchema("Tables");
        foreach (DataRow row in schema.Rows)
        {
            comboBox.Items.Add(row[2].ToString());
        }
        connection.Close();
    }

    private void UpdateAdapter() {
        try
        {
            adapter.Update(dataTable);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedTable = comboBox.SelectedItem.ToString();
        adapter = new SqlDataAdapter($"SELECT * FROM {selectedTable}", connection);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
        dataTable = new DataTable();
        adapter.Fill(dataTable);
        bindingSource.DataSource = dataTable;
    }
}