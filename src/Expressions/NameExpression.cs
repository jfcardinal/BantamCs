using System.Text;

namespace com.stuffwithstuff.bantam.expressions {
   /// <summary>
   /// A simple variable name expression like "abc".
   /// </summary>
   public class NameExpression : IExpression {
      public NameExpression(string name) {
         Name = name;
      }

      public string Name {
         get;
      }

      public void Print(StringBuilder sb) {
         sb.Append(Name);
      }
   }
}
