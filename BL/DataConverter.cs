using DA;

namespace BL
{
    public interface IDataConverter
    {
    }

    public class DataConverter : IDataConverter
    {
        private readonly IDataReader _dataReader;

        public DataConverter(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public void ConvertDataToRecords()
        {
            
        }
    }
}