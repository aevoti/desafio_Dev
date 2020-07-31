using Alunos.Application.UseCases;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.UnitTests.Application
{
    public class RegisterAlunoValidatorTests
    {
        private const string SOME_110_CHARS_STRING = @"TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTE";

        [Theory]
        [InlineData("abc@example.com", "Some Cool Name", true)]
        [InlineData("abc@example.com", "Some Name", true)]
        [InlineData("abc@example.com", "Some", false)]
        [InlineData("abc@example.com", "S m", false)]
        [InlineData("abc@example.com", SOME_110_CHARS_STRING, false)]
        [InlineData("@example.com", "Some Name", false)]
        [InlineData("abc@", "Some Name", false)]
        [InlineData("example", "Some Name", false)]
        [InlineData("", "Some Name", false)]
        [InlineData(null, "Some Name", false)]
        [InlineData("abc@example.com", "", false)]
        [InlineData("abc@example.com", null, false)]
        public void ValidationShouldReturnExpectedValue(string email, string nome, bool expectedResult)
        {
            var validator = new RegisterAlunoValidator();
            var request = new RegisterAluno() { Email = email, Nome = nome };

            var result = validator.Validate(request);

            result.IsValid.Should().Be(expectedResult);
        }
    }
}
