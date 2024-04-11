namespace LexerAri
{
    public class Token
    {
        public TokenTipo Tipo { get; }

        public string? Lexema { get; }

        public Token(TokenTipo tipo, string? lexema)
        {
            Tipo = tipo;
            
            Lexema = lexema;
        }

        public override string? ToString()
        {
            return $"Token: {Tipo}, Lexema: {Lexema}";
        }
    }
}
