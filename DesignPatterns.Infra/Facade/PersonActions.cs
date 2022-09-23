using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Infra.Facade
{
    public class PersonActions : IPersonActions
    {
        private readonly BankOptions _bankOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPersonRepository _personRepository;
        public PersonActions(IOptionsMonitor<BankOptions> optionsMonitor, IHttpClientFactory httpClientFactory, IPersonRepository personRepository)
        {
            _bankOptions = optionsMonitor.CurrentValue;
            _httpClientFactory = httpClientFactory;
            _personRepository = personRepository;
        }
        public async Task DepositMoney(Guid personId)
        {
            // Get person from mock repository
            var person = _personRepository.GetById(personId);

            // Create the deposit model
            var requestModel = new DepositMoney()
            {
                ClientName = person.FirstName + " " + person.LastName,
                TotalAmount = 1000,
                TransactionDate = DateTime.Now,
                TransactionNumber = _bankOptions.TransactionNumber,
            };

            // Create and configure HttpClient
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_bankOptions.BaseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Convert to Json
            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Post the data on the Mock API
            await client.PostAsync(_bankOptions.DepositURI, contentString);
        }
    }
}
