using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> isp18 = new List<Student>();

            isp18.Add(new Student("Vitaliy",18,"М"));
            isp18.Add(new Student("Aleksandr", 19, "М"));
            isp18.Add(new Student("Vika", 18, "Ж"));
            isp18.Add(new Student("Sveta", 17, "Ж"));
            isp18.Add(new Student("Sofia", 19, "Ж"));

            Group Isp18grp = new Group("ISP-18", isp18, "ISP", "Gladkova E.M");
            Isp18grp.GroupInfo();


            List<Student> pks19 = new List<Student>();

            pks19.Add(new Student("Nikolay", 17, "М"));
            pks19.Add(new Student("Mihail", 16, "М"));
            pks19.Add(new Student("Egor", 18, "М"));
            pks19.Add(new Student("Eva", 17, "Ж"));
            pks19.Add(new Student("Anya", 17, "Ж"));

            Group pks19grp = new Group("PKS-19", pks19, "PKS", "Zyimbalova N.A");
            pks19grp.GroupInfo();

            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("group.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, isp18);
            }

            var xmlFormatter = new XmlSerializer(typeof(List<Student>));
            using (var file = new FileStream("group.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, isp18);
            }

            var soap = new SoapFormatter();
            using (var file = new FileStream("group.soap", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file,isp18);
            }

            var jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));
            using (var file = new FileStream("group.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, isp18.ToArray());
            }

            Console.ReadKey();
        }

        
    }
}
