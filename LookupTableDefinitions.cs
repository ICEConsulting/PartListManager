using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TecanPartListManager
{
    public class LookupTableDefinitions
    {

        public class AvailableInstruments
        {
            private string InstrumentID;
            private string InstrumentName;

            public AvailableInstruments(string strName, string strID)
            {
                this.InstrumentID = strID;
                this.InstrumentName = strName;
            }

            public string ID
            {
                get
                {
                    return InstrumentID;
                }
            }

            public string Name
            {

                get
                {
                    return InstrumentName;
                }
            }

        }

        public class AvailableCategories
        {
            private string CategoryID;
            private string CategoryName;

            public AvailableCategories(string strName, string strID)
            {
                this.CategoryID = strID;
                this.CategoryName = strName;
            }

            public string ID
            {
                get
                {
                    return CategoryID;
                }
            }

            public string Name
            {

                get
                {
                    return CategoryName;
                }
            }

        }


        public class AvailableSubCategories
        {
            private String SubCategoryID;
            private String SubCategoryName;

            public AvailableSubCategories(string strName, string strID)
            {
                this.SubCategoryID = strID;
                this.SubCategoryName = strName;
            }

            public string ID
            {
                get
                {
                    return SubCategoryID;
                }
            }

            public string Name
            {
                get
                {
                    return SubCategoryName;
                }
            }
        }


    }
}
