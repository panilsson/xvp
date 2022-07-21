using CommandLine;

namespace xvp.verbs
{
    [Verb("against", HelpText = "Choose the XSD to validate XML file(s) against.")]
    public class Against
    {
        [Value(0, MetaName = "XSD file", HelpText = "The XSD file to validate XML against.", Required = true)]
        public string FileName { get; set; }
    }
}