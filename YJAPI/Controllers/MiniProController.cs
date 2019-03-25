using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
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
                wages = homeInfo.HomeInfo_InfoType==1?homeInfo.HomeInfo_Price:homeInfo.HomeInfo_AvgPrice,
                category = homeInfo.HomeInfo_PhotoPath,
                created_at = homeInfo.HomeInfo_CreateTime,
                home_details = homeInfo.HomeInfo_IntroDuce,
                contact_Name = homeInfo.HomeInfo_Contact,
                contact_Phone = homeInfo.HomeInfo_Phone
            };

            return info;
        }
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
        [HttpGet]
        public Users Login(string phone, string password)
        {
            password= CommonHelper.CalcMD5(password);
            Users user = userbll.Show().Where(c => c.User_Phone == phone && c.User_Pwd == password).FirstOrDefault();
            return user;
        }

        [HttpPost]
        public string ShowSessionKey(PostData postData)
        {
            string appid = "wx477e28346086d70d";
            string secret = "9b25ddb961e662bd7166a0448432dffe";
            string path = "https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + postData.code + "&grant_type=authorization_code";
            var result = JsonConvert.DeserializeObject<dynamic>(HttpClientHelper.Seng("get", path, null));
            string sessionKey = result.session_key;
            byte[] encDatas = Convert.FromBase64String(postData.enctypeData); //Encoding.UTF8.GetBytes(enctypeData);//
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Key = Convert.FromBase64String(sessionKey); // Encoding.UTF8.GetBytes(AesKey);
            rijndaelCipher.IV = Convert.FromBase64String(postData.iv);// Encoding.UTF8.GetBytes(AesIV);
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
            byte[] plainText = transform.TransformFinalBlock(encDatas, 0, encDatas.Length);
            string result1 = Encoding.Default.GetString(plainText);
            dynamic model = Newtonsoft.Json.Linq.JToken.Parse(result1) as dynamic;
            return model.phoneNumber;
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
    public class PostData
    {
        public string iv { get; set; }
        public string code { get; set; }
        public string enctypeData { get; set; }
    }
}
