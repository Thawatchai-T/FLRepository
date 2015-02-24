using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.Domain
{
    public class BaseDomain
    {

        public BaseDomain()
        {
            //this._createDate = DateTime.Now;
            this._udpateDate = DateTime.Now;
        }

        private DateTime _createDate;
        private DateTime _udpateDate;
        private string _createBy;
        private string _updateBy;

        public virtual DateTime CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                this._createDate = value;
            }
        }
        public virtual string CreateBy
        {
            get
            {
                return this._createBy;
            }
            set
            {
                this._createBy = value;
            }
        }
        public virtual DateTime UpdateDate
        {
            get
            {
                return this._udpateDate;
            }
            set
            {
                this._udpateDate = DateTime.Now;
            }
        }
        public virtual string UpdateBy
        {
            get
            {
                return this._updateBy;
            }
            set
            {
                this._updateBy = value;
            }
        }
    }
}
