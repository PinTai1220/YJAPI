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
    public class DaycostController : ApiController
    {
        IDataservices<Daycost, DaycostBLL> bll = DaycostBLL.GetInstance();

        [HttpPost]
        public int Create(Daycost daycost)
        {
            return bll.Create(daycost);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }

        [HttpGet]
        public List<Daycost> Show()
        {
            return bll.Show();
        }
        [HttpGet]
        public Daycost ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(Daycost daycost)
        {
            return bll.Update(daycost);
        }
    }
}
