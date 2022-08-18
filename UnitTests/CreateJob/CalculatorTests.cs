using System;
using System.Threading.Tasks;
using distributed_calculator.CreateJob;
using Emmersion.Testing;
using NUnit.Framework;

namespace UnitTests.CreateJob;

public class CalculatorTests: With_an_automocked<Calculator>
{
    [Test]
    public async Task When_calculating_request()
    {
        var calulation = "CALCULATE: " + RandomString();

        var result = await ClassUnderTest.Calculate(calulation);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(result));
    }
    [TestCase("CALCULATE: 2 + 2", "4")]
    [TestCase("CALCULATE: 2 - 2", "0")]
    [TestCase("CALCULATE: 2 * 2", "4")]
    [TestCase("CALCULATE: 2 / 2", "1")]
    [TestCase("CALCULATE: (77 - 7) / 7", "10")]
    [Test]
    public async Task When_calculating_request_example_math_problems(String calculation, String expectation)
    {
        var result = await ClassUnderTest.Calculate(calculation);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(expectation));
    }
    [Test]
    public void When_the_calculation_request_has_unknown_command()
    {
        var calculation = "FACTOR: " + RandomString();

        var exception = Assert.ThrowsAsync<Exception>(() => ClassUnderTest.Calculate(calculation));
        
        Assert.That(exception.Message, Does.Contain("Unknown calculation command."));
    }
    [Test]
    public void When_the_calculation_request_is_null()
    {
        var exception = Assert.ThrowsAsync<NullReferenceException>(() => ClassUnderTest.Calculate(null));
        
        Assert.That(exception.Message, Does.Contain("Calculation cannot be null"));
    }
}