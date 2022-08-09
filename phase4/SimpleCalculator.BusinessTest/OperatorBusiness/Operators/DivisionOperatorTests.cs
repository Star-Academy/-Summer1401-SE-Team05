using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusiness.Operators;

public class DivisionOperatorTests
{
    [Theory]
    [InlineData(1, 2, 1/2)]
    [InlineData(-45, 111, -45/111)]
    public void DivisionOperator_DivideNumbers_ReturnDividedResult(int dividend, int divisor, int expected)
    {
        //Arrange
        var divideOperator = new DivisionOperator();
        //Act
        var result = divideOperator.Calculate(dividend, divisor);
        //Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(3, 0)]
    [InlineData(0, 0)]
    public void DivisionOperator_DivideByZero_ThrowDivideByZeroException(int dividend, int divisor)
    {
        //Arrange
        var divideOperator = new DivisionOperator();
        //Act
        
        var ex = Assert.Throws<DivideByZeroException>(() => divideOperator.Calculate(dividend, divisor));
        //Assert
        Assert.Equal(ex.Message, "Attempted to divide by zero.");
    }
}
