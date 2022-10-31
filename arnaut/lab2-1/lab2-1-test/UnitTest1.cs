using lab2_1_main;
using static lab2_1_main.Rational;

namespace lab2_1_test;

public class Tests
{
    private Rational a;
    private Rational b;
    
    [SetUp]
    public void Setup()
    {
        a = new Rational(10, 2);
        b = new Rational(5, 3);
    }

    [Test]
    public void Sum()
    {
        Assert.That(new Rational(20, 3), Is.EqualTo(a + b));
    }
    
    [Test]
    public void Subtract()
    {
        Assert.That(new Rational(10, 3), Is.EqualTo(a - b));
    }

    [Test]
    public void Multiply()
    {
        Assert.That(new Rational(25, 3), Is.EqualTo(a * b));
    }

    [Test]
    public void Divide()
    {
        Assert.That(new Rational(3), Is.EqualTo(a / b));
    }
    
    [Test]
    public void ParseStringInt()
    {
        Assert.Multiple(() =>
        {
            Assert.That(TryParse("123", out var output), Is.True);
            Assert.That(new Rational(123), Is.EqualTo(output));
        });
    }

    [Test]
    public void ParseStringFloat()
    {
        Assert.Multiple(() =>
        {
            Assert.That(TryParse("1.23", out var output), Is.True);
            Assert.That(new Rational(123, 100), Is.EqualTo(output));
        });
    }
    
    [Test]
    public void ParseStringFloatDivFloat()
    {
        Assert.Multiple(() =>
        {
            Assert.That(TryParse("1.28/.64", out var output), Is.True);
            Assert.That(new Rational(2), Is.EqualTo(output));
        });
    }
}