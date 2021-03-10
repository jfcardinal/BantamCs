using System;

namespace com.stuffwithstuff.bantam {
   public class ParseException : Exception {
      public ParseException(string message) : base(message) { }
   }
}