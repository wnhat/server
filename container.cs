using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class container
    {

    }
    class Panel_queue
    {
        public string Panel_id;
        public string Eq_id;
        public DateTime Eq_datetime;

        public Panel_queue(string panel_id, string eq_id, DateTime eq_datetime)
        {
            this.Panel_id = panel_id;
            this.Eq_id = eq_id;
            this.Eq_datetime = eq_datetime;
        }

        //public string Panel_id { get => panel_id; set => panel_id = value; }
        //public string Eq_id { get => eq_id; set => eq_id = value; }
        //public DateTime Eq_datetime { get => eq_datetime; set => eq_datetime = value; }
    }

    class Panel_path_container
    {
        public string Panel_id;
        public DirectoryInfo Origin_image_path;
        public DirectoryInfo Result_path;

        public Panel_path_container(string panel_id, DirectoryInfo origin_image_path, DirectoryInfo result_path)
        {
            this.Panel_id = panel_id;
            this.Origin_image_path = origin_image_path;
            this.Result_path = result_path;
        }

        //public string Panel_id { get => panel_id; set => panel_id = value; }
        //public DirectoryInfo Origin_image_path { get => origin_image_path; set => origin_image_path = value; }
        //public DirectoryInfo Result_path { get => result_path; set => result_path = value; }
    }
}
