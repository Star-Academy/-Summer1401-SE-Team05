using FluentAssertions;
using NSubstitute;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;

namespace SimpleCalculator.Test;

public class SimpleCalculatorTests
{
    private readonly IOperatorProvider _operatorProvider;

    public SimpleCalculatorTests()
    {
        _operatorProvider = Substitute.For<IOperatorProvider>();
        
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void Calculate_true_Answer(int first, int second, int expected)
    {
        //Arrange
        Calculator calculator = new Calculator(_operatorProvider);
        var operatorType = OperatorEnum.sum;
        var mockedOperator = Substitute.For<IOperator>();
        mockedOperator.Calculate(Arg.Any<int>(), Arg.Any<int>()).Returns(expected);
        _operatorProvider.GetOperator(Arg.Any<OperatorEnum>()).Returns(mockedOperator);
        //Act
        var result = calculator.Calculate(first, second, operatorType);

        //Assert
        result.Should().Be(expected);
    }
}