using com.stuffwithstuff.bantam.expressions;

namespace com.stuffwithstuff.bantam.parselets {
   /// <summary>
   /// Parselet for the condition or "ternary" operator, like "a ? b : c".
   /// </summary>
   public class ConditionalParselet : IInfixParselet {
      public IExpression Parse(Parser parser, IExpression left, Token token) {
         var thenArm = parser.ParseExpression();
         parser.Consume(TokenType.Colon);
         var elseArm = parser.ParseExpression(BindingPower.Conditional - 1);

         return new ConditionalExpression(left, thenArm, elseArm);
      }

      public int GetBindingPower() {
         return BindingPower.Conditional;
      }
   }
}
