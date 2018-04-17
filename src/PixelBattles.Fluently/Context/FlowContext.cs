using System;
using System.Collections.Generic;

namespace PixelBattles.Fluently.Context
{
    public class FlowContext : IFlowContext
    {
        protected Dictionary<string, object> Values;

        public FlowContext()
        {
            Values = new Dictionary<string, object>();
        }

        public IAssertContext Assert()
        {
            return new AssertContext(this);
        }

        public IValueContext<TValue> Get<TValue>(string key)
        {
            return new ValueContext<TValue>(this, (TValue)Values[key]);
        }
        
        public IValueContext<TValue> Get<TValue>()
        {
            string key = typeof(TValue).Name;
            return Get<TValue>(key);
        }

        public IFlowContext Set<TValue>(string key, TValue value)
        {
            Values[key] = value;
            return this;
        }

        public IFlowContext Set<TValue>(TValue value)
        {
            return Set(typeof(TValue).Name, value);
        }

        public IValueContext<TValue> Setup<TValue>(Func<TValue> generator)
        {
            return Setup(generator());
        }

        public IValueContext<TValue> Setup<TValue>(Func<IFlowContext, TValue> generator)
        {
            return Setup(generator(this));
        }
        
        public IValueContext<TValue> Setup<TValue>(TValue value)
        {
            return new ValueContext<TValue>(this, value);
        }
    }
}
