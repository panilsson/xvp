using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using CommandLine;

namespace xvp.Validator
{
    public static class Validator
    {
        public static bool validate(string filePath, List<string> xsdInfo)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            
            if (xsdInfo.Any())
            {
                for (int i = 0; i < xsdInfo.Count - 1; i+=2)
                {
                    settings.Schemas.Add(xsdInfo[i], xsdInfo[i + 1]);

                }
            }
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            settings.ValidationEventHandler += (o, a) =>
            {
                if (a.Severity == XmlSeverityType.Warning)
                {
                    Console.WriteLine("\tWarning: {0}", a.Message);
                }
                else
                {
                    Console.WriteLine("\tERROR: {0}", a.Message);
                }
            };
            
            XmlReader reader = XmlReader.Create(filePath, settings);

            while (reader.Read());

            return true;

        }
    }
}