using System;
using NUnit.Framework;

[TestFixture]
public class ProductTests
{
    [Test]
    public void When_N_Is_1_Returns_CorrectResult()
    {
        // Arrange
        int n = 1;
        double expected = Math.Pow(Math.Cos(1), 2);

        // Act
        double actual = Program.CalculateProduct(n);

        // Assert
        Assert.AreEqual(expected, actual, 0.0000001);
    }

    [Test]
    public void When_N_Is_5_Returns_CorrectResult()
    {
        // Arrange
        int n = 5;
        double expected = Math.Pow(Math.Cos(1), 2) * 
                         Math.Pow(Math.Cos(2), 2) * 
                         Math.Pow(Math.Cos(3), 2) * 
                         Math.Pow(Math.Cos(4), 2) * 
                         Math.Pow(Math.Cos(5), 2);

        // Act
        double actual = Program.CalculateProduct(n);

        // Assert
        Assert.AreEqual(expected, actual, 0.0000001);
    }

    [Test]
    public void When_N_Is_Zero_Throws_ArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Program.CalculateProduct(0));
    }

    [Test]
    public void When_N_Is_Negative_Throws_ArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Program.CalculateProduct(-5));
    }
} 