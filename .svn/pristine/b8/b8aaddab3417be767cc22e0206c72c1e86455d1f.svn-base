using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Configuration;
using DigiPower.Onlinecol.Standard.Common;
using DigiPower.Onlinecol.Standard.Model;
using DigiPower.Onlinecol.Standard.BLL;

namespace DigiPower.Onlinecol.Standard.Web {
    public static class SystemSet {
        /// <summary>
        ///案卷密级:秘密 字典KEY
        /// </summary>
        public static readonly string _DEFAULT_ARCHIVE_MJ = ConfigurationManager.AppSettings["DefaultArchive_mj"].Trim();

        /// <summary>
        /// 案卷保管期限:永久 字典KEY
        /// </summary>
        public static readonly string _DEFAULT_ARCHIVE_BGQX = ConfigurationManager.AppSettings["DefaultArchive_bgqx"].Trim();

        /// <summary>
        /// 档案馆字典ID
        /// </summary>
        public static readonly int _ARCHIVE = ConvertEx.ToInt(ConfigurationManager.AppSettings["ARCHIVE"]);

        /// <summary>
        /// 建设单位字典ID
        /// </summary>
        public static readonly int _JSCOMPANYINFO = ConvertEx.ToInt(ConfigurationManager.AppSettings["JSCompanyInfo"]);

        /// <summary>
        /// 监理单位字典ID
        /// </summary>
        public static readonly int _JLCOMPANYINFO = ConvertEx.ToInt(ConfigurationManager.AppSettings["JLCompanyInfo"]);

        /// <summary>
        /// 施工单位字典ID
        /// </summary>
        public static readonly int _SGCOMPANYINFO = ConvertEx.ToInt(ConfigurationManager.AppSettings["SGCompanyInfo"]);

        /// <summary>
        /// 签章单位字典ID
        /// </summary>
        public static readonly int _SIGNATURECOMPANYINFO = ConvertEx.ToInt(ConfigurationManager.AppSettings["SignatureCompanyInfo"]);

        /// <summary>
        /// 外协单位(安监,质监,检测等)字典ID
        /// </summary>
        public static readonly int _OUTHELPCOMPANYINFO = ConvertEx.ToInt(ConfigurationManager.AppSettings["OutHelpCompanyInfo"]);

        /// <summary>
        /// 工程受理,工作日超时期限
        /// </summary>
        public static readonly int _RECTIMEOUTDAYS = ConvertEx.ToInt(ConfigurationManager.AppSettings["RecTimeOutDays"]);

        /// <summary>
        /// 文件登记上传文件格式
        /// </summary>
        public static readonly string _FILELISTFILEEXT = ConfigurationManager.AppSettings["FileListFileExt"].Trim();

        /// <summary>
        /// 上传单份文件大小 M为单位
        /// </summary>
        public static readonly string _FILESIZE = ConfigurationManager.AppSettings["FileSize"].Trim();

        /// <summary>
        /// 工程入库后能否查看PDF,默认可以
        /// </summary>
        public static readonly bool _RKLOOKPDFFLAG = ConvertEx.ToBool(ConfigurationManager.AppSettings["RKLookPDFFlag"]);

        /// <summary>
        /// 工程报建确认是否发邮件通知
        /// </summary>
        public static readonly bool _ACCEPTSINGLE_SENDEMAILFLAG = ConvertEx.ToBool(ConfigurationManager.AppSettings["AcceptSingleSendEmailFlag"]);

        /// <summary>
        /// 每页页数
        /// </summary>
        public static readonly int _PAGESIZE = ConvertEx.ToInt(ConfigurationManager.AppSettings["PageSize"]);

        /// <summary>
        /// 默认登录密码
        /// </summary>
        public static readonly string _DEFAULTPWD = ConfigurationManager.AppSettings["DefaultPwd"].Trim();

        /// <summary>
        /// 操作成功返回字符串 success
        /// </summary>
        public static readonly string _RETURN_SUCCESS_VALUE = "success";

        /// <summary>
        /// 操作失败返回字符串 failure
        /// </summary>
        public static readonly string _RETURN_FAILURE_VALUE = "failure";

