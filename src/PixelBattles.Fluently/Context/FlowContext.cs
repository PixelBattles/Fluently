using System;
using System.Collections.Generic;

namespace PixelBattles.Fluently.Context
{
    public class FlowContext : IFlowContext
    {
        protected Dictionary<string, object> values = new Dictionary<string, object>();

        public IAssertContext Assert()
        {
            return new AssertContext(this);
        }

        public IValueContext<TValue> Get<TValue>(string key)
        {
            return new ValueContext<TValue>(this, (TValue)values[key]);
        }
        
        public IValueContext<TValue> Get<TValue>()
        {
            string key = typeof(TValue).Name;
            return Get<TValue>(key);
        }

        public IFlowContext Set<TValue>(string key, TValue value)
        {
            values[key] = value;
            return this;
        }

        public IFlowContext Set(string key, object value)
        {
            values[key] = value;
            return this;
        }
        
        public IValueContext<TValue> Setup<TValue>(Func<TValue> generator)
        {
            throw new NotImplementedException();
        }

        public IValueContext<TValue> Setup<TValue>(Func<IFlowContext, TValue> generator)
        {
            return new ValueContext<TValue>(this, generator(this));
        }
        
        public IValueContext<TValue> Setup<TValue>(TValue value)
        {
            return new ValueContext<TValue>(this, value);
        }
    }
}
