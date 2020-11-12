using Alunos.Application.UseCases;
using Alunos.Application.UseCases.Update;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.UnitTests.Application
{
    public class UpdateAlunoValidatorTests
    {
        private const string SOME_110_CHARS_STRING = @"TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTE";

        [Theory]
        [InlineData("abc@example.com", "Some Cool Name", 10,true)]
        [InlineData("abc@example.com", "Some Name", 10, true)]
        [InlineData("abc@example.com", "Some Name", 0, false)]
        [InlineData("abc@example.com", "Some Name", -10, false)]
        [InlineData("abc@example.com", "Some", 10, false)]
        [InlineData("abc@example.com", "S m", 10, false)]
        [InlineData("abc@example.com", SOME_110_CHARS_STRING, 10, false)]
        [InlineData("@example.com", "Some Name", 10, false)]
        [InlineData("abc@", "Some Name", 10, false)]
        [InlineData("example", "Some Name", 10, false)]
        [InlineData("", "Some Name", 10, false)]
        [InlineData(null, "Some Name", 10, false)]
        [InlineData("abc@example.com", "", 10, false)]
        [InlineData("abc@example.com", null, 10, false)]
        public void ValidationShouldReturnExpectedValue(string email, string nome, int id, bool expectedResult)
        {
            var validator = new UpdateAlunoValidator();
            var request = new UpdateAluno() { Email = email, Nome = nome, AlunoId = id };

            var result = validator.Validate(request);

            result.IsValid.Should().Be(expectedResult);
        }
    }
}
