using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBattles.Fluently.Context
{
    public class ValueContext : IValueContext
    {
        public ValueContext(IFlowContext flowContext, object value)
        {
            this.Value = value;
            this.flowContext = flowContext;
        }

        public ValueContext(IFlowContext flowContext, object value, string destination) :this(flowContext, value)
        {
            this.Destination = destination;
        }

        private IFlowContext flowContext;

        public object Value { get; set; }

        public string Destination { get; set; }

        public IFlowContext Save()
        {
            return flowContext.Set(Destination, Value);
        }

        public IFlowContext Save(string destination)
        {
            this.Destination = destination;
            return flowContext.Set(Destination, Value);
        }
    }
}
