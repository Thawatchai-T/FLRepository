using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.Domain.ViewCommonData
{
    public class EQP
    {
        public virtual string Id { get; set; }

        private string _idSort;
        public virtual string IdSort
        {
            get
            {
                return this._idSort;
            }
            set
            {
                this._idSort = value.PadRight(6, '0');
            }
        }
        public virtual string Name { get; set; }
        public virtual int Parent_Id { get; set; }
    }
}
