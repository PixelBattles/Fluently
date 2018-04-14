using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBattles.Fluently.Context.Generic
{
    public interface IValueContext<TValue>
    {
        TValue Value { get; set; }
        IValueContext<TValue> Save();
        IValueContext<TValue> Save(string destination);
        IFlowContext Continue();
        IValueContext<TAnotherValue> As<TAnotherValue>();
        IValueContext<TValue> With(Action<TValue> action);
        IValueContext<TAnotherValue> Transform<TAnotherValue>(Func<TValue,TAnotherValue> transformator);
        IValueContext<TAnotherValue> Transform<TAnotherValue>(Func<IFlowContext, TValue, TAnotherValue> transformator);
    }
}