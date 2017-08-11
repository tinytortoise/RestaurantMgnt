using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMgnt.Utility
{
    public partial class EncryptHelper
    {
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] oldByte = Encoding.UTF8.GetBytes(str);//字符串转换成字节数组
            byte[] newByte =  md5.ComputeHash(oldByte);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in newByte)
            {
                sb.Append(b.ToString("x2"));//x2:十六进制,恒占用两位
            }
            return sb.ToString();
        }

    }
}
