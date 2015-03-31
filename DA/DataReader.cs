using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using DA.Entities;

namespace DA
{
    public interface IDataReader
    {
        List<RecordData> ReadDataFromFile(string path);
    }

    public class DataReader : IDataReader
    {
        public List<RecordData> ReadDataFromFile( string path )
        {
            var textReader = File.OpenText(path);
            var csv = new CsvReader(textReader);
            csv.Configuration.RegisterClassMap<RecordMap>();
            return csv.GetRecords<RecordData>().ToList();
        }
    }
}
