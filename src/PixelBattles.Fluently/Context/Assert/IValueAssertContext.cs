using System;
using System.Collections;

namespace PixelBattles.Fluently.Context
{
    public interface IValueAssertContext<TValue>
    {
        IValueAssertContext<TValue> NotNull();

        IValueAssertContext<TValue> NotNull<TAnotherValue>(Func<TValue, TAnotherValue> transformator);

        IValueAssertContext<TValue> Empty(Func<TValue, IEnumerable> transformator);

        IValueAssertContext<TValue> NotEmpty(Func<TValue, IEnumerable> transformator);

        IValueAssertContext<TValue> Equals(TValue expected);

        IValueAssertContext<TValue> Equals<TAnotherValue>(Func<TValue, TAnotherValue> transformator, TAnotherValue expected);

        IValueAssertContext<TValue> True(Func<TValue, bool> transformator);

        IValueAssertContext<TValue> True(Func<TValue, bool?> transformator);

        IValueAssertContext<TValue> False(Func<TValue, bool> transformator);

        IValueAssertContext<TValue> False(Func<TValue, bool?> transformator);

        IValueContext<TValue> Continue();
    }
}
