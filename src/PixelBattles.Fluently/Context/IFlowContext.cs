using System;

namespace PixelBattles.Fluently.Context
{
    public interface IFlowContext
    {
        IValueContext<TValue> Get<TValue>(string key);

        IValueContext<TValue> Get<TValue>();
        
        IFlowContext Set<TValue>(string key, TValue value);

        IFlowContext Set(string key, object value);

        IValueContext<TValue> Setup<TValue>(Func<TValue> generator);

        IValueContext<TValue> Setup<TValue>(Func<IFlowContext, TValue> generator);
                
        IValueContext<TValue> Setup<TValue>(TValue value);

        IAssertContext Assert();
    }
}
