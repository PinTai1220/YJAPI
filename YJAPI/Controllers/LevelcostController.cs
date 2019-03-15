using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YJModel;
using YJBLL;
using YJCommon;

namespace YJAPI.Controllers
{
    public class LevelcostController : ApiController
    {
        IDataservices<Levelcost, LevelcostBLL> bll = LevelcostBLL.GetInstance();
        [HttpPost]
        public int Create(Levelcost levelcost)
        {
            return bll.Create(levelcost);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }

        [HttpGet]
        public List<Levelcost> Show()
        {
            return bll.Show();
        }
        [HttpGet]
        public Levelcost ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(Levelcost levelcost)
        {
            return bll.Update(levelcost);
        }
    }
}
