using LexerAri;

var input = "A4 * (12.4 + 4) * 12.3.4 / (2/5) * 2.3 * X + 4.8 (10/.5) + 9. / 2.3.4 + X53";

var lexer = new Lexer(input);

var tokens = lexer.Casamento();

foreach (var token in tokens)
{
    Console.WriteLine(token);
}
