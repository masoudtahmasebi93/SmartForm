using System;
using System.Collections.Generic;
using System.Text;

namespace SmartForm.Common.Domain.Query
{
    public class QueryInputParamater
    {
        public string Code { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public List<QuerySortItems> Sort { get; set; } = new List<QuerySortItems>();
        public string SearchExp { get; set; }
        public List<QueryFilterItems> Filters { get; set; } = new List<QueryFilterItems>();
        public List<string> Columns { get; set; } = new List<string>();

        public List<string> Groups { get; set; } = new List<string>();

        public List<string> GroupsKeys { get; set; } = new List<string>();
    }

    public class QuerySortItems
    {
        public string Field { get; set; }

        public string Sort { get; set; }



    }
    public class QueryFilterItems
    {
        public string FieldName { get; set; }
        public string Operator { get; set; } = "Equal";
        public dynamic Value { get; set; }


    }
    public class DataSourceInput
    {
        public string DSRC_COD { get; set; }
        public Guid DSRC_ID { get; set; }
        public DataSourceType DSRC_TYP_SRC { get; set; }
        public string DSRC_SRC { get; set; }
        public string DSRC_TIT { get; set; }
        public string DSRC_QRY_PARAMS { get; set; }
        public string DSRC_JSO_FIELDS { get; set; }
        public string DSRC_COD_RLS { get; set; }
        public string DSRC_ORDER { get; set; }

    }

    public enum DataSourceType
    {
        Table = 1,
        View = 2,
        Function = 3
    }
}
