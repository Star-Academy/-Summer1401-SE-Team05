using FluentAssertions;
using NSubstitute;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusiness.Operators;

public class MultiplyOperatorTests
{
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(-45, 111, -4995)]
    public void MultiplyOperator_MultiplyNumbers_ReturnMultiplicationResult(int multiplicand, int multiplier, int expected)
    {
        //Arrange
        var multiplyOperator = new MultiplyOperator();
        //Act
        var result = multiplyOperator.Calculate(multiplicand, multiplier);
        //Assert
        result.Should().Be(expected);
    }
}