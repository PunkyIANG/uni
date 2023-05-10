using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;

namespace MauiApp1;

public static class Generator
{
    private static Random rng = new Random();

    public static readonly List<string> RandomWords = new List<string>
    {
        "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "Sed", "non", "risus",
        "Suspendisse", "lectus", "tortor", "dignissim", "sit", "amet", "tempor", "sit", "amet", "turpis", "Donec", "ut",
        "libero", "sed", "arcu", "tincidunt", "porta", "Vestibulum", "ac", "diam", "sit", "amet", "quam", "vehicula",
        "elementum", "sed", "sit", "amet", "diam", "Donec", "eget"//, "odio", "risus", "auctor", "euismod", "sit", "amet",
        // "quis", "orci", "Nullam", "id", "dolor", "id", "nibh", "ultricies", "vehicula", "ut", "id", "elit", "Vivamus",
        // "at", "ligula", "quis", "erat", "porttitor", "faucibus", "Donec", "laoreet", "magna", "sed", "vehicula",
        // "fringilla", "nibh", "porttitor", "vitae", "mollis", "arcu", "posuere", "et", "mattis", "ipsum", "Praesent",
        // "placerat", "elementum", "nibh", "sed", "vestibulum", "Donec", "eu", "ligula", "sit", "amet", "ligula",
        // "vehicula", "consequat", "eu", "ac", "erat", "Nam", "ac", "diam", "sit", "amet", "quam", "vehicula",
        // "elementum", "sed", "sit", "amet", "diam"
    };

    public static List<int> GenerateInts(int count)
    {
        return Enumerable.Range(0, count).ToList().Shuffle();
    }

    public static List<float> GenerateFloats(int count)
    {
        return Enumerable.Range(0, count).Select(x => (float)x).ToList().Shuffle();
    }
    
    public static List<T> Shuffle<T>(this List<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }

        return list;
    }
    
    public static ObservableCollection<T> Shuffle<T>(this ObservableCollection<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
        return list;
    }

    public static BindingList<T> Shuffle<T>(this BindingList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
        return list;
    }
}