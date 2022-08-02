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
    [InlineData(3, 4, 12)]
    [InlineData(-45, 111, -4995)]
    public void MultiplyOperator_MultiplyNumbers_ReturnMultiplicationResult(int first, int second, int expected)
    {
        //Arrange
        MultiplyOperator multiplyOperator = new MultiplyOperator();
        //Act
        var result = multiplyOperator.Calculate(first, second);
        //Assert
        result.Should().Be(expected);
    }
}