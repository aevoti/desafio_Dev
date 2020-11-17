using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiAlunos.IntegrationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ApiAlunos.IntegrationTests
{

    public class AlunoTests : IntegrationTest
    {

        #region GET

        [Fact]
        public async Task Get_AllAlunos_ReturnsOk()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var response = await client.GetAsync("/api/Alunos");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            string json = await response.Content.ReadAsStringAsync();
            var array = JArray.Parse(json);
            array.HasValues.Should().BeTrue();
            array.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public async Task Get_ExistingAlunosWithFilter_ReturnsOk()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var response = await client.GetAsync("/api/Alunos?Nome=Corban");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            string json = await response.Content.ReadAsStringAsync();
            var array = JArray.Parse(json);
            array.HasValues.Should().BeTrue();
            array.Should().OnlyHaveUniqueItems();
            array.Should().ContainSingle();
        }


        [Fact]
        public async Task Get_NonExistingAlunosWithFilter_ReturnsOk()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var response = await client.GetAsync("/api/Alunos?Nome=asdfsdlkafhsduifhasduifhsdui");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            string json = await response.Content.ReadAsStringAsync();
            var array = JArray.Parse(json);
            array.Should().BeEmpty();
        }

        #endregion

        #region POST

        [Fact]
        public async Task Post_ValidAluno_ReturnsCreated()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
                Nome = "Nome aluno success",
                Email = "Email aluno success"
            });
            var response = await client.PostAsync("/api/Alunos", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
            json["id"].Should().NotBeNull();
            json["nome"].Should().NotBeNull();
            json["email"].Should().NotBeNull();
        }

        [Fact]
        public async Task Post_NamelessAluno_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
                Email = "Email aluno badrequest"
            });
            var response = await client.PostAsync("/api/Alunos", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_EmaillessAluno_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
                Nome = "Nome aluno badrequest"
            });
            var response = await client.PostAsync("/api/Alunos", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_EmptyAluno_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
            });
            var response = await client.PostAsync("/api/Alunos", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        #endregion


        #region PUT

        [Fact]
        public async Task Put_ValidAluno_ReturnsNoContent()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
                Nome = "Nome aluno success",
                Email = "Email aluno success"
            });
            var response = await client.PutAsync("/api/Alunos/1", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }


        [Fact]
        public async Task Put_NamelessAluno_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
                Email = "Email aluno badrequest"
            });
            var response = await client.PutAsync("/api/Alunos/1", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_EmaillessAluno_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
                Nome = "Nome aluno badrequest"
            });
            var response = await client.PutAsync("/api/Alunos/1", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_EmptyAluno_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
            });
            var response = await client.PutAsync("/api/Alunos/1", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_InvalidAlunoId_ReturnsNotFound()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            // Act
            var newAluno = JsonConvert.SerializeObject(new
            {
                Nome = "Nome aluno not found",
                Email = "Email aluno not found"
            });
            var response = await client.PutAsync("/api/Alunos/312313", new StringContent(newAluno, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion

        #region DELETE

        [Fact]
        public async Task Delete_ValidAluno_ReturnsNoContent()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            var response = await client.DeleteAsync("/api/Alunos/1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Delete_InvalidAluno_ReturnsNotFound()
        {
            // Arrange
            var client = _factory.RebuildDb().CreateClient();

            var response = await client.DeleteAsync("/api/Alunos/312312321");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion

    }
}
