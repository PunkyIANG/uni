using System.Collections.Generic;
using System.Linq;

public static class ExtensionStuff
{
    #region Generation

    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
    {
        return source.DefaultIfEmpty(default);
    }

    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource fallback)
    {
        return source.Any() ? source : new List<TSource> { fallback };
    }

    public static IEnumerable<TSource> Empty<TSource>() => new List<TSource>();

    public static IEnumerable<int> Range(int start, int count)
    {
        var result = new List<int>();

        for (int i = 0; i < count; i++)
            result.Add(start + i);

        return result;
    }

    public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
    {
        var result = new List<TResult>();

        for (int i = 0; i < count; i++)
            result.Add(element);

        return result;
    }

    #endregion

    #region Equality

    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second,
        IEqualityComparer<TSource> comparer)
    {
        if (first.Count() != second.Count())
            return false;

        var firstEnumerator = first.GetEnumerator();
        var secondEnumerator = second.GetEnumerator();

        for (var i = 0; i < first.Count(); i++)
            if (!comparer.Equals(firstEnumerator.Current, secondEnumerator.Current))
                return false;

        return true;
    }

    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
        if (first.Count() != second.Count())
            return false;

        var firstEnumerator = first.GetEnumerator();
        var secondEnumerator = second.GetEnumerator();

        for (var i = 0; i < first.Count(); i++)
            if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                return false;

        return true;
    }

    #endregion

    #region Join

    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector)
    {
        var result = new List<TResult>();

        foreach (var outerValue in outer)
        foreach (var innerValue in inner)
        {
            var outerKey = outerKeySelector.Invoke(outerValue);
            var innerKey = innerKeySelector.Invoke(innerValue);

            if (outerKey.Equals(innerKey))
                result.Add(resultSelector.Invoke(outerValue, innerValue));
        }

        return result;
    }

    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector,
        IEqualityComparer<TKey> comparer)
    {
        var result = new List<TResult>();

        foreach (var outerValue in outer)
        foreach (var innerValue in inner)
        {
            var outerKey = outerKeySelector.Invoke(outerValue);
            var innerKey = innerKeySelector.Invoke(innerValue);

            if (comparer.Equals(outerKey, innerKey))
                result.Add(resultSelector.Invoke(outerValue, innerValue));
        }

        return result;
    }

    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
    {
        var result = new List<TResult>();

        foreach (var outerValue in outer)
        {
            var innerResult = new List<TInner>();
            foreach (var innerValue in inner)
            {
                var outerKey = outerKeySelector.Invoke(outerValue);
                var innerKey = innerKeySelector.Invoke(innerValue);

                if (outerKey.Equals(innerKey))
                    innerResult.Add(innerValue);
            }

            result.Add(resultSelector.Invoke(outerValue, innerResult));
        }

        return result;
    }

    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
        IEqualityComparer<TKey> comparer)
    {
        var result = new List<TResult>();

        foreach (var outerValue in outer)
        {
            var innerResult = new List<TInner>();

            foreach (var innerValue in inner)
            {
                var outerKey = outerKeySelector.Invoke(outerValue);
                var innerKey = innerKeySelector.Invoke(innerValue);

                if (comparer.Equals(outerKey, innerKey))
                    innerResult.Add(innerValue);
            }
            
            result.Add(resultSelector.Invoke(outerValue, innerResult));
        }

        return result;
    }

    #endregion
    
    public record Obiect(int id, string name, int professorId);
    public record Professor(int id, string name, int age);

    public static void Main()
    {
        Professor popescu = new(id: 1, name: "Popescu", age: 40);
        Professor ionescu = new(id: 2, name: "Ionescu", age: 50);
        Professor georgescu = new(id: 3, name: "Georgescu", age: 60);

        var professors = new List<Professor> { popescu, ionescu, georgescu };

        Obiect html = new(id: 1, name: "HTML", professorId: 1);
        Obiect css = new(id: 2, name: "CSS", professorId: 1);
        Obiect js = new(id: 3, name: "JS", professorId: 1);
        Obiect csharp = new(id: 4, name: "C#", professorId: 2);
        Obiect java = new(id: 5, name: "Java", professorId: 2);
        Obiect python = new(id: 6, name: "Python", professorId: 3);
        Obiect machineLearning = new(id: 7, name: "Machine Learning", professorId: 3);

        var obiecte = new List<Obiect> { html, css, js, csharp, java, python, machineLearning };

        var result = professors.GroupJoin(
            obiecte,
            professor => professor.id,
            obiect => obiect.professorId,
            (professor, obiecte) => (professor, obiecte));

        foreach (var (professor, localObiecte) in result)
        {
            Console.WriteLine($"{professor.name}: ");
            foreach (var obiect in localObiecte)
                Console.WriteLine($"    {obiect.name}");
        }
    }
}

