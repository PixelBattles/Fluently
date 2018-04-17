using System;

namespace PixelBattles.Fluently.Context
{
    public class ValueContext<TValue> : IValueContext<TValue>
    {
        public ValueContext(IFlowContext flowContext, TValue value)
        {
            this.Value = value;
            this.FlowContext = flowContext;
        }

        public ValueContext(IFlowContext flowContext, TValue value, string destination) : this(flowContext, value)
        {
            this.Destination = destination;
        }

        protected IFlowContext FlowContext;

        public TValue Value { get; set; }

        protected string Destination { get; set; }

        public IValueContext<TValue> Save()
        {
            if (String.IsNullOrEmpty(Destination))
            {
                Destination = typeof(TValue).Name;
            }

            FlowContext.Set(Destination, Value);
            return this;
        }

        public IValueContext<TValue> Save(string destination)
        {
            Destination = destination;
            return Save();
        }
        
        public IValueContext<TAnotherValue> Select<TAnotherValue>(Func<TValue, TAnotherValue> transformator)
        {
            return new ValueContext<TAnotherValue>(FlowContext, transformator(Value));
        }

        public IValueContext<TAnotherValue> Select<TAnotherValue>(Func<IFlowContext, TValue, TAnotherValue> transformator)
        {
            return new ValueContext<TAnotherValue>(FlowContext, transformator(FlowContext, Value));
        }
        
        public IFlowContext Continue()
        {
            return FlowContext;
        }

        public IValueContext<TValue> With(Action<TValue> action)
        {
            action(Value);
            return this;
        }
        
        public IValueAssertContext<TValue> Assert()
        {
            return new ValueAssertContext<TValue>(this);
        }
    }
}
