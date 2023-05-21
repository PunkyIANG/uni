namespace lab2;

public class LoremIpsumString
{
    public static readonly string[] FullText = new[] { "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "Sed", "non", "risus",
        "Suspendisse", "lectus", "tortor", "dignissim", "sit", "amet", "tempor", "sit", "amet", "turpis", "Donec", "ut",
        "libero", "sed", "arcu", "tincidunt", "porta", "Vestibulum", "ac", "diam", "sit", "amet", "quam", "vehicula",
        "elementum", "sed", "sit", "amet", "diam", "Donec", "eget"  };

    public string Value => FullText[Index];
    public int Index;
    public readonly Guid Id = Guid.NewGuid();
    
    public LoremIpsumString(int index)
    {
        this.Index = index;
    }
}