using System;
using System.Linq;
using xvp.options;
using CommandLine;
using CommandLine.Text;

namespace xvp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser(config => config.HelpWriter = null);
            
            var parserResult = parser.ParseArguments<Options>(args);
            
            parserResult
                .WithParsed<Options>(options => RunValidator(options))
                .WithNotParsed(errs => DisplayHelp(parserResult));
        }
        
        static void DisplayHelp<T>(ParserResult<T> result)
        {  
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.Heading = "WARNING ERROR IN PARSING";
                h.Copyright = string.Empty;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            Console.WriteLine(helpText);
        }
        private static void RunValidator(Options options)
        {
            if (!options.Input.Any() || !options.Against.Any()) return;
            foreach (var file in options.Input)
            {
                Console.WriteLine("Processing file {0}", file);
                if (Validator.Validate(file, options.Against.ToList()))
                {
                    Console.WriteLine("\tValidation of file {0} finished.\n", file);
                }
            }

        }
    }
}