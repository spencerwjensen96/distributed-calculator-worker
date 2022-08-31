using System;
using System.Threading.Tasks;
using distributed_calculator.Controllers;
using distributed_calculator.CreateJob;
using distributed_calculator.Services;
using Emmersion.Testing;
using Moq;
using NUnit.Framework;

namespace UnitTests.CreateJob;

public class CreateJobServiceTests : With_an_automocked<CreateJobService>
{
    [Test]
    public async Task When_creating_a_job()
    {
        var request = new CreateJobRequest(NewGuid(), RandomString());

        var expected = new CreateJobResponse(request.JobId, "CALCULATE: " + RandomString());

        GetMock<ICalculator>().Setup(x => x.Calculate(request.Calculation)).ReturnsAsync(expected.Result);

        var result = await ClassUnderTest.CreateJob(request);
        
        Assert.That(result.JobId, Is.EqualTo(expected.JobId));
        Assert.That(result.Result, Is.EqualTo(expected.Result));
        
        GetMock<ICalculator>().Verify(x => x.Calculate(request.Calculation));
    }
}