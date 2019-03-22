using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using YJModel;
using YJBLL;
using YJCommon;
using Newtonsoft.Json;

namespace YJAPI.Controllers
{
    public class HomeInfoController : ApiController
    {
        IDataservices<HomeInfo, HomeInfoBLL> bll = HomeInfoBLL.GetInstance();
        [HttpPost]
        public int Create(HomeInfo homeInfo)
        {
            return bll.Create(homeInfo);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }                                                                                                                                              

        [HttpGet]
        public List<HomeInfo> Show()
        {
            return bll.Show();
        }

        [HttpGet]
        public HomeInfo ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(HomeInfo homeInfo)
        {
            return bll.Update(homeInfo);
        }
    }
}
