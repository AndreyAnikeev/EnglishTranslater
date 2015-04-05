using System.Collections.Generic;

namespace BL
{
    public interface IRecordCache
    {
        List<RecordEntity> RecordList { get; set; }
    }

    public class RecordCache : IRecordCache
    {
        public List<RecordEntity> RecordList { get; set; }
    }
}