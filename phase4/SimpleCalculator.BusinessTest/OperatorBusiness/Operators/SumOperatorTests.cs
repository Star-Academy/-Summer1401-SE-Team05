using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusiness.Operators;

public class SumOperatorTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 4, 7)]
    [InlineData(-45, 111, 66)]
    [InlineData(int.MaxValue, 1, int.MinValue)]
    public void SumOperator_AddNumbers_ReturnAdditionResult(int first, int second, int expected)
    {
        //Arrange
        SumOperator sumOperator = new SumOperator();
        //Act
        var result = sumOperator.Calculate(first, second);
        //Assert
        result.Should().Be(expected);
    }
}