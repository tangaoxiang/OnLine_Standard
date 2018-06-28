using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.BLL;
using DigiPower.Onlinecol.Standard.Model;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Reflection;
using System.Text;

using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;
using System.Security.Cryptography;

namespace DigiPower.Onlinecol.Standard.Web {
    public class RequestHandler : IHttpHandler, IRequiresSessionState {
        public void ProcessRequest(HttpContext context) {
            string FileType = DNTRequest.GetQueryString("FileType");
            if (String.IsNullOrWhiteSpace(FileType))
                FileType = context.Request.Form["FileType"];

            string ReturnValue = "";
            switch (FileType) {
                case "login":   //登录
                    ReturnValue = getUserInfo(context);
                    break;
                case "getQuestion": //获取系统帮助详情
                    ReturnValue = getQuestionString();
                    break;
                case "getMenu":     //根据角色获取用户对应的菜单
                    ReturnValue = getMenuJsonByUserId(context);
                    break;
                case "logOut":      //退出系统
                    ReturnValue = logOut(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(ReturnValue);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string getUserInfo(HttpContext context) {
            try {
                if (context.Request.Form["username"] == null || context.Request.Form["password"] == null)
                    return "账号或密码为空!";

                T_UsersInfo_BLL userinfobll = new T_UsersInfo_BLL();

                string strPrivateKey = string.Empty;
                using (StreamReader reader = new StreamReader(context.Server.MapPath("/RsaKey/PrivateKey.xml"))) {
                    strPrivateKey = reader.ReadToEnd();
                }

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(strPrivateKey);

                byte[] result = rsa.Decrypt(UserLoginGather.HexStringToBytes(context.Request.Form["password"]), false);
                System.Text.ASCIIEncoding enc = new ASCIIEncoding();
                string rsaPwd = enc.GetString(result);

                string loginString = "UPPER(loginname)='" + Common.Common.SqlSafe(context.Request.Form["username"]).ToUpper()
                    + "' and passwd='" + DESEncrypt.Encrypt(rsaPwd) + "' ";

                List<T_UsersInfo_MDL> userinfomdl = userinfobll.GetModelList(loginString);
                if (userinfomdl.Count > 0) {
                    if (userinfomdl[0].IsValid == true) {
                        T_Company_BLL compBLL = new T_Company_BLL();
                        T_Company_MDL compMDL = compBLL.GetModel(userinfomdl[0].CompanyID);
                        if (compMDL != null) {
                            context.Session["IsCompany"] = compMDL.IsCompany.ToString().ToLower();
                            context.Session["CompanyName"] = compMDL.CompanyName;
                            context.Session["OLD_AREA_CODE"] = compMDL.AREA_CODE;
                            context.Session["AREA_CODE"] = "";
                            if (compMDL.IsCompany.ToString().ToLower() == "false") {   //只有档案馆，需要区域信息，建设单位等都不要过虑                        
                                string myArea_Code = compMDL.AREA_CODE;
                                string myArea_CodeNew = compMDL.AREA_CODE;
                                for (int i1 = myArea_Code.Length - 1; i1 > 0; i1--) {
                                    if (myArea_Code[i1].ToString() == "0") {
                                        myArea_CodeNew = myArea_Code.Substring(0, i1);
                                    } else {
                                        break;
                                    }
                                }
                                context.Session["AREA_CODE"] = myArea_CodeNew;
                            }
                            context.Session["CompanyType"] = compMDL.CompanyType;
                        } else {
                            return SystemSet._RETURN_FAILURE_VALUE + ":单位信息不存在!";
                        }

                        BLL.T_SystemInfo_BLL systemInfoBLL = new T_SystemInfo_BLL();
                        Model.T_SystemInfo_MDL systemInfoMDL = systemInfoBLL.GetModel(compMDL.CompanyType);
                        if (systemInfoMDL == null) return SystemSet._RETURN_FAILURE_VALUE + ":单位类型字典不存在!";

                        context.Session["CompanyTypeName"] = systemInfoMDL.SystemInfoName;
                        context.Session["CompanyTypeCode"] = systemInfoMDL.SystemInfoCode;
                        context.Session["SystemInfoID"] = systemInfoMDL.SystemInfoID;
                        context.Session["MyParentID"] = systemInfoMDL.ParentID;

                        context.Session["UserID"] = userinfomdl[0].UserID;
                        context.Session["LoginName"] = userinfomdl[0].LoginName;
                        context.Session["UserName"] = userinfomdl[0].UserName;
                        context.Session["RoleID"] = userinfomdl[0].RoleID;
                        context.Session["CompanyID"] = userinfomdl[0].CompanyID;
                        context.Session["IsLeader"] = userinfomdl[0].IsLeader;
                        context.Session["SuperAdmin"] = userinfomdl[0].IsSuperAdmin;
                        context.Session["OwnerFileTmp"] = userinfomdl[0].OwnerFileTmp;     //外协单位用户

                        T_Role_MDL roleMDL = new T_Role_BLL().GetModel(userinfomdl[0].RoleID);  //签章用
                        if (roleMDL != null) {
                            context.Session["RoleName"] = roleMDL.RoleName;
                            context.Session["RoleCode"] = roleMDL.RoleCode;
                        }

                        TimeSpan ts = new TimeSpan(8760, 0, 0);
                        DateTime expired = DateTime.Today.Add(ts);
                        HttpContext.Current.Response.Cookies["LoginName"].Value = context.Server.UrlEncode(userinfomdl[0].LoginName);
                        HttpContext.Current.Response.Cookies["LoginName"].Expires = expired;

                        //修改最后登录时间
                        userinfomdl[0].LastLoginTime = DateTime.Now;
                        userinfobll.Update(userinfomdl[0]);

                        PublicModel.writeLog(SystemSet.EumLogType.LogIn.ToString(), ";用户登录系统");
                        return SystemSet._RETURN_SUCCESS_VALUE;
                    } else {
                        return "如果您已经成功注册，请等待确认后再登录!";
                    }
                } else {
                    return "用户账号或密码错误!";
                }
            } catch (Exception ex) {
                Common.LogUtil.Debug(this, "用户登录BUG", ex);
                return "系统异常,请稍后再试";
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string logOut(HttpContext context) {
            PublicModel.writeLog(SystemSet.EumLogType.LogOut.ToString(), ";用户退出系统");

            context.Session.Abandon();
            context.Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return SystemSet._RETURN_SUCCESS_VALUE;
        }

        /// <summary>
        /// 获取系统帮助详情
        /// </summary>
        /// <returns></returns>
        public string getQuestionString() {
            string strString = string.Empty;

            var tb = new T_Question_BLL().GetList(" QuestionID=" + DNTRequest.GetQueryString("questionID")).Tables[0];
            if (tb != null && tb.Rows.Count > 0)
                strString = Common.Common.DataTableToJson(tb);

            return strString;
        }

        /// <summary>
        ///根据用户角色返回其对应所有菜单 JSON
        /// </summary>
        /// <returns></returns>
        public string getMenuJsonByUserId(HttpContext context) {
            string ReturnValue = string.Empty;
            if (context.Session["RoleID"] != null) {
                DataTable dt = new T_Module_BLL().GetListByRole(" AND IfVisible=1 and ModuleID!=181 and RoleID=" + context.Session["RoleID"]).Tables[0];
                if (dt != null && dt.Rows.Count > 0) {
                    DataTable newDt = new DataTable();
                    newDt.Columns.Add(new DataColumn("id"));
                    newDt.Columns.Add(new DataColumn("parentId"));
                    newDt.Columns.Add(new DataColumn("name"));
                    newDt.Columns.Add(new DataColumn("url"));
                    newDt.Columns.Add(new DataColumn("order"));
                    newDt.Columns.Add(new DataColumn("isHeader"));
                    newDt.Columns.Add(new DataColumn("icon"));

                    foreach (DataRow dr in dt.Rows) {
                        AddRow(newDt, ConvertEx.ToString(dr["ModuleID"]),
                            ConvertEx.ToInt(dr["ParentID"]) == 0 ? "1" : ConvertEx.ToString(dr["ParentID"]),
                            ConvertEx.ToString(dr["ModuleName"]),
                            ConvertEx.ToString(dr["FileName"]), "1", 0,
                            ConvertEx.ToInt(dr["ParentID"]) == 0 ? "&#xe604;" : "");
                    }

                    AddRow(newDt, "1", "0", "主菜单", "", "1", "1", "");
                    ReturnValue = Common.Common.DataTableToJson(newDt);
                }
            }
            return ReturnValue;
        }

        private void AddRow(DataTable dt, params object[] obj) {
            DataRow newRow = dt.NewRow();
            newRow["id"] = obj[0];
            newRow["parentId"] = obj[1];
            newRow["name"] = obj[2];
            newRow["url"] = obj[3];
            newRow["order"] = obj[4];
            newRow["isHeader"] = obj[5];
            newRow["icon"] = obj[6];
            dt.Rows.Add(newRow);
        }

        private void Recursion(DataTable dt, int parentID) {
            DataRow[] dr = dt.Select("ParentID=" + parentID + "", "OrderIndex");
            foreach (DataRow drr in dr) {
                Recursion(dt, ConvertEx.ToInt(drr["ModuleID"]));
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}