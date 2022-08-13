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
    [InlineData(1, 2, 4, OperatorEnum.sum)]
    public void SimpleCalculatorCalculate_CalculateAnswerCorrectly_AddNumbers(int first, int second, int expected, OperatorEnum operatorType)
    {
        //Arrange
        var mockedOperator = Substitute.For<IOperator>();
        mockedOperator.Calculate(Arg.Is(first), Arg.Is(second)).Returns(expected);
        _operatorProvider.GetOperator(Arg.Is(operatorType)).Returns(mockedOperator);
        var calculator = new Calculator(_operatorProvider);
        //Act
        var result = calculator.Calculate(first, second, operatorType);

        //Assert
        result.Should().Be(expected);
    }
}