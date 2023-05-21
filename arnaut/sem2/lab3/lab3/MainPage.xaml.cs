using System.Collections.ObjectModel;
using static lab3.Queries;

namespace lab3;

public partial class MainPage : ContentPage
{
    private static readonly Dictionary<string, Func<IEnumerable<Employee>, IEnumerable<Employee>>> EmployeeQueries =
        new()
        {
            { nameof(GetAllEmployees), GetAllEmployees },
            { nameof(GetEmployeesWithNamesStartingWithJ), GetEmployeesWithNamesStartingWithJ },
            { nameof(GetEmployeesWithSalaryGreaterThan1600), GetEmployeesWithSalaryGreaterThan1600 },
            { nameof(GetEmployeesYoungerThan30), GetEmployeesYoungerThan30 },
            { nameof(GetAllDevelopers), GetAllDevelopers },
            { nameof(GetAllManagers), GetAllManagers },
            { nameof(GetEmployeesFromProject1), GetEmployeesFromProject1 },
            { nameof(GetEmployeesFromProject2), GetEmployeesFromProject2 },
            { nameof(GetEmployeesFromProject3), GetEmployeesFromProject3 },
            { nameof(GetEmployeesFromClient1), GetEmployeesFromClient1 },
            { nameof(GetEmployeesFromClient2), GetEmployeesFromClient2 },
            { nameof(OrderEmployeesByAgeAscending), OrderEmployeesByAgeAscending },
            { nameof(OrderEmployeesBySalaryDescending), OrderEmployeesBySalaryDescending }
        };

    private static readonly Dictionary<string, Func<IEnumerable<Employee>, IEnumerable<string>>> StringQueries = new()
    {
        { nameof(GetEmployeeNames), GetEmployeeNames },
        { nameof(OrderPositionsByGreatestMeanSalary), OrderPositionsByGreatestMeanSalary },
        { nameof(GetProjectNames), GetProjectNames },
        { nameof(OrderProjectsByMeanSalary), OrderProjectsByMeanSalary },
    };

    private readonly DataTemplate EmployeeTemplate;

    public MainPage()
    {
        InitializeComponent();

        EmployeeTemplate = ResultsView.ItemTemplate;

        var allQueries = new List<string>();
        allQueries.AddRange(EmployeeQueries.Keys);
        allQueries.AddRange(StringQueries.Keys);

        QueryPicker.ItemsSource = allQueries;
        QueryPicker.SelectedIndex = 0;

        SetResultsViewItemSource();
    }

    private void QueryPicker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        SetResultsViewItemSource();
    }

    private void SetResultsViewItemSource()
    {
        var selectedQuery = QueryPicker.SelectedItem.ToString();

        if (EmployeeQueries.Keys.Contains(selectedQuery))
        {
            var query = EmployeeQueries[selectedQuery];
            ResultsView.ItemsSource = query(Collections.Employees);
            if (EmployeeTemplate != null)
                ResultsView.ItemTemplate = EmployeeTemplate;
        }
        else if (StringQueries.Keys.Contains(selectedQuery))
        {
            var query = StringQueries[selectedQuery];
            ResultsView.ItemsSource = query(Collections.Employees);
            ResultsView.ItemTemplate = null;
        }
    }
}