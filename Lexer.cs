using System.Text.RegularExpressions;

namespace LexerAri
{
    public class Lexer
    {
        private readonly string _entrada;

        public Lexer(string entrada)
        {
            _entrada = entrada;
        }

        private readonly List<(TokenTipo Tipo, string padrao)> regras = new()
        {
            (TokenTipo.FLUTUANTE, @"\d*\.\d+|\d+\.\d*"),

            (TokenTipo.OPERADOR, @"[+-/*]"),

            (TokenTipo.ABRE_PARÊNTESE, @"\("),

            (TokenTipo.FECHA_PARÊNTESE, @"\)"),

            (TokenTipo.INTEIRO, @"[0-9]+"),

            (TokenTipo.INVALIDO, @"\bINVALIDO\b"),

            (TokenTipo.ID, @"[a-zA-Z][a-zA-Z0-9]*"),

            (TokenTipo.LETRA, @"[a-zA-Z]"),
        };

        static (string, List<string>) LimparEntrada(string entrada)
        {
            var padrao = @"\b\d+\.\d+\.\d+\b";
            
            string substituicao = "INVALIDO"; 

            List<string> substituicoes = new ();

            string resultado = Regex.Replace(entrada, padrao, m =>
            {
                substituicoes.Add(m.Value);

                return substituicao;
            });

            resultado = resultado.Replace(" ", "");

            resultado = resultado.Replace("\n", "");

            resultado = resultado.Replace("\r", "");

            return (resultado, substituicoes);
        }

        public IEnumerable<Token> Casar()
        {
            var resultado = new List<Token>();

            var regexPattern = string.Join("|", regras.Select(p => $"({p.padrao})"));

            var regex = new Regex(regexPattern);

            var entradaTratada = LimparEntrada(_entrada);

            var matches = regex.Matches(entradaTratada.Item1).ToList();

            var caracteresInvalidos = entradaTratada.Item2;

            foreach (var match in matches)
            {
                for (int i = 0; i < regras.Count; i++)
                {
                    if (match.Groups[i + 1].Success)
                    {
                        if (regras[i].Tipo == TokenTipo.INVALIDO)
                        {
                            resultado.Add(new Token(regras[i].Tipo, caracteresInvalidos.FirstOrDefault()));

                            caracteresInvalidos.RemoveAt(0);
                        }
                            
                        else
                            resultado.Add(new Token(regras[i].Tipo, match.Value));

                        break;
                    }
                }
            }

            return resultado;
        }
    }
}
