using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMgnt.Model;
using RestaurantMgnt.Utility;


namespace RestaurantMgnt.DAL
{
    public partial  class ManagerInfoDAL
    {
        string sql = string.Empty;
        /// <summary>
        /// 查询获取结果集
        /// </summary>
        /// <returns>结果集</returns>
        public List<ManagerInfo> GetManagerInfoList () 
        {
            sql = "Select * from ManagerInfo";
            DataTable dt = SQLiteHelper.GetDataTable(sql);
            List<ManagerInfo> list = new List<ManagerInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ManagerInfo()
                             {
                                 ManagerId = Convert.ToInt32(row["mid"]),
                                 ManagerName = row["mname"].ToString(),
                                 ManagerPassword = row["mpwd"].ToString(),
                                 ManagerType = Convert.ToInt32(row["mtype"])
                              }
                         );
            }
            return list;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="managerInfo">ManagerInfo类型的对象</param>
        /// <returns>受影响行数</returns>
        public int InsertManagerInfo(ManagerInfo managerInfo)
        {
            sql = "Insert into ManagerInfo(mname,mpwd,mtype) Values(@name,@password,@type)";
            SQLiteParameter[] sp =
                {
                    new SQLiteParameter("@name",managerInfo.ManagerName),
                    new SQLiteParameter("@password", EncryptHelper.EncryptString(managerInfo.ManagerPassword) ),
                    new SQLiteParameter("@type",managerInfo.ManagerType)
                };
            return SQLiteHelper.ExecuteNonQuery(sql, sp); 
        }
    }
}
