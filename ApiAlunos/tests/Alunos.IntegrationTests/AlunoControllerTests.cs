using Alunos.Application.UseCases;
using Alunos.Application.ViewModels;
using Alunos.IntegrationTests.Fixture;
using ApiAlunos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alunos.IntegrationTests
{
    public class AlunoControllerTests :
        IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AlunoControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetById_GivenValidId_ReturnsOkResponseAndAluno()
        {
            var response = await _client.GetAsync("/api/Alunos/5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeTrue();

            var aluno = responseJson["data"].ToObject<AlunoViewModel>();

            aluno.Should().NotBeNull();
            aluno.AlunoId.Should().Be(5);
        }

        [Fact]
        public async Task GetById_GivenNonExistingId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/Alunos/9999");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAlunos_ReturnsOkAndAlunoList()
        {
            var response = await _client.GetAsync("/api/Alunos");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeTrue();

            var alunos = responseJson["data"].ToObject<PaginatedList<AlunoViewModel>>();

            alunos.Should().NotBeNull();
            alunos.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAlunos_GivenInvalidPage_ReturnsOkAndEmptyList()
        {
            var response = await _client.GetAsync("/api/Alunos?page=1000");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeTrue();

            var alunos = responseJson["data"].ToObject<PaginatedList<AlunoViewModel>>();

            alunos.Should().NotBeNull();
            alunos.Items.Should().BeEmpty();
        }

        [Fact]
        public async Task Post_GivenValidAluno_ReturnsOk()
        {
            var request = new RegisterAluno() 
            {
                Email = "abc@example.com",
                Nome = "Some Nome"
            };

            var myContent = JsonConvert.SerializeObject(request);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var response = await _client.PostAsync("/api/Alunos", byteContent);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeTrue();
        }

        [Fact]
        public async Task Post_GivenInvalidAluno_ReturnsBadRequestAndErrors()
        {
            var request = new RegisterAluno() 
            {
                Email = "abc@example.com",
                Nome = "Some Nome"
            };

            var myContent = JsonConvert.SerializeObject(request);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var response = await _client.PostAsync("/api/Alunos", byteContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeFalse();
            responseJson["errors"].ToObject<List<string>>().Should().NotBeEmpty();
        }

        [Fact]
        public async Task Put_GivenValidAluno_ReturnsOk()
        {
            var request = new UpdateAluno()
            {
                Email = "abc2@example.com",
                Nome = "Some Nome",
                AlunoId = 5
            };

            var myContent = JsonConvert.SerializeObject(request);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var response = await _client.PutAsync("/api/Alunos/5", byteContent);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeTrue();
        }

        [Fact]
        public async Task Put_GivenInvalidAluno_ReturnsBadRequestAndErrors()
        {
            var request = new UpdateAluno()
            {
                Email = "@example.com",
                Nome = "Some Nome",
                AlunoId = 5
            };

            var myContent = JsonConvert.SerializeObject(request);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var response = await _client.PutAsync("/api/Alunos/5", byteContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeFalse();
            responseJson["errors"].ToObject<List<string>>().Should().NotBeEmpty();
        }

        [Fact]
        public async Task Put_GivenNonExistingId_ReturnsNotFound()
        {
            var request = new UpdateAluno()
            {
                Email = "abc@example.com",
                Nome = "Some Nome",
                AlunoId = 5000
            };

            var myContent = JsonConvert.SerializeObject(request);

            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var response = await _client.PutAsync("/api/Alunos/5000", byteContent);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_GivenNonExistingId_ReturnsNotFound()
        {
            var response = await _client.DeleteAsync("/api/Alunos/9999");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_GivenExistingId_ReturnsOk()
        {
            var response = await _client.DeleteAsync("/api/Alunos/1");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<JObject>(stringResponse);

            responseJson.Should().NotBeNull();
            responseJson["success"].ToObject<bool>().Should().BeTrue();
        }
    }
}
