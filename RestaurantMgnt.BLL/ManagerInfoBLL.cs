using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMgnt.Model;
using RestaurantMgnt.DAL;


namespace RestaurantMgnt.BLL
{
    public partial class ManagerInfoBLL
    {
        ManagerInfoDAL managerInfoDAL = new ManagerInfoDAL();

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns>数据集</returns>
        public List<ManagerInfo> GetList()
        {
            return managerInfoDAL.GetManagerInfoList();
        }

        /// <summary>
        /// 判断DAL层的数据是否插入成功
        /// </summary>
        /// <param name="managerInfo">ManagerInfo类型的对象</param>
        /// <returns>数据插入结果</returns>
        public bool AddManagerInfo(ManagerInfo managerInfo)
        {
            return managerInfoDAL.InsertManagerInfo(managerInfo) > 0;
        }
    }
}
 