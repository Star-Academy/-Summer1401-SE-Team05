using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusiness.Operators;

public class SumOperatorTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(int.MaxValue, 1, int.MinValue)]
    public void SumOperator_AddNumbers_ReturnAdditionResult(int firstToAdd, int secondToAdd, int expected)
    {
        //Arrange
        var sumOperator = new SumOperator();
        //Act
        var result = sumOperator.Calculate(firstToAdd, secondToAdd);
        //Assert
        result.Should().Be(expected);
    }
}