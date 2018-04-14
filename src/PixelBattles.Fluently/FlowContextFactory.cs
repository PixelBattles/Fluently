using PixelBattles.Fluently.Context;
using System.Collections.Generic;

namespace PixelBattles.Fluently
{
    public class FlowContextFactory
    {
        public static IEnumerable<object[]> CreateFlowContext() => new[] { new[] { new FlowContext() } };
    }
}
