using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace server
{
    class IP_TR
    {
        IP_container ip_docker = new IP_container();
        public IP_TR()
        {
            string ip_path = @"D:\1218180\program2\c#\server\IP.json";
            StreamReader file = new StreamReader(ip_path);
            StringReader file_string = new StringReader(file.ReadToEnd());
            JsonSerializer file_serial = new JsonSerializer();
            ip_docker = (IP_container)file_serial.Deserialize(new JsonTextReader(file_string),typeof(IP_container));
        }
    }

    class IP_container
    {
        public List<string> AVI { get; set; }
        public List<string> SVI { get; set; }
        public List<string> APP { get; set; }
        public List<string> MTP { get; set; }
        public List<string> MAIN { get; set; }
        public List<string> PRE { get; set; }
        public List<string> POST { get; set; }
    }
}
