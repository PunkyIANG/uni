using System.Collections;

namespace lab3;

public static class Queries
{
    public static IEnumerable<Employee> GetAllEmployees(IEnumerable<Employee> employees) =>
        from employee in employees select employee;

    public static IEnumerable<Employee> GetEmployeesWithNamesStartingWithJ(IEnumerable<Employee> employees) =>
        from employee in employees where employee.Name.StartsWith("J") select employee;

    public static IEnumerable<Employee> GetEmployeesWithSalaryGreaterThan1600(IEnumerable<Employee> employees) =>
        from employee in employees where employee.Salary > 1600 select employee;

    public static IEnumerable<Employee> GetEmployeesYoungerThan30(IEnumerable<Employee> employees) =>
        from employee in employees where employee.Age < 30 select employee;

    public static IEnumerable<Employee> GetAllDevelopers(IEnumerable<Employee> employees) =>
        from employee in employees where employee.Position == "Developer" select employee;

    public static IEnumerable<Employee> GetAllManagers(IEnumerable<Employee> employees) =>
        from employee in employees where employee.Position == "Manager" select employee;

    public static IEnumerable<Employee> GetEmployeesFromProject1(IEnumerable<Employee> employees) =>
        from employee in employees where employee.ProjectId == 1 select employee;

    public static IEnumerable<Employee> GetEmployeesFromProject2(IEnumerable<Employee> employees) =>
        from employee in employees where employee.ProjectId == 2 select employee;

    public static IEnumerable<Employee> GetEmployeesFromProject3(IEnumerable<Employee> employees) =>
        from employee in employees where employee.ProjectId == 3 select employee;

    public static IEnumerable<Employee> GetEmployeesFromClient1(IEnumerable<Employee> employees) =>
        from employee in employees
        join project in Collections.Projects on employee.ProjectId equals project.Id
        where project.ClientId == 1
        select employee;

    public static IEnumerable<Employee> GetEmployeesFromClient2(IEnumerable<Employee> employees) =>
        from employee in employees
        join project in Collections.Projects on employee.ProjectId equals project.Id
        where project.ClientId == 2
        select employee;

    public static IEnumerable<Employee> OrderEmployeesByAgeAscending(IEnumerable<Employee> employees) =>
        from employee in employees orderby employee.Age select employee;
    
    public static IEnumerable<Employee> OrderEmployeesBySalaryDescending(IEnumerable<Employee> employees) =>
        from employee in employees orderby employee.Salary descending select employee;

    ///////////////////////////////////////////////////////////////

    public static  IEnumerable<string>GetEmployeeNames(IEnumerable<Employee> employees) =>
        from employee in employees select employee.Name;

    public static IEnumerable<string> OrderPositionsByGreatestMeanSalary(IEnumerable<Employee> employees) =>
        from employee in employees
        group employee by employee.Position
        into positionGroup
        orderby positionGroup.Average(employee => employee.Salary) descending
        select positionGroup.Key;
    
    public static IEnumerable<string> GetProjectNames(IEnumerable<Employee> employees) =>
        from project in Collections.Projects select project.Name;
    
    public static IEnumerable<string> OrderProjectsByMeanSalary(IEnumerable<Employee> employees) =>
        from project in Collections.Projects
        join employee in employees on project.Id equals employee.ProjectId
        group employee by project.Name
        into projectGroup
        orderby projectGroup.Average(employee => employee.Salary) descending
        select projectGroup.Key;

    
}