using System;
using System.Threading.Tasks;
using distributed_calculator.Controllers;
using distributed_calculator.Registration;
using Emmersion.Http;
using Emmersion.Testing;
using Moq;
using NUnit.Framework;

using HttpMethod = Emmersion.Http.HttpMethod;
using HttpRequest = Emmersion.Http.HttpRequest;

namespace UnitTests.Registration;

public class RegistrationServiceTests : With_an_automocked<RegistrationService>
{
    [Test]
    public async Task When_registration_request_succeeds()
    {
        var registrationRequest =
            new RegistrationRequest(RandomString(), NewGuid(), RandomString(), RandomString(), RandomString());
        var request = new HttpRequest();
        var expected = new HttpResponse(statusCode: 200, new HttpHeaders(), RandomString());
        GetMock<IHttpClient>()
            .Setup(x => x.ExecuteAsync(IsAny<HttpRequest>()))
            .Callback<IHttpRequest>(r => request = r as HttpRequest)
            .ReturnsAsync(expected);

        var result = await ClassUnderTest.RegisterAsync(registrationRequest);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.Not.Null);
    }
    
    [Test]
    public Task When_registration_request_fails()
    {
        var registrationRequest =
            new RegistrationRequest(RandomString(), NewGuid(), RandomString(), RandomString(), RandomString());
        var expected = new HttpResponse(statusCode: 500, new HttpHeaders(), RandomString());
        GetMock<IHttpClient>()
            .Setup(x => x.ExecuteAsync(IsAny<HttpRequest>()))
            .Callback<IHttpRequest>(r => { })
            .ReturnsAsync(expected);

        var exception = Assert.ThrowsAsync<Exception>(() => ClassUnderTest.RegisterAsync(registrationRequest));
        Assert.That(exception, Is.Not.Null);
        Assert.That(exception!.Message, Is.EqualTo("Something went wrong in the registration process."));
        return Task.CompletedTask;
    }
    
    [Test]
    public Task When_registration_request_fails_because_request_is_null()
    {
        var expected = new HttpResponse(statusCode: 500, new HttpHeaders(), RandomString());
        GetMock<IHttpClient>()
            .Setup(x => x.ExecuteAsync(IsAny<HttpRequest>()))
            .Callback<IHttpRequest>(r => { })
            .ReturnsAsync(expected);

        Assert.ThrowsAsync<NullReferenceException>(() => ClassUnderTest.RegisterAsync(null));
        return Task.CompletedTask;
    }
}