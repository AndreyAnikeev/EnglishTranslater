using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Common;
using DA;

namespace BL
{
    public interface IDataConverter
    {
        List<RecordEntity> ConvertDataToRecords( string path );
    }

    public class DataConverter : IDataConverter
    {
        private readonly IDataReader _dataReader;

        public DataConverter(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public List<RecordEntity> ConvertDataToRecords(string path)
        {
            var result = new List<RecordEntity>();    
            var data = _dataReader.ReadDataFromFile(path);
            if (data != null)
            {
                result = data
                    .Select(item =>
                    {
                        if (item.FormatFrom == Constants.EnglishIdentifier && item.FormatTo == Constants.RussianIdentifier)
                        {
                            return new RecordEntity {EnglishWord = item.MainWord, RussianWord = item.Translation};
                        }
                        else if ( item.FormatFrom == Constants.RussianIdentifier && item.FormatTo == Constants.EnglishIdentifier )
                        {
                            return new RecordEntity { EnglishWord = item.Translation, RussianWord = item.MainWord };
                        }
                        return null;
                    })
                    .ToList();
            }
            return result;
        }
    }
}