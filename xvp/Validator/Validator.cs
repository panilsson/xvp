using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace xvp
{
    public static class Validator
    {
        public static bool Validate(string filePath, List<string> xsdInfo)
        {
            var set = new XmlSchemaSet();

            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                ValidationType = ValidationType.Schema
            };

            if (xsdInfo.Any())
            {
                for (var i = 0; i < xsdInfo.Count - 1; i += 2)
                {
                    using (var xr = XmlReader.Create(
                               new XmlTextReader(xsdInfo[i]),
                               new XmlReaderSettings() { DtdProcessing = DtdProcessing.Parse }))
                    {
                        set.Add(xsdInfo[i + 1], xr);
                    }
                    set.Compile();
                    settings.Schemas.Add(set);
                }
            }

            settings.ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags = XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;

            settings.ValidationEventHandler += (o, a) =>
            {
                Console.WriteLine(a.Severity == XmlSeverityType.Warning ? 
                    "\tWARNING: {0}" : "\tERROR: {0}", a.Message);
            };
            
            XmlReader reader = XmlReader.Create(filePath, settings);

            while (reader.Read());

            return true;
        }
    }
}