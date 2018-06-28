using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using DigiPower.Onlinecol.Standard.Web.CommonCtrl;

namespace DigiPower.Onlinecol.Standard.Web
{
    public class Comm
    {
        #region 赋值取值

        /// <summary>
        /// 禁用或启用某控件下所有控件
        /// </summary>
        /// <param name="c"></param>
        /// <param name="bEnabled"></param>
        public static void EnableControls(Control c, bool bEnabled)
        {
            if (c is WebControl)
                ((WebControl)c).Enabled = bEnabled;

            if (c is HtmlControl)
                ((HtmlControl)c).Disabled = !bEnabled;

            foreach (Control cc in c.Controls)
                EnableControls(cc, bEnabled);
        }

        /// <summary>
        /// 将控件的值赋给model
        /// </summary>
        /// <param name="obj">model</param>
        /// <param name="container">control</param>
        /// <returns></returns>
        public static object GetValueToObject(object obj, Control container)
        {
            if (obj == null) return null;

            Type objType = obj.GetType();

            PropertyInfo[] objPropertiesArray = objType.GetProperties();

            //遍历属性集合
            foreach (PropertyInfo objProperty in objPropertiesArray)
            {
                Control control = container.FindControl(objProperty.Name);

                if (control != null)
                {
                    //取当前属性项的字段类型
                    Type ModelType = objProperty.PropertyType;

                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;

                        object objvalue = txt.Text == "" ? null : SetObjValueByType(ModelType, txt.Text);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is HiddenField)
                    {
                        HiddenField txt = (HiddenField)control;
                        object objvalue = txt.Value == "" ? null : SetObjValueByType(ModelType, txt.Value);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DropDownList)
                    {
                        DropDownList drp = (DropDownList)control;

                        object objvalue = SetObjValueByType(ModelType, drp.Text);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is CheckBox)
                    {
                        CheckBox chk = (CheckBox)control;

                        object objvalue = SetObjValueByType(ModelType, chk.Checked);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx txt = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx)control;

                        //object objvalue = txt.Text == "" ? null : SetObjValueByType(ModelType, txt.Text);
                        object objvalue = SetObjValueByType(ModelType, txt.Text);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea)control;

                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType)control;

                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is ctrlDropDownTrainPlan)
                    {
                        ctrlDropDownTrainPlan plan = control as ctrlDropDownTrainPlan;
                        object objvalue = SetObjValueByType(ModelType, plan.SelectedValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is ctrDropDownCellTmp)
                    {
                        ctrDropDownCellTmp drp = control as ctrDropDownCellTmp;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule)control;

                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp)control;

                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo)control;

                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo)control;

                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is CommonCtrl.ctrlOptStatus)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlOptStatus drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlOptStatus)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownRole)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownRole drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownRole)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCanDefineType)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCanDefineType drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCanDefineType)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCutLeng)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCutLeng drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCutLeng)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSplit)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSplit drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSplit)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is RadioButtonList)
                    {
                        ListControl rl = (ListControl)control;

                        object objvalue = SetObjValueByType(ModelType, rl.SelectedValue);

                        if (objvalue != null)
                        {
                            objProperty.SetValue(obj, objvalue, null);
                        }
                    }
                    else if (control is CommonCtrl.ctrlDropDownConstructionProject)
                    {
                        CommonCtrl.ctrlDropDownConstructionProject drp = (CommonCtrl.ctrlDropDownConstructionProject)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                            objProperty.SetValue(obj, objvalue, null);
                    }
                    else if (control is CommonCtrl.ctrlDropDownUser)
                    {
                        CommonCtrl.ctrlDropDownUser drp = (CommonCtrl.ctrlDropDownUser)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                            objProperty.SetValue(obj, objvalue, null);
                    }
                    else if (control is CommonCtrl.ctrlDropDownWorkFlow)
                    {
                        CommonCtrl.ctrlDropDownWorkFlow drp = (CommonCtrl.ctrlDropDownWorkFlow)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                            objProperty.SetValue(obj, objvalue, null);
                    }
                    else if (control is CommonCtrl.ctrlDropDownSingleProject)
                    {
                        CommonCtrl.ctrlDropDownSingleProject drp = (CommonCtrl.ctrlDropDownSingleProject)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                            objProperty.SetValue(obj, objvalue, null);
                    }
                    else if (control is CommonCtrl.ctrlDropDownSingleProjectUsers)
                    {
                        CommonCtrl.ctrlDropDownSingleProjectUsers drp = (CommonCtrl.ctrlDropDownSingleProjectUsers)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                            objProperty.SetValue(obj, objvalue, null);
                    }
                    else if (control is CommonCtrl.ctrlDropDownFileList)
                    {
                        CommonCtrl.ctrlDropDownFileList drp = (CommonCtrl.ctrlDropDownFileList)control;
                        object objvalue = SetObjValueByType(ModelType, drp.SelectValue);
                        if (objvalue != null)
                            objProperty.SetValue(obj, objvalue, null);
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// 将model的值赋给控件
        /// </summary>
        /// <param name="obj">model</param>
        /// <param name="container">control</param>
        /// <returns></returns>
        public static object SetValueToPage(object obj, Control container)
        {
            if (obj == null) return null;

            Type objType = obj.GetType();

            PropertyInfo[] objPropertiesArray = objType.GetProperties();

            foreach (PropertyInfo objProperty in objPropertiesArray)
            {
                Control control = container.FindControl(objProperty.Name);

                if (control != null)
                {
                    if (objProperty.GetValue(obj, null) == null)
                        continue;
                    object ctlValue = objProperty.GetValue(obj, null).ToString();

                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;

                        txt.Text = ctlValue.ToString();
                    }
                    else if (control is Label)
                    {
                        Label txt = (Label)control;

                        txt.Text = ctlValue.ToString();
                    }
                    else if (control is Literal)
                    {
                        Literal txt = (Literal)control;

                        txt.Text = ctlValue.ToString();
                    }
                    else if (control is HiddenField)
                    {
                        HiddenField txt = (HiddenField)control;
                        txt.Value = ctlValue.ToString();
                    }
                    else if (control is DropDownList)
                    {
                        DropDownList drp = (DropDownList)control;

                        drp.Text = ctlValue.ToString();
                    }
                    else if (control is CheckBox)
                    {
                        CheckBox chk = (CheckBox)control;

                        if (ctlValue != null && ctlValue.ToString().Trim() == "1") chk.Checked = true;
                        else if (ctlValue != null && ctlValue.ToString().Trim() == "0") chk.Checked = false;
                        else chk.Checked = Convert.ToBoolean(ctlValue);
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx txt = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx)control;

                        txt.Text = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea)control;

                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType)control;

                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule)control;

                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp)control;

                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlOptStatus)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlOptStatus drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlOptStatus)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCanDefineType)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCanDefineType drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCanDefineType)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCutLeng)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCutLeng drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCutLeng)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSplit)
                    {
                        DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSplit drp = (DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSplit)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is RadioButtonList)
                    {
                        ListControl rl = (ListControl)control;

                        rl.SelectedValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlDropDownConstructionProject)
                    {
                        CommonCtrl.ctrlDropDownConstructionProject drp = (CommonCtrl.ctrlDropDownConstructionProject)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlDropDownUser)
                    {
                        CommonCtrl.ctrlDropDownUser drp = (CommonCtrl.ctrlDropDownUser)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlDropDownWorkFlow)
                    {
                        CommonCtrl.ctrlDropDownWorkFlow drp = (CommonCtrl.ctrlDropDownWorkFlow)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlDropDownFileList)
                    {
                        CommonCtrl.ctrlDropDownFileList drp = (CommonCtrl.ctrlDropDownFileList)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlDropDownSingleProject)
                    {
                        CommonCtrl.ctrlDropDownSingleProject drp = (CommonCtrl.ctrlDropDownSingleProject)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlDropDownSingleProjectUsers)
                    {
                        CommonCtrl.ctrlDropDownSingleProjectUsers drp = (CommonCtrl.ctrlDropDownSingleProjectUsers)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                    else if (control is CommonCtrl.ctrlDropDownRole)
                    {
                        CommonCtrl.ctrlDropDownRole drp = (CommonCtrl.ctrlDropDownRole)control;
                        drp.SelectValue = ctlValue.ToString();
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// 根据属性类型设置属性值
        /// </summary>
        /// <param name="ModelType">属性类型</param>
        ///<param name="obj"></param>
        /// <returns></returns>
        private static object SetObjValueByType(Type ModelType, object obj)
        {
            if (obj != null)
            {
                if (ModelType.FullName.Contains("System.String"))
                {
                    return obj.ToString();
                }
                else if (ModelType.FullName.Contains("System.Int32"))
                {
                    return Common.ConvertEx.ToInt(obj);
                }
                else if (ModelType.FullName.Contains("System.DateTime"))
                {
                    return Common.ConvertEx.ToDate(obj.ToString());
                }
                else if (ModelType.FullName.Contains("System.Boolean"))
                {
                    return Convert.ToBoolean(obj);
                }
                else if (ModelType.FullName.Contains("System.Decimal"))
                {
                    return Common.ConvertEx.ToDecimal(obj);
                }
            }
            return null;
        }

        #endregion

        #region 组建页面查询条件
        /// <summary>
        /// 根据用户组建一个查询页面中的条件sql
        /// </summary>
        /// <param name="pControl">控件集合 一般用Panel</param>
        public static string BuildSqlWhereByUser(ControlCollection pControl)
        {
            StringBuilder sbSql = new StringBuilder();
            if (pControl != null)
            {
                GetSearchCtl(sbSql, pControl);
            }
            return sbSql.ToString();
        }
        /// <summary>
        /// 组建一个查询页面中的条件sql
        /// </summary>
        /// <param name="pControl">控件集合 一般用Panel</param>
        /// <returns></returns>
        public static string BuildSqlWhere(ControlCollection pControl)
        {
            StringBuilder sbSql = new StringBuilder();

            if (pControl != null)
            {
                sbSql.Append(" 1=1");

                GetSearchCtl(sbSql, pControl);
            }
            return sbSql.ToString();
        }

        /// <summary>
        /// 获取查询页面中的TextBox,DropDownList值，组合sql
        /// </summary>
        /// <param name="pControl"></param>
        private static string GetSearchCtl(StringBuilder sbSql, ControlCollection pControl)
        {
            if (pControl != null)
            {
                string pstrID = string.Empty;

                object pobject = new object();

                string ctrVal = string.Empty;

                foreach (Control pSubControl in pControl)
                {
                    string typename = pSubControl.GetType().FullName;

                    if (pSubControl is TextBox)
                    {
                        pstrID = ((TextBox)pSubControl).ID.ToString();

                        ctrVal = ((TextBox)pSubControl).Text.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (pstrID == "txtBeginTime" || pstrID == "txtEndTime")
                        {

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ctrVal))
                            {
                                sbSql.Append(" and ");

                                sbSql.Append(pstrID);

                                sbSql.Append(" like '%");

                                sbSql.Append(ctrVal);

                                sbSql.Append("%'");
                            }
                        }
                    }
                    else if (pSubControl is HtmlInputText)
                    {
                        pstrID = ((HtmlInputText)pSubControl).ID.ToString();

                        ctrVal = ((HtmlInputText)pSubControl).Value.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }

                    }
                    else if (pSubControl is DropDownList)
                    {
                        pstrID = ((DropDownList)pSubControl).ID.ToString();

                        ctrVal = ((DropDownList)pSubControl).SelectedValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }
                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlTextBoxEx)pSubControl).Text.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (pstrID == "txtBeginTime" || pstrID == "txtEndTime")
                        {

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ctrVal))
                            {
                                sbSql.Append(" and ");

                                sbSql.Append(pstrID);

                                sbSql.Append(" like '%");

                                sbSql.Append(ctrVal);

                                sbSql.Append("%'");
                            }
                        }
                    }

                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownUserType)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownUserType)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownUserType)pSubControl).SelectedValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }

                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownArea)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }

                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrDropDownCellTmp)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrDropDownCellTmp)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrDropDownCellTmp)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }


                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownModule)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }
                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownFileListTmp)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }
                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownCompanyInfo)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }

                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystemInfo)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }

                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlArchiveFormType)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }
                    else if (pSubControl is CommonCtrl.ctrlOptStatus)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlOptStatus)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlOptStatus)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }
                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownSystem)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }
                    else if (pSubControl is DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType)
                    {
                        pstrID = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType)pSubControl).ID.ToString();

                        ctrVal = ((DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlDropDownReportType)pSubControl).SelectValue.Trim();

                        ctrVal = ctrVal.Replace("'", "''");

                        if (!string.IsNullOrEmpty(ctrVal))
                        {
                            sbSql.Append(" and ");

                            sbSql.Append(pstrID);

                            sbSql.Append(" = '");

                            sbSql.Append(ctrVal);

                            sbSql.Append("'");
                        }
                    }
                }

                return sbSql.ToString();
            }
            else { return string.Empty; }
        }

        private static void BuildSqlString(StringBuilder sbSql, string pstrID, string ctrVal)
        {
            sbSql.Append(" and ");

            sbSql.Append(pstrID);

            sbSql.Append(" = '");

            sbSql.Append(ctrVal);

            sbSql.Append("'");
        }

        public static string AddEmpty(string Name, int ll_i)//填补空格
        {
            for (int i = 0; i < ll_i; i++)
            {
                Name = "　" + Name;//此处使用是全角输入下空格，半角会HTML会过滤
            }
            return Name;
        }

        #endregion
    }
}