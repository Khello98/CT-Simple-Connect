using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace SimpleConnect
{
    class CTParameterFile
    {
        public void ReadActionXml(string inputFile)
        {
            bool step0 = false;
            bool step1 = false;
            bool step2 = false;
            // Start with XmlReader object  
            //here, we try to setup Stream between the XML file nad xmlReader
            using (XmlReader reader = XmlReader.Create(inputFile))
            {
                while (reader.Read())
                {
                    //Console.Write("Element  ");
                   // Console.Write(reader.Name);
                   // Console.WriteLine();
                   // Console.ReadKey();
                    
                    if (reader.IsStartElement() && (reader.Name.ToUpper() == "PARAMETERFILE"))
                    {
                        reader.Read();
                        
                        step0 = true;
                        
                        if ((reader.IsStartElement() && (reader.Name.ToUpper() == "DRIVE")) && step0 == true)
                        {
                            reader.Read();
                            step1 = true;
                            if ((reader.IsStartElement() && (reader.Name.ToUpper() == "CLASSIFIER")) && step1 == true)
                            {
                                reader.Skip();
                                step2 = true;
                                reader.Read(); // read end element
                            }
                            reader.Read();
                            if ((reader.IsStartElement() && (reader.Name.ToUpper() == "CONFIGURATION")) && step2 == true)
                            {
                                reader.Skip();
                                reader.Read(); // read end element
                            }
                            if (reader.IsStartElement() && (reader.Name.ToUpper() == "PARAMETERS")) //start of drive parameters
                            {
                                reader.Read();
                                while (reader.Name.ToUpper() != "PARAMETER")
                                {
                                    Console.Write(reader.Name);
                                    Console.Write("  ");
                                    Console.Write(reader.AttributeCount);
                                }
                                break;
                            }
                        }
                    }
                    Console.WriteLine(reader.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
