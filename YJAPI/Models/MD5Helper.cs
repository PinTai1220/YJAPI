using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace YJAPI.Models
{
    public static class CommonHelper
    {  // string 的扩展方法：必须声明在static类中
        public static string CalcMD5(this string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return CalcMD5(bytes);
        }
        /// <summary>
        /// 根据 byte 数组进行MD5 加密
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string CalcMD5(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(bytes);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" +
                    computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }

        /// <summary>
        /// 根据 流进行MD5加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string CalcMD5(Stream stream)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(stream);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" +
                    computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }

        /// <summary>
        /// 生成验证码封装一个生成 n 位验证码的函数，为了避免混淆，不生成'1'、 'l'、 '0'、 'o'等字符
        /// </summary>
        /// <returns></returns>
        public static string GenerateCaptchaCode(int len)
        {
            char[] data = { 'a', 'c', 'd', 'e', 'f', 'g', 'k', 'm', 'p', 'r', 's', 't', 'w', 'x', 'y', '3', '4', '5', '7', '8' };
            StringBuilder sbCode = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                char ch = data[rand.Next(data.Length)];             //[0,data.length)
                sbCode.Append(ch);
            }
            return sbCode.ToString();
        }
    }
}