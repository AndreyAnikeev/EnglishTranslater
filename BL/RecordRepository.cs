using System.Collections.Generic;

namespace BL
{
    public interface IRecordRepository
    {
        List<RecordEntity> RecordList { get; set; }
    }

    public class RecordRepository : IRecordRepository
    {
        public List<RecordEntity> RecordList { get; set; }
    }
}