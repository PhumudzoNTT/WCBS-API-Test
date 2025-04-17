using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Common
{
    public class BaseTest : PlaywrightTest
    {
        public IAPIRequestContext Request;
        protected readonly IConfiguration _configuration;
        protected AppSettings _appSettings = new();
        protected string authToken;
        protected HttpClient _httpClient;

        public BaseTest()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();

            _configuration.GetSection(AppSettings.BaseSettings).Bind(_appSettings);
            _configuration.GetSection("LoginSettingsSection").Bind(_appSettings.LoginSettingsSection);

            _configuration.Should().NotBeNull();
        }

        [SetUp]
        public async Task Setup()
        {
            Request = await this.Playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = _appSettings.BaseUrl,
                IgnoreHTTPSErrors = true,
                Timeout = 60000
            });

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_appSettings.BaseUrl)
            };

            authToken = await GetAuthTokenAsync();
        }

        protected async Task<string> GetAuthTokenAsync()
        {
            try
            {
                var payload = string.Format(@"{{
                    ""email"": ""{0}"",
                    ""sharedSecret"": ""{1}""
                }}", _appSettings.LoginSettingsSection.Email, _appSettings.LoginSettingsSection.SharedSecret);

                var loginResponse = await Request.PostAsync(
                    "/api/V1/Account/Token/OnBehalfOf/Email",
                    new APIRequestContextOptions
                    {
                        Data = payload,
                        Headers = new Dictionary<string, string>
                        {
                            { "Content-Type", "application/json" }
                        }
                    });

                var responseBody = await loginResponse.JsonAsync();
                var token = responseBody?.GetProperty("token").GetString();

                token.Should().NotBeNullOrEmpty("Token was not returned in response");
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get auth token: {ex.Message}", ex);
            }
        }

        [TearDown]
        public async Task Teardown()
        {
            if (Request != null)
            {
                await Request.DisposeAsync();
            }
            _httpClient?.Dispose();
        }
    }

    public class AppSettings
    {
        public const string BaseSettings = "BaseSettings";
        public string BaseUrl { get; set; } = BaseSettings;
        public LoginSettings LoginSettingsSection { get; set; } = new();
    }

    public class LoginSettings
    {
        public string Email { get; set; } = string.Empty;
        public string SharedSecret { get; set; } = string.Empty;
    }
}