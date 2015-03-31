using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Common;
using DA;
using DA.Entities;

namespace BL
{
    public interface IDataConverter
    {
        List<RecordEntity> ConvertDataToRecords( List<RecordData> data );
    }

    public class DataConverter : IDataConverter
    {

        public DataConverter()
        {
        }

        public List<RecordEntity> ConvertDataToRecords(List<RecordData> data )
        {
            var result = new List<RecordEntity>();    
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