using System;
using System.Collections.Generic;
using System.Text;
using LTP.Common;
using DigiPower.Onlinecol.Standard.Model;
using System.Data;

namespace DigiPower.Onlinecol.Standard.BLL
{
    public class T_SingleProject_PIC_BLL
    {
        private readonly DigiPower.Onlinecol.Standard.DAL.T_SingleProject_PIC_DAL dal = new DigiPower.Onlinecol.Standard.DAL.T_SingleProject_PIC_DAL();
        public T_SingleProject_PIC_BLL()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DigiPower.Onlinecol.Standard.Model.T_SingleProject_PIC_MDL model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 根据单位取工程
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public DataSet GetListByProjectidId(int projectid)
        {
            return dal.GetListByProjectidId(projectid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SingleProjectID)
        {
            dal.Delete(SingleProjectID);
        }

        public void Update(int SingleProjectID,string title)
        {
            dal.Update(SingleProjectID, title);
        }

        public DataSet GetListBysId(int sid)
        {
            return dal.GetListBysId(sid);
        }
    }
}
