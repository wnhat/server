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
        IP_TR ip_tr;
        List<INS_pc_manage> Ins_pc_list;

        public File_container(IP_TR ip_tr_)
        {
            this.panel_list = new List<Panel_path_container>();
            this.log_list = new List<string>();
            this.Ins_pc_list = new List<INS_pc_manage>();
            ip_tr = ip_tr_;

            List<PC> refresh_pc_list = ip_tr.name_to_ip(new List<string> { "AVI" });
            foreach (var pc in refresh_pc_list)
            {
                Ins_pc_list.Add(new INS_pc_manage(pc,log_list));
            }

            Refresh_file_list();
        }

        public void Refresh_file_list()
        {
            // TODO: this is a test version;
            panel_list.Clear();
            List<Panel_path_container> new_panel_list = new List<Panel_path_container>();
            foreach (var pc in Ins_pc_list)
            {
                Console.WriteLine(pc.pc_ip);
                new_panel_list.AddRange(pc.Serch_file());
            }
            panel_list = new_panel_list;
        }

        public List<Panel_path_container> get_panel(string panel_id)
        {
            List<Panel_path_container> return_panel_list = panel_list.Where(x => { return x.Panel_id == panel_id; }).ToList();
            return return_panel_list;
        }
    }

    class INS_pc_manage : pc_manager
    {
        public INS_pc_manage(PC input_pc, List<string> log_list_)
        {
            this.eq_id = input_pc.eq_id;
            this.pc_ip = input_pc.pc_ip;
            this.pc_name = input_pc.pc_name;
            this.pc_side = input_pc.pc_side;
            this.log_list = log_list_;
        }

        public List<Panel_path_container> Serch_file()
        {
            List<Panel_path_container> panel_list = new List<Panel_path_container>();
            List<string> search_list = new Disk_part().getall;
            foreach (var search_disk in search_list)
            {
                Console.WriteLine(search_disk);
                try
                {
                    string diskpath1 = Path.Combine(pc_ip, "NetworkDrive", search_disk, "Defect Info", "Origin");
                    string diskpath2 = Path.Combine(pc_ip, "NetworkDrive", search_disk, "Defect Info", "Result");
                    List<string> image_directory_list = Directory.GetDirectories(diskpath1).ToList();
                    List<string> result_directory_list = Directory.GetDirectories(diskpath2).ToList();
                    image_directory_list.Sort();
                    result_directory_list.Sort();

                    foreach (var item in image_directory_list)
                    {
                        string this_panel_result_dir = result_directory_list.FirstOrDefault(x => { return x.Substring(x.Length-17) == item.Substring(item.Length-17); });
                        if (this_panel_result_dir != null)
                        {
                            Panel_path_container this_panel = new Panel_path_container(item.Substring(item.Length - 17), item, this_panel_result_dir, eq_id, pc_name, search_disk);
                            panel_list.Add(this_panel);
                            result_directory_list.Remove(this_panel_result_dir);
                        }
                        else
                        {
                            log_list.Add(String.Format("result file not exist; panel id : {0}; path: {1}", item.Substring(item.Length - 17), item));
                            //Console.WriteLine("result file not exist: {0}",item.Name);
                        }
                    }

                    foreach (var item in result_directory_list)
                    {
                        string this_panel_image_dir = image_directory_list.FirstOrDefault(x => { return x.Substring(x.Length - 17) == item.Substring(item.Length - 17); });
                        if (this_panel_image_dir != null)
                        {
                            Panel_path_container this_panel = new Panel_path_container(item.Substring(item.Length - 17), this_panel_image_dir, item, eq_id, pc_name, search_disk);
                            if (!panel_list.Contains(this_panel))
                            {
                                panel_list.Add(this_panel);
                            }
                            image_directory_list.Remove(this_panel_image_dir);
                        }
                        else
                        {
                            log_list.Add(String.Format("image file not exist; panel id : {0}; path: {0}", item.Substring(item.Length - 17), item));
                        }
                    }
                }

                catch (Exception e)
                {
                    log_list.Add(String.Format("查询文件失败：{0}", e.Message));
                }
            }
            return panel_list;
        }
    }
}
