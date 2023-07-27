using Alba;
using EmployeeDirectoryApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryApi.ContractTests.OnCallDeveloper
{
    public class GettingTheOnCallDeveloper
    {
        [Fact]
        public async Task MakingTheDuringBusinessRequest()
        {
            await using var host = await AlbaHost.For<Program>(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var stubbedClock = new Mock<IProvideTheBusinessClock>();
                    stubbedClock.Setup(x => x.AreWeOpen()).Returns(true);
                    services.AddSingleton<IProvideTheBusinessClock>(stubbedClock.Object);
                });
            });
            var expectedOnCallDeveloper = new OnCallDeveloperResponseModel
            {
                Name = "Sierra",
                Email = "st@aol.com",
                PhoneNumber = "123-4567",
            };
            var responseMessage = await host.Scenario(api =>
            {
                api.Get.Url("/on-call-developer");
                api.StatusCodeShouldBeOk();
            });
            var response = responseMessage.ReadAsJson<OnCallDeveloperResponseModel>();
            Assert.Equal(expectedOnCallDeveloper,response);
        }
        [Fact]
        public async Task MakingTheAfterBusinessRequest()
        {
            await using var host = await AlbaHost.For<Program>(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var stubbedClock = new Mock<IProvideTheBusinessClock>();
                    stubbedClock.Setup(x => x.AreWeOpen()).Returns(false);
                    services.AddSingleton<IProvideTheBusinessClock>(stubbedClock.Object);
                });
            }); ;
            var expectedOnCallDeveloper = new OnCallDeveloperResponseModel
            {
                Name = "Becky",
                Email = "becky@aol.com",
                PhoneNumber = "876-5432",
            };
            var responseMessage = await host.Scenario(api =>
            {
                api.Get.Url("/on-call-developer");
                api.StatusCodeShouldBeOk();
            });
            var response = responseMessage.ReadAsJson<OnCallDeveloperResponseModel>();
            Assert.Equal(expectedOnCallDeveloper, response);
        }

    }
}
