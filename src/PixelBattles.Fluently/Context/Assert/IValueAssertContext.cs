using System;

namespace PixelBattles.Fluently.Context
{
    public interface IValueAssertContext<TValue>
    {
        IValueAssertContext<TValue> NotNull();

        IValueAssertContext<TValue> Equals(TValue expected);

        IValueAssertContext<TValue> Equals<TAnotherValue>(Func<TValue, TAnotherValue> transformator, TAnotherValue expected);

        IValueAssertContext<TValue> True(Func<TValue, bool> transformator);

        IValueAssertContext<TValue> True(Func<TValue, bool?> transformator);

        IValueAssertContext<TValue> False(Func<TValue, bool> transformator);

        IValueAssertContext<TValue> False(Func<TValue, bool?> transformator);

        IValueContext<TValue> Continue();
    }
}
