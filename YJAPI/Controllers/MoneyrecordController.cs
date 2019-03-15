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
    public class MoneyrecordController : ApiController
    {
        IDataservices<Moneyrecord, MoneyrecordBLL> bll = MoneyrecordBLL.GetInstance();
        [HttpPost]
        public int Create(Moneyrecord moneyrecord)
        {
            return bll.Create(moneyrecord);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }

        [HttpGet]
        public List<Moneyrecord> Show()
        {
            return bll.Show();
        }
        [HttpGet]
        public Moneyrecord ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(Moneyrecord moneyrecord)
        {
            return bll.Update(moneyrecord);
        }
    }
}
