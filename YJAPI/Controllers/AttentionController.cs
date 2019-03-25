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
    public class AttentionController : ApiController
    {
        IDataservices<Attention, AttentionBLL> bll = AttentionBLL.GetInstance();
        //public dynamic ResponeGet(int id)
        //{
        //    Attention att = bll.ShowById(id);
        //    if (att == null)
        //    {
        //        if (bll.Create(new Attention() { Attention_Id=0,Attention_Uid=id,Attention_Infoids=""}) > 0)
        //            return new
        //            {
        //                datacount = 0,
        //                msg = "记录创建成功",
        //                data = new List<dynamic>()
        //            };
        //        else
        //            return new
        //            {
        //                datacount = 0,
        //                msg = "记录创建失败",
        //                data = new List<dynamic>()
        //            };
        //    }
        //    else
        //    {
        //        string[] ids = att.Attention_Infoids.Split(',');
        //        List<Attention> atts = new List<Attention>();
        //        Attention attention = null;
        //        for (int i = 0; i < ids.Length; i++)
        //        {
        //            attention = bll.ShowById(Convert.ToInt32(ids[i]));
        //        }
        //        return new
        //        {
        //            datacount = atts.Count,
        //            msg = "记录获取成功",
        //            data = atts
        //        };
        //    }
        //}
        //public int upt(Attention t)
        //{
        //    return bll.Update(t);
        //}
    }
}
