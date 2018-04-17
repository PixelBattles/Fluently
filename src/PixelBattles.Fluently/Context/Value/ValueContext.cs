using System;

namespace PixelBattles.Fluently.Context
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

        public IValueContext<TAnotherValue> Select<TAnotherValue>(Func<TValue, TAnotherValue> transformator)
        {
            return new ValueContext<TAnotherValue>(flowContext, transformator(Value));
        }

        public IValueContext<TAnotherValue> Select<TAnotherValue>(Func<IFlowContext, TValue, TAnotherValue> transformator)
        {
            throw new NotImplementedException();
        }

        IValueContext<TValue> IValueContext<TValue>.Save(string destination)
        {
            Destination = destination;
            flowContext.Set(Destination, Value);
            return this;
        }

        public IFlowContext Continue()
        {
            return flowContext;
        }

        public IValueContext<TValue> With(Action<TValue> action)
        {
            action(Value);
            return this;
        }

        IValueContext<TValue> IValueContext<TValue>.Save()
        {
            if (String.IsNullOrWhiteSpace(Destination))
            {
                Destination = typeof(TValue).Name;
            }
            flowContext.Set(Destination, Value);
            return this;
        }

        public IValueAssertContext<TValue> Assert()
        {
            return new ValueAssertContext<TValue>(this);
        }
    }
}
