using System.Collections.Generic;

using com.stuffwithstuff.bantam.expressions;
using com.stuffwithstuff.bantam.parselets;

namespace com.stuffwithstuff.bantam {
   public class Parser {
      private Lexer _tokens;
      private List<Token> _read = new List<Token>();
      private Dictionary<TokenType, IPrefixParselet> _prefixParselets = new Dictionary<TokenType, IPrefixParselet>();
      private Dictionary<TokenType, IInfixParselet> _infixParselets = new Dictionary<TokenType, IInfixParselet>();

      public Parser(Lexer tokens) {
         _tokens = tokens;
      }

      public void Register(TokenType token, IPrefixParselet parselet) {
         _prefixParselets.Add(token, parselet);
      }

      public void Register(TokenType token, IInfixParselet parselet) {
         _infixParselets.Add(token, parselet);
      }

      public IExpression ParseExpression(int precedence) {
         var token = Consume();

         if (!_prefixParselets.TryGetValue(token.Type, out var prefix)) {
            throw new ParseException("Could not parse \"" + token.Text + "\".");
         }

         IExpression left = prefix.Parse(this, token);

         while (precedence < GetBindingPower()) {
            token = Consume();

         if (!_infixParselets.TryGetValue(token.Type, out var infix)) {
            throw new ParseException("Could not parse \"" + token.Text + "\".");
         }
            left = infix.Parse(this, left, token);
         }

         return left;
      }

      public IExpression ParseExpression() {
         return ParseExpression(0);
      }

      public bool Match(TokenType expected) {
         var token = LookAhead(0);
         if (token.Type != expected) {
            return false;
         }

         Consume();
         return true;
      }

      public Token Consume(TokenType expected) {
         var token = LookAhead(0);
         if (token.Type != expected) {
            throw new ParseException("Expected token " + expected + " and found " + token.Type);
         }

         return Consume();
      }

      public Token Consume() {
         // Make sure we've read the token.
         var token = LookAhead(0);
         _read.Remove(token);
         return token;
      }

      private Token LookAhead(int distance) {
         // Read in as many as needed.
         while (distance >= _read.Count) {
            _read.Add(_tokens.Next());
         }

         // Get the queued token.
         return _read[distance];
      }

      private int GetBindingPower() {
         if (_infixParselets.TryGetValue(LookAhead(0).Type, out var parselet)) {
            return parselet.GetBindingPower();
         }
         return 0;
      }
   }
}
