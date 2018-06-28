using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_Module_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_Module_MDL
    {
        public T_Module_MDL()
        { }
        #region Model
        private int _moduleid;
        private int? _parentid;
        private string _bh;
        private string _modulename;
        private int? _pictureindex;
        private int? _selectedindex;
        private string _filename;
        private bool _ifvisible;
        private int? _orderindex;
        private string _description;
        private bool _del;
        private string _rightlistid;
        private bool _ifinsidepage;


        /// <summary>
        /// 
        /// </summary>
        public int ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BH
        {
            set { _bh = value; }
            get { return _bh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleName
        {
            set { _modulename = value; }
            get { return _modulename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PictureIndex
        {
            set { _pictureindex = value; }
            get { return _pictureindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SelectedIndex
        {
            set { _selectedindex = value; }
            get { return _selectedindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IfVisible
        {
            set { _ifvisible = value; }
            get { return _ifvisible; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderIndex
        {
            set { _orderindex = value; }
            get { return _orderindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Del
        {
            set { _del = value; }
            get { return _del; }
        }
        /// <summary>
        /// 权限按钮集合
        /// </summary>
        public string RightListID
        {
            set { _rightlistid = value; }
            get { return _rightlistid; }
        }
        /// <summary>
        ///    是否内页(也就是二级页面,跟BH一起配合使用)
        /// </summary>
        public bool IfInsidePage
        {
            set { _ifinsidepage = value; }
            get { return _ifinsidepage; }
        }
        #endregion Model


    }
}

