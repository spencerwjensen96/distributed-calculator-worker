using distributed_calculator.Controllers;
using Emmersion.Http;
using HttpMethod = Emmersion.Http.HttpMethod;
using HttpRequest = Emmersion.Http.HttpRequest;

namespace distributed_calculator.Registration;

public interface IRegistrationService
{
    public Task<RegistrationResult> RegisterAsync(RegistrationRequest registrationRequest);
}

public class RegistrationService : IRegistrationService
{
    private readonly IHttpClient _httpClient;

    public RegistrationService(IHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RegistrationResult> RegisterAsync(RegistrationRequest registrationRequest)
    {
        var request = new HttpRequest
        {
            Url = registrationRequest.URL,
            Method = HttpMethod.POST,
            Body = "{" +
                   $"\"workerId\":\"{registrationRequest.WorkerId}\"," +
                   $"\"createJobEndpoint\":\"{registrationRequest.CreateJobEndpoint}\"," +
                   $"\"errorCheckEndpoint\":\"{registrationRequest.ErrorCheckEndpoint}\"," +
                   $"\"teamName\":\"{registrationRequest.TeamName}\"" +
                   "}"
        };
        var response = await _httpClient.ExecuteAsync(request);
        if (response?.StatusCode != 200)
        {
            throw new Exception("Something went wrong in the registration process.");
        }

        var returnResponse = new RegistrationResult(response.Body);
        return returnResponse;
    }
}