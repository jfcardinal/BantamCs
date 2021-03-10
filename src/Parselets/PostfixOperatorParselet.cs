using com.stuffwithstuff.bantam.expressions;

namespace com.stuffwithstuff.bantam.parselets {
   /// <summary>
   /// Generic infix parselet for an unary arithmetic operator. Parses
   /// postfix unary "?" expressions.
   /// </summary>
   public class PostfixOperatorParselet : IInfixParselet {
      private readonly int _bindingPower;

      public PostfixOperatorParselet(int bindingPower) {
         _bindingPower = bindingPower;
      }

      public IExpression Parse(Parser parser, IExpression left, Token token) {
         return new PostfixExpression(left, token.Type);
      }

      public int GetBindingPower() {
         return _bindingPower;
      }
   }
}