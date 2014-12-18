using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class CommonData {


        public CommonData(decimal ID, decimal PARENT_ID, decimal LEVELS, string NAME, decimal ISLEAF,string NAME_ENG)
        {
            this.Id = Convert.ToInt32(ID);
            this.IsLeaf = Convert.ToBoolean(ISLEAF);
            this.Levels = Convert.ToInt32(LEVELS);
            this.Name = NAME;
            this.Parent_Id = Convert.ToInt32(PARENT_ID);
            this.Name_Eng = NAME_ENG;
        }

        public CommonData(){
        }


        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Name_Eng { get; set; }
        public virtual int Parent_Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Remark { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Create_By { get; set; }
        public virtual DateTime? Create_Date { get; set; }
        public virtual string Update_By { get; set; }
        public virtual DateTime? Update_Date { get; set; }
        public virtual bool IsLeaf { get; set; }
        public virtual int Levels {get;set;}

    }
}
