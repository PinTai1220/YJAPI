using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YJAPI.Models;
using YJBLL;
using YJCommon;
using YJModel;

namespace YJAPI.Controllers
{
    public class MiniProController : ApiController
    {
        IDataservices<HomeInfo, HomeInfoBLL> bll = HomeInfoBLL.GetInstance();
        IDataservices<Users, UsersBLL> userbll = UsersBLL.GetInstance();
        IDataservices<Attention, AttentionBLL> attBll = AttentionBLL.GetInstance();
        /// <summary>
        /// 显示所有的房屋信息
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 显示房屋的详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                wages = homeInfo.HomeInfo_InfoType == 1 ? homeInfo.HomeInfo_Price : homeInfo.HomeInfo_AvgPrice,
                category = homeInfo.HomeInfo_PhotoPath,
                created_at = homeInfo.HomeInfo_CreateTime,
                home_details = homeInfo.HomeInfo_IntroDuce,
                contact_Name = homeInfo.HomeInfo_Contact,
                contact_Phone = homeInfo.HomeInfo_Phone
            };

            return info;
        }
        /// <summary>
        /// 轮播图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<dynamic> GetSwiper()
        {
            List<dynamic> strs = new List<dynamic>()
            {
                new
                {
                    image = "http://localhost:17547/Images/b2.jpg"
                },
                new
                {
                    image = "http://localhost:17547/Images/d1.jpg"
                },
                new
                {
                    image = "http://localhost:17547/Images/g1.jpg"
                }
            };
            return strs;
        }
        /// <summary>
        /// 显示所有的租房信息
        /// </summary>
        /// <returns></returns>

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
                    wages = item.HomeInfo_AvgPrice,
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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public Users Login(string userphone, string password)
        {
            password = CommonHelper.CalcMD5(password);
            Users user = userbll.Show().Where(c => c.User_Phone == userphone && c.User_Pwd == password).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="homeId">房屋编号</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public int InsCol(int userId, int homeId)
        {
            Attention attention = new Attention()
            {
                Attention_Uid = userId,
                Attention_Infoids = homeId
            };
            return attBll.Create(attention);
        }

        /// <summary>
        /// 移除收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public int DelCol(int id)
        {
            return attBll.Delete(id);
        }

        /// <summary>
        /// 主页删除收藏
        /// </summary>
        /// <param name="homeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public int DelCol(int homeId, int userId)
        {
            Attention attention = attBll.Show().Where(c => c.Attention_Infoids == homeId && c.Attention_Uid == userId).FirstOrDefault();
            int id = attention.Attention_Id;
            return attBll.Delete(id);
        }

        /// <summary>
        /// 查询某用户是否已经添加了收藏
        /// </summary>
        /// <param name="homeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public int ExistsCol(int homeId, int userId)
        {
            Attention attention = attBll.Show().Where(c => c.Attention_Uid == userId && c.Attention_Infoids == homeId).FirstOrDefault();
            if (attention is null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 显示某用户的所有收藏
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<collects> ShowCol(int userId)
        {
            List<Attention> attentions = attBll.Show().Where(c => c.Attention_Uid == userId).ToList();
            List<collects> infos = new List<collects>();

            foreach (var item in attentions)
            {
                collects info = new collects
                {
                    id = item.Attention_Id,
                    hid = item.HomeInfo.HomeInfo_Id,
                    title = item.HomeInfo.HomeInfo_Xq_Name,
                    district = item.HomeInfo.HomeInfo_PosiTion,
                    payment_method = item.HomeInfo.HomeInfo_Area,
                    wages = item.HomeInfo.HomeInfo_InfoType == 1 ? item.HomeInfo.HomeInfo_Price : item.HomeInfo.HomeInfo_AvgPrice,
                    category = item.HomeInfo.HomeInfo_PhotoPath
                };
                infos.Add(info);
            }

            return infos;
        }
        [HttpGet]
        public List<infos> ShowHomeIds(int userId)
        {
            List<Attention> attentions = attBll.Show().Where(c => c.Attention_Uid == userId).ToList();

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
                    state = attentions.Select(c => c.Attention_Infoids == item.HomeInfo_Id).Count()>0? 1 : 0
                    
                };
                infos.Add(info);
            }
            return infos;
        }
    }

    public class collects
    {
        public int id { get; set; }
        public int hid { get; set; }
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

        public int state { get; set; }
    }
}
