using PixelBattles.Fluently.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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

        //[Theory]
        //[MemberData(nameof(FlowContextFactory.CreateFlowContext), MemberType = typeof(FlowContextFactory))]
        //public abstract IFlowContext Run(IFlowContext context);
    }
}
