using System.Text;

namespace com.stuffwithstuff.bantam.expressions {
   /// <summary>
   /// A postfix unary arithmetic expression like "a!"
   /// </summary>
   public class PostfixExpression : IExpression {
      private IExpression _leftExpr;
      private TokenType _operator;

      public PostfixExpression(IExpression left, TokenType op) {
         _leftExpr = left;
         _operator = op;
      }

      public void Print(StringBuilder sb) {
         sb.Append('(');
         _leftExpr.Print(sb);
         sb.Append(_operator.Punctuator()).Append(')');
      }
   }
}