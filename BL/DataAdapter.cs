using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;

namespace BL
{
    public interface IDataRecordAdapter
    {
        List<RecordEntity> GetRecords(string path);
    }

    public class DataRecordAdapter : IDataRecordAdapter
    {
        private readonly IDataConverter _dataConverter;
        private readonly IDataReader _dataReader;
        private readonly IRecordCache _cache;

        public DataRecordAdapter(IDataConverter dataConverter, IDataReader dataReader, IRecordCache cache)
        {
            _dataConverter = dataConverter;
            _dataReader = dataReader;
            _cache = cache;
        }

        public List<RecordEntity> GetRecords(string path)
        {
            var data = _dataReader.ReadDataFromFile(path);
            var records = _dataConverter.ConvertDataToRecords( data );
            _cache.RecordList = records;
            return records;
        } 
    }
}
