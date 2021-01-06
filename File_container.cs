using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Filecontainer
    {
        List<PanelPathContainer> panel_list;
        PanelPathManager PathManager;
        List<string> log_list;
        IP_TR ip_tr;
        List<INS_pc_manage> Ins_pc_list;

        public Filecontainer(IP_TR ip_tr_)
        {
            this.panel_list = new List<PanelPathContainer>();
            this.log_list = new List<string>();
            this.Ins_pc_list = new List<INS_pc_manage>();
            this.PathManager = new PanelPathManager();
            ip_tr = ip_tr_;

            List<PC> refresh_pc_list = ip_tr.name_to_ip(new List<string> { "AVI"});
            foreach (var pc in refresh_pc_list)
            {
                Ins_pc_list.Add(new INS_pc_manage(pc,log_list));
            }
            Refresh_file_list();
        }

        public async void Refresh_file_list()
        {
            // TODO: 
            Console.WriteLine(DateTime.Now);
            List<PanelPathContainer> new_panel_list = new List<PanelPathContainer>();

            List<Task> task_list = new List<Task>();
            foreach (var pc in Ins_pc_list)
            {
                var refresh_task = Task.Run(() => pc.Serch_file(new_panel_list));
                task_list.Add(refresh_task);
            }
            await Task.WhenAll(task_list);
            Console.WriteLine("finished all.");
            Console.WriteLine(DateTime.Now);
            panel_list.Clear();
            panel_list = new_panel_list;
        }

        public List<PanelPathContainer> GetPanel(string panel_id)
        {
            // list.where cost more than 100ms when the list are large than 4,000,000;
            // TODO: use dict in panel list;
            List<PanelPathContainer> return_panel_list = panel_list.Where(x => { return x.Panel_id == panel_id; }).ToList();
            if (return_panel_list.Count > 0)
            {
                return return_panel_list;
            }
            else
            {
                return null;
            }
        }

    }

    class INS_pc_manage : PcManager
    {
        public INS_pc_manage(PC input_pc, List<string> log_list_)
        {
            this.EqId = input_pc.EqId;
            this.PcIp = input_pc.PcIp;
            this.PcName = input_pc.PcName;
            this.PcSide = input_pc.PcSide;
            this.log_list = log_list_;
        }

        public void Serch_file(List<PanelPathContainer> new_panel_list)
        {
            List<PanelPathContainer> panel_list = new List<PanelPathContainer>();
            List<string> search_list = new Disk_part().getall;
            foreach (var search_disk in search_list)
            {
                Console.WriteLine("pc: {1} ; disk: {0}",search_disk,PcIp);
                try
                {
                    string diskpath1 = Path.Combine(PcIp, "NetworkDrive", search_disk, "Defect Info", "Origin");
                    string diskpath2 = Path.Combine(PcIp, "NetworkDrive", search_disk, "Defect Info", "Result");
                    List<string> image_directory_list = Directory.GetDirectories(diskpath1).ToList();
                    List<string> result_directory_list = Directory.GetDirectories(diskpath2).ToList();
                    image_directory_list.Sort();
                    result_directory_list.Sort();

                    foreach (var item in image_directory_list)
                    {
                        string this_panel_result_dir = result_directory_list.FirstOrDefault(x => { return x.Substring(x.Length-17) == item.Substring(item.Length-17); });
                        if (this_panel_result_dir != null)
                        {
                            PanelPathContainer this_panel = new PanelPathContainer(item.Substring(item.Length - 17), item, this_panel_result_dir, EqId, PcName, search_disk);
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
                            PanelPathContainer this_panel = new PanelPathContainer(item.Substring(item.Length - 17), this_panel_image_dir, item, EqId, PcName, search_disk);
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
            Console.WriteLine("pc: {0} finishied;", PcIp);
            new_panel_list.AddRange(panel_list);
        }
    }
}
