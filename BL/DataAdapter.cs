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

        public DataRecordAdapter(IDataConverter dataConverter, IDataReader dataReader)
        {
            _dataConverter = dataConverter;
            _dataReader = dataReader;
        }

        public List<RecordEntity> GetRecords(string path)
        {
            var data = _dataReader.ReadDataFromFile(path);
            return _dataConverter.ConvertDataToRecords( data );
        } 
    }
}
