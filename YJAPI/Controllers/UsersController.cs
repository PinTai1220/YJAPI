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
    public class UsersController : ApiController
    {
        IDataservices<Users, UsersBLL> bll = UsersBLL.GetInstance();
        [HttpPost]
        public int Create(Users users)
        {
            return bll.Create(users);
        }
        [HttpGet]
        public int Delete(int id)
        {
            return bll.Delete(id);
        }

        [HttpGet]
        public List<Users> Show()
        {
            return bll.Show();
        }
        [HttpGet]
        public Users ShowById(int id)
        {
            return bll.ShowById(id);
        }
        [HttpPost]
        public int Update(Users users)
        {
            return bll.Update(users);
        }
    }
}
