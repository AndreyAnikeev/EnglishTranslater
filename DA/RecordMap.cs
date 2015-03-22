using CsvHelper.Configuration;
using DA.Entities;

namespace DA
{
    class RecordMap: CsvClassMap<RecordData>
    {
        public RecordMap()
        {
            Map(m => m.FormatFrom).Index(0);
            Map(m => m.FormatTo).Index(1);
            Map(m => m.MainWord).Index(2);
            Map(m => m.Translation).Index(3);
        }
    }
}
