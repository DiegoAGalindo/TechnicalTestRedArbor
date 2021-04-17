using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechnicalTestRedArbor.Models;
using TechnicalTestRedArbor.Tests.Attributes;
using Xunit;

namespace TechnicalTestRedArbor.Tests
{
    [TestCaseOrderer("TechnicalTestRedArbor.Tests.Orderers.PriorityOrderer", "TechnicalTestRedArbor.Tests")]
    public class EmployeesControllerTests
    {
        public static int TestId;

        [Fact, TestPriority(1)]
        public void Test1Post()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/EmployeesController-Post.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);

            var context = new TestLambdaContext();
            var response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            Assert.IsType<int>(Convert.ToInt32(response.Body));
            TestId = Convert.ToInt32(response.Body);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

        [Fact, TestPriority(2)]
        public void Test2Get()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/EmployeesController-Get.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            var response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            var employees = JsonConvert.DeserializeObject<List<ResponseEmployee>>(response.Body);
            Assert.True(employees != null && employees.Any(p => p.Id == TestId));
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

        [Fact, TestPriority(3)]
        public void Test3GetById()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/EmployeesController-GetById.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var Path = $"api/redarbor/{TestId}";
            request.PathParameters = new Dictionary<string, string>
            {
                {"proxy", Path}
            };
            request.Path = Path;

            var context = new TestLambdaContext();

            var response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            var employee = JsonConvert.DeserializeObject<ResponseEmployee>(response.Body);
            Assert.True(employee != null && employee.Id == TestId);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

        [Fact, TestPriority(4)]
        public void Test4Put()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/EmployeesController-Put.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var Path = $"api/redarbor/{TestId}";
            request.PathParameters = new Dictionary<string, string>
            {
                {"proxy", Path}
            };
            request.Path = Path;
            var context = new TestLambdaContext();
            var response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
        }

        [Fact, TestPriority(5)]
        public void Test5GetById()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/EmployeesController-GetById.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var Path = $"api/redarbor/{TestId}";
            request.PathParameters = new Dictionary<string, string>
            {
                {"proxy", Path}
            };
            request.Path = Path;

            var context = new TestLambdaContext();

            var response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            var employee = JsonConvert.DeserializeObject<ResponseEmployee>(response.Body);
            Assert.True(employee != null && employee.Id == TestId);
            Assert.True(employee != null && employee.Username == "test1updated");
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

        [Fact, TestPriority(6)]
        public void Test6Delete()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/EmployeesController-Delete.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var Path = $"api/redarbor/{TestId}";
            request.PathParameters = new Dictionary<string, string>
            {
                {"proxy", Path}
            };
            request.Path = Path;

            var context = new TestLambdaContext();

            var response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
        }

        [Fact, TestPriority(7)]
        public void Test7GetById()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/EmployeesController-GetById.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var Path = $"api/redarbor/{TestId}";
            request.PathParameters = new Dictionary<string, string>
            {
                {"proxy", Path}
            };
            request.Path = Path;

            var context = new TestLambdaContext();

            var response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(204, response.StatusCode);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
        }
    }
}