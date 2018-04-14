using System.Net.Http;
using Xunit;

namespace PixelBattles.Fluently.Samples
{
    public class MathTest : FlowTest
    {
        [Fact]
        public void Multiply_Is_Working()
        {
            FlowContext
                .Setup(1).Save("left operand").Continue()
                .Setup(2).Save("right operand").Continue()
                .Setup(context => context.Get<int>("left operand").Value * context.Get<int>("right operand").Value).Save("result").Continue()
                .Assert().Equals(context => context.Get<int>("result").Value, 2);
        }

        [Fact]
        public void Division_Is_Working()
        {
            FlowContext
                .Setup(8).Save("left operand").Continue()
                .Setup(2).Save("right operand").Continue()
                .Setup(context => context.Get<int>("left operand").Value / context.Get<int>("right operand").Value).Save("result").Continue()
                .Assert().Equals(context => context.Get<int>("result").Value, 4);
        }
    }
}
