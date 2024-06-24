using GildedRoseKata;
using System;
using System.IO;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace GildedRoseTests
{
    [Collection("WriterSequential")]
    public class ApprovalTest : IDisposable
    {
        private readonly StringWriter consoleOutput;

        public ApprovalTest()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        public void Dispose()
        {
            consoleOutput.Dispose();
            Console.SetOut(Console.Out);
        }

        [Fact]
        public Task ThirtyDays()
        {
            Program.Main(new string[] { "30" });
            var output = consoleOutput.ToString();

            return Verifier.Verify(output);
        }
    }
}