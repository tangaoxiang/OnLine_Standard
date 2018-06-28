using System;
namespace DigiPower.Onlinecol.Standard.Model
{
    /// <summary>
    /// 实体类T_Train_Rec_MDL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class T_Train_Rec_MDL
    {
        public T_Train_Rec_MDL()
        { }
        #region Model
        private int _trainrecid;
        private int? _userid;
        private int? _trainplanid;
        private string _traindesc;
        private string _trainresult;
        /// <summary>
        /// 
        /// </summary>
        public int TrainRecID
        {
            set { _trainrecid = value; }
            get { return _trainrecid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TrainPlanID
        {
            set { _trainplanid = value; }
            get { return _trainplanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainDesc
        {
            set { _traindesc = value; }
            get { return _traindesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainResult
        {
            set { _trainresult = value; }
            get { return _trainresult; }
        }
        #endregion Model

    }
}

