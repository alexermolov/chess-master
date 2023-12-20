using System.Collections.Generic;

namespace ChessMaster
{
    public class ColumnConfig
    {
        public IEnumerable<Column> Columns { get; set; }
    }

    public class Column
    {
        public string Header { get; set; }

        public string DataField { get; set; }
    }
}
