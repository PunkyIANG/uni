using System.Collections;

namespace lab3;

public class MyString : IEnumerable<char>
{
    private readonly char[] _characters;

    #region Constructors

    public MyString(char[] characters)
    {
        _characters = (char[])characters.Clone();
    }

    public MyString() : this(Array.Empty<char>()) {}

    public MyString(string inputString) : this(inputString.ToCharArray()) { }
    
    public MyString(MyString myString) : this(myString._characters) { }
    
    #endregion

    #region Indexer

    public char this[int i]
    {
        get => _characters[i];
        set => _characters[i] = value;
    }

    #endregion

    #region Properties
    
    public static MyString Empty => new MyString();
    public int Length => _characters.Length;
    public bool IsEmpty => Length == 0;
    
    #endregion
    
    #region Methods
    
    public char[] ToCharArray() => (char[])_characters.Clone();
    
    public override string ToString() => new(_characters);
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public MyString Substring(int startIndex, int length)
    {
        if (startIndex < 0 || startIndex >= Length)
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        if (length < 0 || startIndex + length > Length)
            throw new ArgumentOutOfRangeException(nameof(length));
        var result = new char[length];
        Array.Copy(_characters, startIndex, result, 0, length);
        return new MyString(result);
    }
    
    public MyString Substring(int startIndex) => Substring(startIndex, Length - startIndex);

    
    public MyString Concat(char[] chars, int startIndex, int length)
    {
        if (chars.Length == 0)
            return this;
        
        if (startIndex < 0 || startIndex >= chars.Length)
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        if (length < 0 || startIndex + length > chars.Length)
            throw new ArgumentOutOfRangeException(nameof(length));
        var result = new char[Length + length];
        Array.Copy(_characters, result, Length);
        Array.Copy(chars, startIndex, result, Length, length);
        return new MyString(result);
    }

    public MyString Concat(MyString myString) => Concat(myString._characters, 0, myString.Length);
    
    public MyString Concat(string str) => Concat(str.ToCharArray(), 0, str.Length);
    
    public MyString Concat(char c) => Concat(new[] {c}, 0, 1);
    
    public MyString Concat(char[] chars) => Concat(chars, 0, chars.Length);

    public MyString Concat(MyString myString, int startIndex, int length) =>
        Concat(myString._characters, startIndex, length);
    
    public MyString Concat(string str, int startIndex, int length) =>
        Concat(str.ToCharArray(), startIndex, length);
    
    
    public IEnumerator<char> GetEnumerator()
    {
        return ((IEnumerable<char>)_characters).GetEnumerator();
    }

    public override bool Equals(object? obj)
    {
        if (obj is MyString myString)
            return _characters.Equals(myString._characters);
        return false;
    }

    public bool Equals(MyString other)
    {
        return _characters.Equals(other._characters);
    }

    public override int GetHashCode()
    {
        return _characters.GetHashCode();
    }

    #endregion
    
    #region Operators

    public static MyString operator+(MyString myString1, MyString myString2) => myString1.Concat(myString2);

    public static bool operator==(MyString myString1, MyString myString2) => myString1.Equals(myString2);
    
    public static bool operator!=(MyString myString1, MyString myString2) => !myString1.Equals(myString2);

    public static implicit operator MyString(string str) => new(str);
    
    public static implicit operator string(MyString myString) => myString.ToString();

    #endregion
}