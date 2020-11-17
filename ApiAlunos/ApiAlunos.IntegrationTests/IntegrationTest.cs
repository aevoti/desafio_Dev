using System;
using System.Net.Http;
using ApiAlunos.Infrastructure.Context;
using ApiAlunos.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace ApiAlunos.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>().BuildApplicationFactory();
            _factory = appFactory;
        }
    }
}
