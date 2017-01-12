using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TecanPartListManager
{
    public class Compatibilities
    {
        private string CompatibilityID;
        private string CompatibilityAbbv;
        private string CompatibilityName;

        public Compatibilities(string strName, string strID, string strAbbv = "")
        {
            this.CompatibilityID = strID;
            this.CompatibilityAbbv = strAbbv;
            this.CompatibilityName = strName;
        }

        public string ID
        {
            get
            {
                return CompatibilityID;
            }
        }

        public string Abbv
        {

            get
            {
                return CompatibilityAbbv;
            }
        }

        public string Name
        {

            get
            {
                return CompatibilityName;
            }
        }

    }
}
