using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YJBLL;
using YJCommon;
using YJModel;

namespace YJAPI.Controllers
{
    public class MiniProController : ApiController
    {
        IDataservices<HomeInfo, HomeInfoBLL> bll = HomeInfoBLL.GetInstance();
        [HttpGet]
        public List<infos> HomeInfos()
        {
            List<HomeInfo> homeInfos = bll.Show();
            homeInfos = homeInfos.Where(c => c.HomeInfo_InfoType == 1).ToList();
            List<infos> infos = new List<infos>();
            foreach (var item in homeInfos)
            {
                infos info = new infos
                {
                    id = item.HomeInfo_Id,
                    title = item.HomeInfo_Xq_Name,
                    district = item.HomeInfo_PosiTion,
                    payment_method = item.HomeInfo_Area,
                    wages = item.HomeInfo_Price,
                    category = item.HomeInfo_PhotoPath,
                    created_at = item.HomeInfo_CreateTime,
                    home_details = item.HomeInfo_IntroDuce,
                    contact_Name = item.HomeInfo_Contact,
                    contact_Phone = item.HomeInfo_Phone
                };
                infos.Add(info);
            }
            return infos;
        }

        [HttpGet]
        public infos HomeInfosById(int id)
        {
            HomeInfo homeInfo = bll.ShowById(id);
            infos info = new infos
            {
                id = homeInfo.HomeInfo_Id,
                title = homeInfo.HomeInfo_Xq_Name,
                district = homeInfo.HomeInfo_PosiTion,
                payment_method = homeInfo.HomeInfo_Area,
                wages = homeInfo.HomeInfo_Price,
                category = homeInfo.HomeInfo_PhotoPath,
                created_at = homeInfo.HomeInfo_CreateTime,
                home_details = homeInfo.HomeInfo_IntroDuce,
                contact_Name = homeInfo.HomeInfo_Contact,
                contact_Phone = homeInfo.HomeInfo_Phone
            };

            return info;
        }


        [HttpGet]
        public List<infos> HomeInfosByZuFang()
        {
            List<HomeInfo> homeInfos = bll.Show();
            homeInfos = homeInfos.Where(c => c.HomeInfo_InfoType == 2).ToList();
            List<infos> infos = new List<infos>();
            foreach (var item in homeInfos)
            {
                infos info = new infos
                {
                    id = item.HomeInfo_Id,
                    title = item.HomeInfo_Xq_Name,
                    district = item.HomeInfo_PosiTion,
                    payment_method = item.HomeInfo_Area,
                    wages = item.HomeInfo_Price,
                    category = item.HomeInfo_PhotoPath,
                    created_at = item.HomeInfo_CreateTime,
                    home_details = item.HomeInfo_IntroDuce,
                    contact_Name = item.HomeInfo_Contact,
                    contact_Phone = item.HomeInfo_Phone
                };
                infos.Add(info);
            }
            return infos;
        }


    }

    public class infos
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public string payment_method { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public double wages { get; set; }

        /// <summary>
        /// 房源图片
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// 房源介绍
        /// </summary>
        public string home_details { get; set; }

        public string contact_Name { get; set; }

        public string contact_Phone { get; set; }
    }
}
