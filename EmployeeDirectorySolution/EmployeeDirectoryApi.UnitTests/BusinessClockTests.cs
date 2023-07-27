using Microsoft.AspNetCore.Authentication;
using Moq;

namespace EmployeeDirectoryApi.UnitTests
{
    public class BusinessClockTests
    {
        [Fact]
        public void ClosedBeforeNine()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(x => x.GetCurrent()).Returns(new DateTime(2023, 7, 23, 10, 5, 23));
            IProvideTheBusinessClock standardBusinessClock = new StandardBusinessClock(stubbedClock.Object);



            Assert.True(standardBusinessClock.AreWeOpen());
        }



        [Fact]
        public void OpenAtNine()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(x => x.GetCurrent()).Returns(new DateTime(2023, 7, 23, 6, 5, 23));
            IProvideTheBusinessClock standardBusinessClock = new StandardBusinessClock(stubbedClock.Object);



            Assert.False(standardBusinessClock.AreWeOpen());
        }
    }
}