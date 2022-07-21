using System;
using System.Runtime.CompilerServices;
using xvp.options;
using CommandLine;
using CommandLine.Text;

namespace xvp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandLine.Parser(with => with.HelpWriter = null);
            
            var parserResult = parser.ParseArguments<DefaultOptions>(args);
            
            parserResult
                .WithParsed<DefaultOptions>(options => Run(options))
                .WithNotParsed(errs => DisplayHelp(parserResult));
        }

        static void DisplayHelp<T>(ParserResult<T> result)
        {  
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.Heading = "xvp 1.0";
                h.Copyright = string.Empty;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            Console.WriteLine(helpText);
        }
        private static void Run(DefaultOptions options)
        {

        }
    }
}