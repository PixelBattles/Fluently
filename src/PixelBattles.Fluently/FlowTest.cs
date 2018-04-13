using PixelBattles.Fluently.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBattles.Fluently
{
    public abstract class FlowTest
    {
        public abstract IFlowContext Run(IFlowContext context);
    }
}
