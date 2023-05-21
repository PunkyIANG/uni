namespace lab3;

public record Employee(string Name, int Age, string Position, int Salary, int ProjectId);
public record Project(string Name, string Description, int Id, int ClientId);
public record Client(string Name, int Id);

public static class Collections
{
    public static List<Employee> Employees = new()
    {
        new("John", 25, "Developer", 1400, 1),
        new("Jane", 30, "Developer", 2100, 1),
        new("Jack", 35, "Developer", 2400, 2),
        new("Jerry", 27, "Developer", 1500, 3),
        new("Mary", 40, "Manager", 2400, 1),
        new("Mark", 45, "Manager", 2500, 2),
        new("Mike", 32, "Manager", 2500, 3),
    };
    
    public static List<Project> Projects = new()
    {
        new("Rider", "Next-gen IDE for C# development", 1, 1),
        new("IDEA", "Next-gen IDE for Java development", 2, 1),
        new("Jira", "The go-to tool for project management", 3, 2)
    };
    
    public static List<Client> Clients = new()
    {
        new("Jetbrains", 1),
        new("Atlassian", 2)
    };
}