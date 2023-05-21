using System.Collections;

namespace lab2;

public class Collections
{
    public static (string,IEnumerable<PropertyWrapper>)[] GetEnumerables() => new[] {
        ("Employee", new Employee().Cast<PropertyWrapper>()),
        ("TypedEmployee", new TypedEmployee()),
        ("ListEmployee", new ListEmployee()),
        ("CustomEnumeratorEmployee", new CustomEnumeratorEmployee().Cast<PropertyWrapper>())
    };
}

// public record PropertyWrapper(string name, object value);

public class PropertyWrapper
{
    public string name { get; set; }
    public object value { get; set; }
    
    public PropertyWrapper(string name, object value)
    {
        this.name = name;
        this.value = value;
    }

    public override string ToString()
    {
        return $"{name}: {value}";
    }
}

public class Employee : IEnumerable
{
    public string Name { get; set; } = "John";
    public string Surname { get; set; } = "Doe";
    public int Age { get; set; } = 22;
    public string Position { get; set; } = "Manager";


    public IEnumerator GetEnumerator()
    {
        yield return new PropertyWrapper(nameof(Name), Name);
        yield return new PropertyWrapper(nameof(Surname), Surname);
        yield return new PropertyWrapper(nameof(Age), Age);
        yield return new PropertyWrapper(nameof(Position), Position);
    }
}

public class TypedEmployee : IEnumerable<PropertyWrapper>
{
    public string Name { get; set; } = "TypedJohn";
    public string Surname { get; set; } = "TypedDoe";
    public int Age { get; set; } = 34;
    public string Position { get; set; } = "TypedManager";

    public IEnumerator<PropertyWrapper> GetEnumerator()
    {
        yield return new PropertyWrapper(nameof(Name), Name);
        yield return new PropertyWrapper(nameof(Surname), Surname);
        yield return new PropertyWrapper(nameof(Age), Age);
        yield return new PropertyWrapper(nameof(Position), Position);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class ListEmployee : List<PropertyWrapper>
{
    public string Name { get; set; } = "ListJohn";
    public string Surname { get; set; } = "ListDoe";
    public int Age { get; set; } = 46;
    public string Position { get; set; } = "ListManager";

    public ListEmployee()
    {
        Add(new PropertyWrapper(nameof(Name), Name));
        Add(new PropertyWrapper(nameof(Surname), Surname));
        Add(new PropertyWrapper(nameof(Age), Age));
        Add(new PropertyWrapper(nameof(Position), Position));
    }
}

public class CustomEnumeratorEmployee : IEnumerable
{
    public string Name { get; set; } = "CustomJohn";
    public string Surname { get; set; } = "CustomDoe";
    public int Age { get; set; } = 58;
    public string Position { get; set; } = "CustomManager";

    public IEnumerator GetEnumerator()
    {
        return new CustomEnumerator(this);
    }
    
    private class CustomEnumerator : IEnumerator
    {
        private const int _max = 4;
        private int _index = -1;
        private readonly CustomEnumeratorEmployee _employee;
        
        public CustomEnumerator(CustomEnumeratorEmployee employee)
        {
            _employee = employee;
        }
        
        public bool MoveNext()
        {
            _index++;
            return _index < _max;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current => _index switch
        {
            0 => new PropertyWrapper(nameof(Name), _employee.Name),
            1 => new PropertyWrapper(nameof(Surname), _employee.Surname),
            2 => new PropertyWrapper(nameof(Age), _employee.Age),
            3 => new PropertyWrapper(nameof(Position), _employee.Position),
            _ => throw new InvalidOperationException()
        };
    }
}