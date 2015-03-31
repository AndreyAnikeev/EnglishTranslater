using ApprovalTests;
using DA;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class DataReaderTest
    {
        [Fact]
        public void should_read_file_and_map_items()
        {
            var path = "MockData/DataFile.csv";
            DataReader dataReader = new DataReader();
            var result = dataReader.ReadDataFromFile(path);
            Approvals.VerifyJson(JsonConvert.SerializeObject(result));
        } 
    }
}