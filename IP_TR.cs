using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace server
{
    enum PC_name
    {
        AVI,
        SVI,
        APP,
        MTP,
        MAIN,
        PRE,
        POST,
    }
    class IP_TR
    {
        IP_container ip_docker = new IP_container();
        public IP_TR()
        {
            string ip_path = @"D:\program\c#\server\IP.json";
            StreamReader file = new StreamReader(ip_path);
            StringReader file_string = new StringReader(file.ReadToEnd());
            JsonSerializer file_serial = new JsonSerializer();
            ip_docker = (IP_container)file_serial.Deserialize(new JsonTextReader(file_string), typeof(IP_container));
        }
        public List<string> get_ip(PC_name switch_on)
        {
            List<string> return_list = new List<string>();
            switch (switch_on)
            {
                case PC_name.AVI:
                    return_list = ip_docker.AVI;
                    break;
                case PC_name.SVI:
                    return_list = ip_docker.SVI;
                    break;
                case PC_name.APP:
                    return_list = ip_docker.APP;
                    break;
                case PC_name.MTP:
                    return_list = ip_docker.MTP;
                    break;
                case PC_name.MAIN:
                    return_list = ip_docker.MAIN;
                    break;
                case PC_name.PRE:
                    return_list = ip_docker.PRE;
                    break;
                case PC_name.POST:
                    return_list = ip_docker.POST;
                    break;
            }

            return return_list;
        }
        public List<string> get_ip_byeq(PC_name pc_type, List<int> eq_number)
        {
            List<string> return_list = new List<string>();
            List<string> all_list_bytype = get_ip(pc_type);

            foreach (var item in eq_number)
            {
                return_list.Add(all_list_bytype[item * 2 - 2]);
                return_list.Add(all_list_bytype[item * 2 - 1]);
            }

            return return_list;
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
