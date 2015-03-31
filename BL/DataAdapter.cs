using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IDataRecordAdapter
    {
        List<RecordEntity> GetRecords(string path);
    }

    public class DataRecordAdapter : IDataRecordAdapter
    {
        private readonly IDataConverter _dataConverter;

        public DataRecordAdapter(IDataConverter dataConverter)
        {
            _dataConverter = dataConverter;
        }

        public List<RecordEntity> GetRecords(string path)
        {
            return _dataConverter.ConvertDataToRecords(path);
        } 
    }
}
