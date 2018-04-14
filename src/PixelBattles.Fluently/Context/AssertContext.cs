using System;
using Xunit;

namespace PixelBattles.Fluently.Context
{
    public class AssertContext : IAssertContext
    {
        private IFlowContext flowContext;
        public AssertContext(IFlowContext flowContext)
        {
            this.flowContext = flowContext;
        }

        public IFlowContext Equals<TValue>(Func<IFlowContext, TValue> extractor, TValue expected)
        {
            Assert.Equal(expected, extractor(flowContext));
            return flowContext;
        }
    }
}
