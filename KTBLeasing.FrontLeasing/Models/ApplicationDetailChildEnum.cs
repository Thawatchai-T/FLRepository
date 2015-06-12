using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public enum ApplicationDetailChildEnum
    {
        //Form
        ApplicationDetail,
        WaiveDocument,
        MethodPayment,
        Guarantor,
        OptionEndLeaseTerm,
        Maintenance,
        Insurance,
        Commission,
        StampDuty,
        StipulateLoss,
        Funding,
        TermCondition,

        //Store
        EquipmentList,
        Seller,
        AnnualTax,
        InsuranceEquipment,
        GuarantorList,
        CollectionSchedule,
        MaintenanceList,
        EquipmentDetail,
        PurchaseOrder,
        //Unknow
        Unknow
    }
}