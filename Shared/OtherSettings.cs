using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class OtherSettings
    {
        public int NumDaysNotifyUserForInventoryExpDate { get; set; }

        public int MinAgeForEmployee { get; set; }

        public string EmployeeImgsFileDirName { get; set; }

        public string ProductImgsFileDirName { get; set; }

        public string ComboMealImgsFileDirName { get; set; }

        public string InventoryPDFReportLoc { get; set; }

        public string POSReceiptFileLoc { get; set; }

        public bool IsPOSReceiptAutoSave { get; set; }
    }
}
