using System;

namespace PixelBattles.Fluently.Context
{
    public interface IValueContext<TValue>
    {
        TValue Value { get; set;  } 

        IValueContext<TValue> Save();

        IValueContext<TValue> Save(string destination);
        
        IValueContext<TValue> With(Action<TValue> action);

        IValueContext<TAnotherValue> Select<TAnotherValue>(Func<TValue, TAnotherValue> transformator);

        IValueContext<TAnotherValue> Select<TAnotherValue>(Func<IFlowContext, TValue, TAnotherValue> transformator);

        IValueAssertContext<TValue> Assert();

        IFlowContext Continue();
    }
}