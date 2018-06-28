using DigiPower.Onlinecol.Standard.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiPower.Onlinecol.Standard.Web
{
    /// <summary>
    /// OfficeServer 的摘要说明。
    /// </summary>
    public partial class ReportPDFServer : System.Web.UI.Page
    {
        private string mFilePath;
        private string mOption;
        private string mRecordID;

        public string singleProjectID = string.Empty;         //工程ID
        public string pdfFileName = string.Empty;             //报表PDF文件路径

        private DBstep.iMsgServer2000 MsgObj;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            singleProjectID = DNTRequest.GetQueryString("singleProjectID");
            pdfFileName = DNTRequest.GetQueryString("pdfFileName");

            // 在此处放置用户代码以初始化页面

            MsgObj = new DBstep.iMsgServer2000();

            //mFilePath = Path.Combine(mFilePath, "Document");
            MsgObj.MsgVariant(Request.BinaryRead(Request.ContentLength));
            if (MsgObj.GetMsgByName("DBSTEP").Equals("DBSTEP"))             //如果是合法的信息包
            {
                mOption = MsgObj.GetMsgByName("OPTION");
                mRecordID = MsgObj.GetMsgByName("RECORDID");	  //取得文档编号
                mFilePath = GetFilePath(mRecordID);              //取得操作信息


                //string tmpFileName = Path.GetFileNameWithoutExtension(mFileName) + ".tmp";
                if (mOption.Equals("LOADFILE"))						                       //下面的代码为打开服务器数据库里的文件
                {
                    mRecordID = MsgObj.GetMsgByName("RECORDID");	       //取得文档编号
                    //mFilePath = GetFilePath(mRecordID, out mFileName);
                    if (System.IO.File.Exists(mFilePath))
                    {

                        //tmpFileName = Guid.NewGuid().ToString() + Path.GetExtension(mFileName);
                        //if (!System.IO.File.Exists(mFilePath + "\\" + tmpFileName))
                        //    System.IO.File.Copy(mFilePath + "\\" + mFileName, mFilePath + "\\" + tmpFileName);
                        //清除文本信息
                        MsgObj.MsgTextClear();                                                    //清除文本信息
                        if (MsgObj.MsgFileLoad(mFilePath)) //读取临时文件
                        {
                            MsgObj.SetMsgByName("STATUS", "打开成功!.");		   //设置状态信息
                            MsgObj.MsgError(string.Empty);
                            MsgObj.MsgTextClear();             //清除错误信息
                        }
                        else
                            MsgObj.MsgError("打开失败!");		                                  //设置错误信息
                    }
                    else
                        MsgObj.MsgError("打开失败!");		                                  //设置错误信息

                }
                else if (mOption.Equals("SAVEFILE"))					                          //下面的代码为保存文件在服务器的数据库里
                {
                    MsgObj.MsgTextClear();                                                    //清除文本信息


                    if (MsgObj.MsgFileSave(mFilePath))						  //保存文档内容到文件夹中
                    {
                        MsgObj.SetMsgByName("STATUS", "保存成功!");	                          //设置状态信息
                        MsgObj.MsgError("");						                          //清除错误信息
                        MsgObj.MsgFileClear();
                    }
                    else
                    {
                        //MsgObj.MsgError("保存失败!");		                                  //设置错误信息
                        MsgObj.MsgError("Error:packet message");
                        MsgObj.MsgTextClear();
                        MsgObj.MsgFileClear();
                    }
                }
            }
            else
            {
                MsgObj.MsgError("Error:packet message");
                MsgObj.MsgTextClear();
                MsgObj.MsgFileClear();
            }
            MsgObj.Send(Response);
            //Response.BinaryWrite(MsgObj.MsgVariant());
        }

        public string GetFilePath(string id)
        {
            string pdfFilePathName = string.Empty;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("/Upload/TempReport/" + pdfFileName))) //存放报表的PDF 
            {
                pdfFilePathName = HttpContext.Current.Server.MapPath("/Upload/TempReport/" + pdfFileName);
            }
            else
            {
                Common.MessageBox.ShowAndCloseWin(this, "没有文件,无法签章！");
            }
            return pdfFilePathName;
        }
    }
}