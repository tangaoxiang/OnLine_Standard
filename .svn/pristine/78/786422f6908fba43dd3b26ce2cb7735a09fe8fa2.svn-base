using System;
using System.Collections.Generic;
using System.Web;

namespace DigiPower.Onlinecol.Standard.Web
{
    public class GridExPara
    {
        private bool _bShow = true;
        private string _fieldName = "";
        private string _showName = "";
        private CtrlType _iType = 0;
        private int _iLength = 0;
        private string _subType = "";
        private string _js = "";
        private bool _enabled = false;
        public GridExPara()
        {
        }

        public bool bShow
        {
            set { _bShow = value; }
            get { return _bShow; }
        }
        public string FieldName
        {
            set { _fieldName = value; }
            get { return _fieldName; }
        }
        public string ShowName
        {
            set { _showName = value; }
            get { return _showName; }
        }

        public enum CtrlType
        {
            Label,
            TextBox,
            DropDownList,
            Image,
            CheckBox,
            FileUpload,
            SystemInfo
        }

        public CtrlType iType
        {
            set { _iType = value; }
            get { return _iType; }
        }
        public int iLength
        {
            set { _iLength = value; }
            get { return _iLength; }
        }
        public string subType
        {
            set { _subType = value; }
            get { return _subType; }
        }
        public string AddJS
        {
            set { _js = value; }
            get { return _js; }
        }
        public bool Enabled
        {
            set { _enabled = value; }
            get { return _enabled; }
        }
    }
}