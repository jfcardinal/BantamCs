using System.Text;

namespace com.stuffwithstuff.bantam.expressions {
   /// <summary>
   /// Interface for all expression AST node classes.
   /// </summary>
   public interface IExpression {
      /// <summary>
      /// Pretty-print the expression to a string.
      /// </summary>
      /// <param name="sb"></param>
      void Print(StringBuilder sb);
   }
}
