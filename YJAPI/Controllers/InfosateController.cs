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
    }
}