        /// <summary>
        /// 工程登记注册,提示电话
        /// </summary>
        public static readonly string _QUICKREGTEL = ConfigurationManager.AppSettings["QuickRegTel"].Trim();

        /// <summary>
        /// 菜单权限按钮代码
        /// </summary>
        public static readonly string _MENURIGHTCHAR = ConfigurationManager.AppSettings["MenuRightChar"].Trim();

        /// <summary>
        ///流程权限按钮代码
        /// </summary>
        public static readonly string _WORKFLOWRIGHTCHAR = ConfigurationManager.AppSettings["WorkFlowRightChar"].Trim();

        /// <summary>
        /// 建设单位角色编号
        /// </summary>
        public static readonly string _ROLECODE_JSCOMPANY = ConfigurationManager.AppSettings["RoleCode_JSCompany"].Trim();

        /// <summary>
        /// 施工单位角色编号
        /// </summary>
        public static readonly string _ROLECODE_SGCOMPANY = ConfigurationManager.AppSettings["RoleCode_SGCompany"].Trim();

        /// <summary>
        ///监理单位角色编号
        /// </summary>
        public static readonly string _ROLECODE_JLCOMPANY = ConfigurationManager.AppSettings["RoleCode_JLCompany"].Trim();

        /// <summary>
        ///签章单位角色类别
        /// </summary>
        public static readonly string _SIGNATURE_ROLETYPE = ConfigurationManager.AppSettings["SignatureRoleType"].Trim();

        /// <summary>
        ///外协单位角色类别
        /// </summary>
        public static readonly string _OUTHELP_ROLETYPE = ConfigurationManager.AppSettings["OutHelpRoleType"].Trim();

        /// <summary>
        ///业务指导人员默认受理的流程节点ID 多个,隔开
        /// </summary>
        public static readonly string _DEFAULT_RECV_WORKFLOWID = ConfigurationManager.AppSettings["DefaultRecvWorkFlowID"].Trim();

        /// <summary>
        ///业务指导人员角色编号
        /// </summary>
        public static readonly string _ROLECODE_CHARGEUSER = ConfigurationManager.AppSettings["RoleCode_ChargeUser"].Trim();

        /// <summary>
        /// 系统URL访问地址
        /// </summary>
        public static readonly string _APPURL = ConfigurationManager.AppSettings["AppUrl"].Trim();

        /// <summary>
        /// 系统名称
        /// </summary>
        public static readonly string _APPTITLE = ConfigurationManager.AppSettings["AppTitle"].Trim();

        /// <summary>
        /// 系统使用地址,比如马鞍山, 跟AppTitle配合使用
        /// </summary>
        public static readonly string _APPAREA = ConfigurationManager.AppSettings["AppArea"].Trim();

        /// <summary>
        /// PDF是否签章,签章则用金格插件,不签章则用adobe reader插件,比如一书两证 0:不签章 1:签章 ,如果签章,则默认文件都需要走签章流程,1书2证除外
        /// </summary>
        public static readonly string _ISIGNATUREPDF = ConfigurationManager.AppSettings["iSignaturePdf"].Trim();
 
        /// <summary>
        ///责任书对应的归档目录ID,责任书签章完成后,自动上传到该份文件下(要考虑不同类型的工程的责任书对应的模板ID不同)-
        /// </summary>
        public static readonly string _ZRS_TOFILELISTTMPRECIDS = ConfigurationManager.AppSettings["ZrsToFileListTmpRecIDS"];

        /// <summary>
        ///认可证对应的归档目录ID,责任书签章完成后,自动上传到该份文件下(要考虑不同类型的工程的认可证对应的模板ID不同)-
        /// </summary>
        public static readonly string _RKZ_TOFILELISTTMPRECIDS = ConfigurationManager.AppSettings["RkzToFileListTmpRecIDS"];

        /// <summary>
        ///证明书对应的归档目录ID,责任书签章完成后,自动上传到该份文件下(要考虑不同类型的工程的证明书对应的模板ID不同)-
        /// </summary>
        public static readonly string _ZMS_TOFILELISTTMPRECIDS = ConfigurationManager.AppSettings["ZmsToFileListTmpRecIDS"];


