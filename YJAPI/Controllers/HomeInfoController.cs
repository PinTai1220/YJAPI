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

using StackExchange.Redis;

namespace YJAPI.Controllers
{
    public class HomeInfoController : ApiController
    {
        private static readonly object Locker = new object();
        private static ConnectionMultiplexer redisConn;
        public static ConnectionMultiplexer GetRedisConn()
        {
            if (redisConn == null)
            {
                lock (Locker)
                {
                    if (redisConn == null || !redisConn.IsConnected)
                    {
                        redisConn = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    }
                }
            }
            return redisConn;
        }

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
            redisConn = GetRedisConn();
            var db = redisConn.GetDatabase(0);
            List<HomeInfo> homes = bll.Show();
            string strResult = JsonConvert.SerializeObject(homes);
            if (!db.KeyExists("HomeInfo"))
            {
                db.StringSet("HomeInfo", strResult);
                db.KeyExpire("HomeInfo", DateTime.Now.AddMinutes(2));
            }
            homes = JsonConvert.DeserializeObject<List<HomeInfo>>(strResult);
            return homes;
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
        [HttpGet]
        public dynamic getinfobypage(int pageindex, int pagesize)
        {
            HomeInfoBLL hbll = bll as HomeInfoBLL;
            var data = hbll.ShowBySome(pageindex, pagesize);
            return data;
        }
        public List<HomeInfo> GetByUid(int uid)
        {
            return bll.Show().Where(s => s.HomeInfo_UserId == uid).ToList();
        }
    }
}
