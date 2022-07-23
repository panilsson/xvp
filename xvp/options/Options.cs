using System.Collections.Generic;
using CommandLine;

namespace xvp.options
{
    class Options
    {
        // Input: list of input XML files
        [Option('i', "input")]
        public IEnumerable<string> Input { get; set; }
        
        // Against: XSD file to validate against
        [Option('a', "against")]
        public IEnumerable<string> Against { get; set; }
    }
}