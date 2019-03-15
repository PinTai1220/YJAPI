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
    public class DeveloperController : ApiController
    {
        IDataservices<Developers_apply_for, Developers_apply_forBLL> bll = Developers_apply_forBLL.GetInstance();
        [HttpPost]
        public int Create(Developers_apply_for developers)
        {
            return bll.Create(developers);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }

        [HttpGet]
        public List<Developers_apply_for> Show()
        {
            return bll.Show();
        }
        [HttpGet]
        public Developers_apply_for ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(Developers_apply_for developers)
        {
            return bll.Update(developers);
        }
    }
}
