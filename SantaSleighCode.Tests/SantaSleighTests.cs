using Xunit;
using FluentAssertions;

namespace SantaSleighCode.Tests
{
    public class SantaSleighTests
    {
        [Fact]
        public void GetDirection_Default_FacingNorth()
        {
            var sut = new SantaSleigh();

            var result = sut.GetDirection();

            result.Should().Be("N");
        }
    }
}
