using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBattles.Fluently.Context
{
    public interface IValueContext
    {
        object Value { get; }
        IFlowContext Save();
        IFlowContext Save(string destination);
    }
}
