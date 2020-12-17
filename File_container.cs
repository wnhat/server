using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class File_container
    {
        List<Panel_path_container> panel_list = new List<Panel_path_container>();
        List<string> log_list = new List<string>();

        public File_container()
        {
            this.panel_list = new List<Panel_path_container>();
            this.log_list = new List<string>();
        }

        public void Refresh_file_list()
        {
            // TODO: this is a test version;
            panel_list.Clear();
            Serchfile(@"D:\program\c#\testdata");
        }
        private void Serchfile(string diskpath)
        {
            // TODO: add eqp id;
            DirectoryInfo origin_directory = new DirectoryInfo(diskpath);
            DirectoryInfo[] image_directory_list = origin_directory.GetDirectories(Path.Combine(diskpath,"Origin"));
            DirectoryInfo[] result_directory_list = origin_directory.GetDirectories(Path.Combine(diskpath, "Result"));
            foreach (var item in image_directory_list)
            {
                if (result_directory_list.Contains(item))
                {
                    DirectoryInfo this_panel_result_dir = result_directory_list.Where(x => { return x.Name == item.Name;}).ToList()[0];
                    Panel_path_container this_panel = new Panel_path_container(item.Name, item, this_panel_result_dir);
                    panel_list.Add(this_panel);
                }
                else
                {
                    log_list.Add(String.Format("result file not exist; panel id : {0}; path: {0}", item.Name, item.FullName));
                    //Console.WriteLine("result file not exist: {0}",item.Name);
                }
            }

            foreach (var item in result_directory_list)
            {
                if (result_directory_list.Contains(item))
                {
                    DirectoryInfo this_panel_image_dir = image_directory_list.Where(x => { return x.Name == item.Name; }).ToList()[0];
                    Panel_path_container this_panel = new Panel_path_container(item.Name, item, this_panel_image_dir);
                    panel_list.Add(this_panel);
                }
                else
                {
                    log_list.Add(String.Format("image file not exist; panel id : {0}; path: {0}", item.Name,item.FullName));
                }
            }
        }
        public List<Panel_path_container> get_panel(string panel_id)
        {
            List<Panel_path_container> return_panel_list = panel_list.Where(x => { return x.Panel_id == panel_id; }).ToList();
            return return_panel_list;
        }
    }

}
