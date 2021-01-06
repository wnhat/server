using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class OnInspectPanelContainer
    {
        SqlServerConnector Thesqlserver;
        Filecontainer Thefilecontainer;
        public Queue<PanelMission> MissionQueue;
        List<string> logger;

        public OnInspectPanelContainer(SqlServerConnector theSqlserver, Filecontainer theFileContainer)
        {
            this.Thefilecontainer = theFileContainer;
            this.Thesqlserver = theSqlserver;
            MissionQueue = new Queue<PanelMission>();
            logger = new List<string>();
        }

        public void AddMisionByServer()
        {
            // 获取SQL server近一小时的C52000N站点近一小时E级产品添加任务
            List<string> missionDataSet = Thesqlserver.get_oninspect_mission();
            foreach (var mission in missionDataSet)
            {
                // TODO: 当一张屏多次进入设备时返回的列表将不是单一值；
                var missionlist = Thefilecontainer.GetPanel(mission);
                if (missionlist != null)
                {
                    PanelPathContainer newPanelMissionPath = missionlist[0];
                    //MissionContainer.Add(new PanelMission(mission, mission_type.PRODUCITVE, newPanelMissionPath));
                    MissionQueue.Enqueue(new PanelMission(mission, mission_type.PRODUCITVE, newPanelMissionPath));
                }
                else
                {
                    logger.Add(String.Format("can not find panel path in the PathContainer, PanelId : {0}",mission));
                }
            }
        }
        public PanelMission GetMission()
        {
            PanelMission returnpanel = MissionQueue.Dequeue();
            return returnpanel;
        }
    }
}
