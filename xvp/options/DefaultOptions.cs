using System.Collections.Generic;
using CommandLine;

namespace xvp.options
{
    public class DefaultOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.", SetName="default")]
        public bool Verbose { get; set; }
        
        [Option('h', "help", Required = false, HelpText = "Displays help screen.", SetName="default")]
        public bool Help { get; set; }
        
        [Option("version", Required = false, HelpText = "Displays help screen.", SetName="default")]
        public bool Version { get; set; }
    }
}