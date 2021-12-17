using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            if (type == "g")
            {
                GenerateForGroups(count, filename, format);
            }
            else
            {
                System.Console.Out.Write("Unrecognized type of data" + type);
            }
        }

        static void GenerateForGroups(int count, string filename, string format)
        {
            var groups = new List<AddressData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new AddressData()
                {
                    FirstName = TestBase.GetRandomString(10),
                    LastName = TestBase.GetRandomString(10),
                    Address = TestBase.GetRandomString(15),
                    City = TestBase.GetRandomString(8),
                    Country = "United States",
                    State = TestBase.GetRandomNumber(),
                    PostCode = TestBase.GetRandomNumberString(5),
                    MobileNumber = TestBase.GetRandomNumberString(11),
                    Title = TestBase.GetRandomString(10)
                });
            }
            StreamWriter writer = new StreamWriter(filename);
            if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);

            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
        }

        static void WriteGroupsToXmlFile(List<AddressData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<AddressData>)).Serialize(writer, groups);
        }
    }
}