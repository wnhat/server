using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    enum judge_grade
    {
        S,
        A,
        T,
        Q,
        W,
        D,
        E,
        F,
    }
    enum mission_type
    {
        PRODUCITVE,
        INS_CHECK,
    }

    struct Disk_part
    {
        string F_DRIVE { get { return "F_Drive"; } }
        string G_DRIVE { get { return "G_Drive"; } }
        string H_DRIVE { get { return "H_Drive"; } }
        string I_DRIVE { get { return "I_Drive"; } }
        string J_DRIVE { get { return "J_Drive"; } }
        string K_DRIVE { get { return "K_Drive"; } }
        string L_DRIVE { get { return "L_Drive"; } }
        string M_DRIVE { get { return "M_Drive"; } }
        string N_DRIVE { get { return "N_Drive"; } }
        string O_DRIVE { get { return "O_Drive"; } }
        string P_DRIVE { get { return "P_Drive"; } }
        string Q_DRIVE { get { return "Q_Drive"; } }
        string R_DRIVE { get { return "R_Drive"; } }
        string S_DRIVE { get { return "S_Drive"; } }
        public List<string> getall
        {
            get {
                return new List<string>{ "F_Drive", "G_Drive" , "H_Drive" , "I_Drive" , "J_Drive" ,
                    "K_Drive" , "L_Drive" , "M_Drive" , "N_Drive" , "O_Drive" , "P_Drive", "Q_Drive", "R_Drive", "S_Drive" };
                }
        }
    }

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
    }

    class Panel_path_container
    {
        public string Panel_id;
        public string Origin_image_path;
        public string Result_path;
        public string Pc_name;
        public int Eq_id;
        public string Disk_name;

        public Panel_path_container(string panel_id, string origin_image_path, string result_path,int eq_id, string pc_name,string disk_name)
        {
            this.Panel_id = panel_id;
            this.Origin_image_path = origin_image_path;
            this.Result_path = result_path;
            this.Eq_id = eq_id;
            this.Pc_name = pc_name;
            this.Disk_name = disk_name;
        }

    }

    class mission_panel
    {
        public string panel_id { get; set; }
        public string repetition { get; set; }
        public panel_judge_table panel_judge { get; set; }
        public mission_type type { get; set; }
    }

    class panel_judge_table
    {

    }

    class panel_judgement
    {
        public Operator op;
        public judge_grade Judge;

    }

    class Operator
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    class PC
    {
        public int eq_id { get; set; }
        public string pc_ip { get; set; }
        public string pc_name { get; set; }
        public string pc_side { get; set; }

        public bool is_pc_in_type(List<int> eq_id_list, List<string> pc_name_list, List<string> pc_side_list)
        {
            if (eq_id_list.Contains(eq_id) & pc_name_list.Contains(pc_name) & pc_side_list.Contains(pc_side))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Pc_container
    {
        public List<PC> pc_list_all { get; set; }
    }

    class pc_manager : PC
    {
        public List<string> log_list { get; set; }
        // virtual public void Serch_file() {}
        // TODO: use log lib;
    }

    class Product_mission_panel
    {
        public string panel_id { get; set; }
        public string repetition { get; set; }
        public panel_judge_table panel_judge { get; set; }
    }

    class panel_judge_table
    {

    }

    class panel_judgement
    {
        Operator op;
        judge_grade Judge;

    }

    class Operator
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