        /// <summary>
        /// 用户操作枚举
        /// </summary>
        public enum EumLogType {
            /// <summary>
            /// 系统bug
            /// </summary>
            ErrorBug,
            /// <summary>
            /// 用户登录
            /// </summary>
            LogIn,
            /// <summary>
            /// 用户登出
            /// </summary>
            LogOut,
            /// <summary>
            /// 新增数据
            /// </summary>
            AddData,
            /// <summary>
            /// 修改数据
            /// </summary>
            UpdData,
            /// <summary>
            /// 删除数据
            /// </summary>
            DelData
        }

        /// <summary>
        /// 证书类型枚举
        /// </summary>
        public enum EumReportType {
            /// <summary>
            /// 责任书
            /// </summary>
            ZRS,
            /// <summary>
            /// 认可证(预验收意见书)
            /// </summary>
            RKZ,
            /// <summary>
            /// 移交证明书
            /// </summary> 
            ZMS
        }

        /// <summary>
        /// 枚举工程流程编号
        /// </summary>
        public enum EumWorkFlowCode {
            /// <summary>
            /// 报建确认
            /// </summary>
            SINGLEPROJECTRED,
            /// <summary>
            /// 文件登记
            /// </summary>
            FILEREG,
            /// <summary>
            /// 在线预验收
            /// </summary>
            ONLINE_CHECK,
            /// <summary>
            /// 接收整理
            /// </summary>
            ARCHIVEPACK,
            /// <summary>
            /// 窗口接收
            /// </summary>
            WINRECV,
            /// <summary>
            /// 业务审核
            /// </summary>
            SIGNER,
            /// <summary>
            /// 领导签字
            /// </summary>
            FG_SIGNER,
            /// <summary>
            /// 移交入库
            /// </summary>
            IMPORT_TO
        }

        /// <summary>
        /// 用户类别枚举
        /// </summary>
        public enum EumUserType {
            /// <summary>
            /// 档案馆用户
            /// </summary>
            [System.ComponentModel.Description("档案馆用户")]
            ArchiveUser,
            /// <summary>
            /// 公司用户
            /// </summary>
            [System.ComponentModel.Description("公司用户")]
            CompanyUser,
            /// <summary>
            /// 签章用户
            /// </summary>
            [System.ComponentModel.Description("签章用户")]
            SignatureUser,
            /// <summary>
            /// 外协用户
            /// </summary>
            [System.ComponentModel.Description("外协用户")]
            OutHelpUser
        }

        /// <summary>
        /// 工程上传附件证书类别(规划许可证号,施工许可证号,其它证号等)
        /// </summary>
        public enum EumProject_Credentials {
            /// <summary>
            /// 规划许可证号
            /// </summary>
            [System.ComponentModel.Description("规划许可证号")]
            ghxkz,
            /// <summary>
            /// 施工许可证号
            /// </summary>
            [System.ComponentModel.Description("施工许可证号")]
            sgxkz,
            /// <summary>
            /// 其它证号等
            /// </summary>
            [System.ComponentModel.Description("其它证号等")]
            other
        }

        /// <summary>
        /// 签章动作枚举
        /// </summary>
        public enum EumSignatureOperationType {
            /// <summary>
            /// 签章保存
            /// </summary>
            [System.ComponentModel.Description("签章保存")]
            SignatureSave,
            /// <summary>
            /// 签章重置
            /// </summary>
            [System.ComponentModel.Description("签章重置")]
            SignatureReset,
            /// <summary>
            /// 签章完成
            /// </summary>
            [System.ComponentModel.Description("签章完成")]
            SignatureFinish,
            /// <summary>
            /// 责任书签章
            /// </summary>
            [System.ComponentModel.Description("责任书签章")]
            ZRS_Signature,
            /// <summary>
            /// 认可证签章
            /// </summary>
            [System.ComponentModel.Description("认可证签章")]
            RKZ_Signature,
            /// <summary>
            /// 证明书签章
            /// </summary>
            [System.ComponentModel.Description("证明书签章")]
            ZMS_Signature,
        }
    }
}