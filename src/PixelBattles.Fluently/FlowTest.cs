using PixelBattles.Fluently.Context;
using System;

namespace PixelBattles.Fluently
{
    public abstract class FlowTest : IDisposable
    {
        protected IFlowContext FlowContext;

        public FlowTest()
        {
            this.FlowContext = new FlowContext();
        }

        public void Dispose()
        {
        }
    }
}
