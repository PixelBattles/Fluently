using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBattles.Fluently.Context.Generic
{
    public class ValueContext<TValue> : IValueContext<TValue>
    {
        public ValueContext(IFlowContext flowContext, TValue value)
        {
            this.Value = value;
            this.flowContext = flowContext;
        }

        public ValueContext(IFlowContext flowContext, TValue value, string destination) : this(flowContext, value)
        {
            this.Destination = destination;
        }

        private IFlowContext flowContext;

        public TValue Value { get; set; }
        
        public string Destination { get; set; }

        public IFlowContext Save()
        {
            throw new NotImplementedException();
        }

        public IFlowContext Save(string destination)
        {
            return flowContext.Set(destination, Value);
        }

        public IValueContext<TAnotherValue> As<TAnotherValue>()
        {
            throw new NotImplementedException();
        }

        public IValueContext<TAnotherValue> Transform<TAnotherValue>(Func<TValue, TAnotherValue> transformator)
        {
            throw new NotImplementedException();
        }

        public IValueContext<TAnotherValue> Transform<TAnotherValue>(Func<IFlowContext, TValue, TAnotherValue> transformator)
        {
            throw new NotImplementedException();
        }
    }
}
