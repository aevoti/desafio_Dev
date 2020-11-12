using Alunos.Application.UseCases;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.UnitTests.Application
{
    public class SortTypeUtilTests
    {
        [Theory]
        [InlineData("ID_ASC", SortType.ORDER_BY_ID_ASC)]
        [InlineData("ID_DEC", SortType.ORDER_BY_ID_DEC)]
        [InlineData("NOME_ASC", SortType.ORDER_BY_NOME_ASC)]
        [InlineData("NOME_DEC", SortType.ORDER_BY_NOME_DEC)]
        [InlineData("otherStr", SortType.ORDER_BY_ID_ASC)]
        [InlineData("", SortType.ORDER_BY_ID_ASC)]
        [InlineData(null, SortType.ORDER_BY_ID_ASC)]
        public void FromString_ShouldReturnExpectedValue(string sortTypeStr, SortType expectedResult)
        {
            var sortType = SortTypeUtil.FromString(sortTypeStr);

            sortType.Should().BeOfType<SortType>();
            sortType.Should().Be(expectedResult);
        }
    }
}
