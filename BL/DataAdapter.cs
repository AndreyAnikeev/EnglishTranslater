using System.Collections.Generic;
using DA;

namespace BL
{
    public interface IDataRecordAdapter
    {
        List<RecordEntity> GetShuffleRecordList(string path);
    }

    public class DataRecordAdapter : IDataRecordAdapter
    {
        private readonly IDataConverter _dataConverter;
        private readonly IDataReader _dataReader;
        private readonly IRecordCache _cache;
        private readonly IShuffler _shuffler;

        public DataRecordAdapter(IDataConverter dataConverter, IDataReader dataReader, IRecordCache cache, IShuffler shuffler)
        {
            _dataConverter = dataConverter;
            _dataReader = dataReader;
            _cache = cache;
            _shuffler = shuffler;
        }

        public List<RecordEntity> GetShuffleRecordList(string path)
        {
            var data = _dataReader.ReadDataFromFile(path);
            var records = _dataConverter.ConvertDataToRecords( data );
            _cache.RecordList = records;
            var result = _shuffler.ShuffleItems(records);
            return result;
        } 
    }
}
