using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YJAPI.Models;
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

        public SelectInfo ShowBySelect(string str, int pageIndex, int pageSize, string type)
        {
            List<Users> users = bll.Show();

            SelectInfo selectInfo = new SelectInfo();
            selectInfo.Count = users.Count;

            users = users.Take((pageIndex - 1) * pageSize).Skip(pageSize).Where(c => c.User_Phone.Contains(str) || c.User_Wx_Name.Contains(str) || c.User_Wx_Sex == (str == "男" ? 1 : 0)).ToList();
            if (string.IsNullOrEmpty(type)) users.Where(c => c.User_Type.Equals(type));

            selectInfo.Users = users;
            return selectInfo;
        }
    }

    public class SelectInfo
    {
        public int Count { get; set; }
        public List<Users> Users { get; set; }
    }
}
