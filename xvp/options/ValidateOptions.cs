using System.Collections.Generic;
using CommandLine;

namespace xvp.options
{
    public class ValidateOptions
    {
        [Option('i', "input", Required = true, HelpText = "Input XML file(s).", SetName = "validate")]
        public IEnumerable<string>  Input { get; set; }
    }
}