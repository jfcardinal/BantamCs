using com.stuffwithstuff.bantam.expressions;

namespace com.stuffwithstuff.bantam.parselets {
   /// <summary>
   /// Simple parselet for a named variable like "abc".
   /// </summary>
   public class NameParselet : IPrefixParselet {
      public IExpression Parse(Parser parser, Token token) {
         return new NameExpression(token.Text);
      }
   }
}
