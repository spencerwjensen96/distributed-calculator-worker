using distributed_calculator.Controllers;
using distributed_calculator.ErrorCheck;
using Emmersion.Testing;
using NUnit.Framework;

namespace UnitTests.ErrorCheck;

public class ErrorCheckServiceTests : With_an_automocked<ErrorCheckService>
{
    [Test]
    public void When_reporting_an_error()
    {
        var errorCheckRequest = new ErrorCheckRequest();
        GetMock<IErrorCheckRepository>().Setup(x => x.Execute());
    }
}