using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusiness.Operators;

public class DivisionOperatorTests
{
    [Theory]
    [InlineData(1, 2, 1/2)]
    [InlineData(3, 4, 3/4)]
    [InlineData(-45, 111, -45/111)]
    [InlineData(int.MaxValue, 1, int.MaxValue)]
    public void Test_DivideCalculate(int first, int second, int expected)
    {
        //Arrange
        DivisionOperator divideOperator = new DivisionOperator();
        //Act
        var result = divideOperator.Calculate(first, second);
        //Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(3, 0)]
    [InlineData(0, 0)]
    public void Test_DivisionByZero(int first, int second)
    {
        //Arrange
        DivisionOperator divideOperator = new DivisionOperator();
        //Act
        var ex = Assert.Throws<DivideByZeroException>(() => divideOperator.Calculate(first, second));
        //Assert
        Assert.Equal(ex.Message, "Attempted to divide by zero.");
    }
}
