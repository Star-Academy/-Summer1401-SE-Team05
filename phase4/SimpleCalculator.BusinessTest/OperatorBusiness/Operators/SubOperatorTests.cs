using FluentAssertions;
using NSubstitute;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusiness.Operators;

public class SubOperatorTests
{
    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(3, 4, -1)]
    [InlineData(-45, 111, -156)]
    [InlineData(int.MaxValue, -1, int.MinValue)]
    public void SubOperator_SubtractNumbers_ReturnSubtractionResult(int first, int second, int expected)
    {
        //Arrange
        SubOperator subOperator = new SubOperator();
        //Act
        var result = subOperator.Calculate(first, second);
        //Assert
        result.Should().Be(expected);
    }
}