namespace LexerAri
{
    public class Token
    {
        public TokenTipo Type { get; }

        public string? Value { get; }

        public Token(TokenTipo type, string? value)
        {
            Type = type;
            
            Value = value;
        }

        public override string? ToString()
        {
            return $"Token: {Type}, Lexema: {Value}";
        }
    }
}
