using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using YJModel;
using YJCommon;
using YJBLL;

namespace YJAPI.Controllers
{
    public class InfosateController : ApiController
    {
        IDataservices<Infostate, InfostateBLL> bll = InfostateBLL.GetInstance();
        [HttpPost]
        public int Create(Infostate infostate)
        {
            return bll.Create(infostate);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }

        [HttpGet]
        public List<Infostate> Show()
        {
            return bll.Show();
        }
        [HttpGet]
        public Infostate ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(Infostate infostate)
        {
            return bll.Update(infostate);
        }
        public List<Infostate> GetByUid(int uid)
        {
            var result = bll.Show().Where(a => a.HomeInfo.HomeInfo_UserId == uid).ToList();
            return result;
        }
        public dynamic GetBystate(int pageindex,int pagesize,int state)
        {
            var list = bll.Show();
            var result = list.Where(a =>a.HomeInfo.HomeInfo_InfoType==state).ToList();
            var pagecount = (int)Math.Ceiling(result.Count * 1.0 / pagesize);
            result = result.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return new { pagecount,data=result};
        }
    }
}
