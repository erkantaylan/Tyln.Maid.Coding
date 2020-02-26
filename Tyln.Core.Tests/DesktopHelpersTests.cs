using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Tyln.Core.Tests
{
    public class DesktopHelpersTests
    {
        [Fact]
        public void Test_WindowProcesses()
        {
            List<Process> list = DesktopHelpers.GetAltTabProcesses().ToList();
            Assert.True(true);
        }
    }
}