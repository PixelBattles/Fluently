using System;

namespace PixelBattles.Fluently.Context
{
    public interface IAssertContext
    {
        IFlowContext Equals<TValue>(Func<IFlowContext, TValue> extractor, TValue expected);
    }
}
