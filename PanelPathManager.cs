using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class PanelPathManager
    {
        Dictionary<string, List<PanelPathContainer>> theContainer = new Dictionary<string, List<PanelPathContainer>>();
        private readonly object ContainerLock = new object();

        public void PanelPathAdd(PanelPathContainer thispanel)
        {
            lock (ContainerLock)
            {
                if (theContainer.ContainsKey(thispanel.Panel_id))
                {
                    theContainer[thispanel.Panel_id].Add(thispanel);
                }
                else
                {
                    theContainer.Add(thispanel.Panel_id, new List<PanelPathContainer> { thispanel });
                }
            }
        }

        public void PanelPathAdd(List<PanelPathContainer> panelList)
        {
            foreach (var panel in panelList)
            {
                PanelPathAdd(panel);
            }
        }

        public List<PanelPathContainer> PanelPathGet(string panelId,string eqId)
        {
            if (theContainer.ContainsKey(panelId))
            {
                return theContainer[panelId];
            }
            else
            {
                return null;
            }
        }

        //public PanelPathContainer PanelPathGetLatest(string panelId)
        //{
        //    if (theContainer.ContainsKey(panelId))
        //    {
        //        List<PanelPathContainer> returnlist = theContainer[panelId];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
