using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    //房屋信息表
    public class HomeInfo
    {
        [Key]
        public int homeinfo_Id { get; set; }//标识列   主键
        [ForeignKey("UserInfo")]
        public int homeinfo_Userid { get; set; }//用户id   外键
        public Users UserInfo { get; set; }
        public string homeinfo_xq_Name { get; set; }//小区名称
        public string homeinfo_Area { get; set; }//建筑面积
        public float homeinfo_Avgprice { get; set; }//均价
        public string homeinfo_Introduce { get; set; }//介绍
        public int homeinfo_Istao { get; set; }//单位(套)
        public float homeinfo_Price { get; set; }//价格
        public string homeinfo_Photopath { get; set; }//图片路径
        public string homeinfo_Position { get; set; }//位置
        public float homeinfo_Longitude { get; set; }//经度
        public float homeinfo_Latitude { get; set; }//纬度
        public string homeinfo_Contact { get; set; }//联系人
        public string homeinfo_Phone { get; set; }//联系方式
        public string homeinfo_Ctime { get; set; }//联系时间
        public int homeinfo_Infotype { get; set; }//信息类型(出售，出租，楼盘)
        public string homeinfo_Environment { get; set; }//环境(露台，多阳台，单阳台，干湿分离，套房...)
        public string homeinfo_Createtime { get; set; }//信息添加日期
    }
}
