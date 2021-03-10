using com.stuffwithstuff.bantam.expressions;

namespace com.stuffwithstuff.bantam.parselets {
   /// <summary>
   /// Parses parentheses used to group an expression, like "(b + c)".
   /// </summary>
   public class GroupParselet : IPrefixParselet {
      public IExpression Parse(Parser parser, Token token) {
         var expression = parser.ParseExpression();
         parser.Consume(TokenType.RightParen);
         return expression;
      }
   }
}
