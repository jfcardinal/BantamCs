using com.stuffwithstuff.bantam.expressions;

namespace com.stuffwithstuff.bantam.parselets {
   /// <summary>
   /// Parses assignment expressions like "a = b". The left side of an assignment
   /// expression must be a simple name like "a", and expressions are
   /// right-associative. (In other words, "a = b = c" is parsed as "a = (b = c)").
   /// </summary>
   public class AssignParselet : IInfixParselet {
      public IExpression Parse(Parser parser, IExpression left, Token token) {
         var right = parser.ParseExpression(BindingPower.Assignment - 1);

         if (!(left is NameExpression))
            throw new ParseException("The left-hand side of an assignment must be a name.");

         var name = ((NameExpression)left).Name;
         return new AssignExpression(name, right);
      }

      public int GetBindingPower() {
         return BindingPower.Assignment;
      }
   }
}