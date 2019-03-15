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
    public class SessionidsController : ApiController
    {
        IDataservices<Sessionids, SessionidsBLL> bll = SessionidsBLL.GetInstance();
        [HttpPost]
        public int Create(Sessionids sessionids)
        {
            return bll.Create(sessionids);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }

        [HttpGet]
        public List<Sessionids> Show()
        {
            return bll.Show();
        }
        [HttpGet]
        public Sessionids ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(Sessionids sessionids)
        {
            return bll.Update(sessionids);
        }
    }
}
