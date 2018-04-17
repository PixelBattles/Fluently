using System;
using System.Collections;
using Xunit;

namespace PixelBattles.Fluently.Context
{
    public class ValueAssertContext<TValue> : IValueAssertContext<TValue>
    {
        private IValueContext<TValue> valueContext;

        public ValueAssertContext(IValueContext<TValue> valueContext)
        {
            this.valueContext = valueContext;
        }

        public IValueAssertContext<TValue> NotNull()
        {
            Assert.NotNull(valueContext.Value);
            return this;
        }

        public IValueAssertContext<TValue> Equals(TValue expected)
        {
            Assert.Equal(expected, valueContext.Value);
            return this;
        }

        public IValueAssertContext<TValue> Equals<TAnotherValue>(Func<TValue,TAnotherValue> transformator, TAnotherValue expected)
        {
            Assert.Equal(expected, transformator(valueContext.Value));
            return this;
        }

        public IValueAssertContext<TValue> True(Func<TValue, bool> transformator)
        {
            Assert.True(transformator(valueContext.Value));
            return this;
        }

        public IValueAssertContext<TValue> True(Func<TValue, bool?> transformator)
        {
            Assert.True(transformator(valueContext.Value));
            return this;
        }

        public IValueAssertContext<TValue> False(Func<TValue, bool> transformator)
        {
            Assert.True(transformator(valueContext.Value));
            return this;
        }

        public IValueAssertContext<TValue> False(Func<TValue, bool?> transformator)
        {
            Assert.True(transformator(valueContext.Value));
            return this;
        }

        public IValueContext<TValue> Continue()
        {
            return valueContext;
        }

        public IValueAssertContext<TValue> NotNull<TAnotherValue>(Func<TValue, TAnotherValue> transformator)
        {
            Assert.NotNull(transformator(valueContext.Value));
            return this;
        }

        public IValueAssertContext<TValue> Empty(Func<TValue, IEnumerable> transformator)
        {
            Assert.Empty(transformator(valueContext.Value));
            return this;
        }

        public IValueAssertContext<TValue> NotEmpty(Func<TValue, IEnumerable> transformator)
        {
            Assert.NotEmpty(transformator(valueContext.Value));
            return this;
        }
    }
}
