using System;
using StringCalculator;
using Xunit;

namespace CalculatorTests;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        int res = StringCalculator.StringCalculator.CalculateString("");
        Assert.Equal(0, res);
    }
    [Theory]
    [InlineData("25", 25)]
    [InlineData("234", 234)]
    [InlineData("5", 5)]
    public void SingleNumberReturnsOneNumber(string s, int expected)
    {
        int res = StringCalculator.StringCalculator.CalculateString(s);
        Assert.Equal(expected, res);
    }
    [Theory]
    [InlineData("25, 34", 59)]
    [InlineData("234, 1", 235)]
    [InlineData("5, 7", 12)]
    public void TwoNumbersSeparatedByColonReturnsSum(string s, int expected)
    {
        int res = StringCalculator.StringCalculator.CalculateString(s);
        Assert.Equal(expected, res);
    }
    [Theory]
    [InlineData("25\n34", 59)]
    [InlineData("234\n1", 235)]
    [InlineData("5\n7", 12)]
    public void TwoNumbersSeparatedByNewlineReturnsSum(string s, int expected)
    {
        int res = StringCalculator.StringCalculator.CalculateString(s);
        Assert.Equal(expected, res);
    }
    [Theory]
    [InlineData("25, 34\n2", 61)]
    [InlineData("234, 1, 25", 260)]
    [InlineData("5\n7\n4", 16)]
    public void ThreeNumbersSeparatedByNewlineOrColonReturnsSum(string s, int expected)
    {
        int res = StringCalculator.StringCalculator.CalculateString(s);
        Assert.Equal(expected, res);
    }
    [Theory]
    [InlineData("-25, 34\n2", 61)]
    [InlineData("234, -1, 25", 260)]
    [InlineData("5\n-7\n4", 16)]
    public void NegativeNumbersThrowException(string s, int expected)
    {
        _ = Assert.Throws<ArgumentException>(() => StringCalculator.StringCalculator.CalculateString(s));
    }
    [Theory]
    [InlineData("25, 3400\n2", 27)]
    [InlineData("234, 1, 25, 1001", 260)]
    [InlineData("5\n7\n4, 1000", 1016)]
    public void NumbersGreaterThan1000AreIgnored(string s, int expected)
    {
        int res = StringCalculator.StringCalculator.CalculateString(s);
        Assert.Equal(expected, res);
    }
    [Theory]
    [InlineData("//#\n25#3400#2", 27)]
    [InlineData("//t\n234t1, 25, 1001", 260)]
    [InlineData("//x\n5,7\n4x1000", 1016)]
    public void FirstLineDefinesNewSeparator(string s, int expected)
    {
        int res = StringCalculator.StringCalculator.CalculateString(s);
        Assert.Equal(expected, res);
    }
    [Theory]
    [InlineData("//[#::]\n25#::3400#::2", 27)]
    [InlineData("//[tt]\n234tt1, 25, 1001", 260)]
    [InlineData("//[xa]\n5,7\n4xa1000", 1016)]
    public void BracketsDefineNewMulticharacterSeparator(string s, int expected)
    {
        int res = StringCalculator.StringCalculator.CalculateString(s);
        Assert.Equal(expected, res);
    }
}
