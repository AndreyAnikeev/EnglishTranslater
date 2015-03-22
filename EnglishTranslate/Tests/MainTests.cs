using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Xunit;

namespace Tests
{
    public class MainTests
    {
        [Fact]
        public void test()
        {
            DataProvider dataProvider = new DataProvider();
            var path = "MockData/DataFile.csv";
//            dataProvider.ReadData( path );
        }
    }
}
