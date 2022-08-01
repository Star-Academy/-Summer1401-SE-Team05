using FluentAssertions;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusiness;

public class OperatorProviderTests
{
    [Theory]
    [InlineData(OperatorEnum.sum, typeof(SumOperator))]
    [InlineData(OperatorEnum.division, typeof(DivisionOperator))]
    [InlineData(OperatorEnum.sub, typeof(SubOperator))]
    [InlineData(OperatorEnum.multiply, typeof(MultiplyOperator))]
    public void Test_OperatorProvider_ReturnsCorrectOperator(OperatorEnum operatorType, Type type)
    {
        //Arrange
        OperatorProvider operatorProvider = new OperatorProvider();
        //Act
        var result = operatorProvider.GetOperator(operatorType);
        //Assert
        result.Should().BeOfType(type);
    }

    // [Fact]
    // public void Test_nullException()
    // {
    //     //Arrange
    //     OperatorProvider operatorProvider = new OperatorProvider();
    //     //Act
    //     var result = operatorProvider.GetOperator(null);
    //     //Assert
    //     result.Should().BeOfType(type);
    // }
}