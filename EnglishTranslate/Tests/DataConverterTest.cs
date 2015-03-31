using System.Collections.Generic;
using BL;
using DA.Entities;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class DataConverterTest
    {
        [Fact]
        public void should_convert_data()
        {
            var arrangeRecords = new List<RecordData>
            {
                new RecordData
                {
                    FormatFrom = "английский",
                    FormatTo = "русский",
                    MainWord = "hello",
                    Translation = "привет"
                }
            };
            var expected = new List<RecordEntity>
            {
                new RecordEntity
                {
                    EnglishWord = "hello",
                    RussianWord = "привет"
                }
            };
            DataConverter dataConverter = new DataConverter();
            var result = dataConverter.ConvertDataToRecords(arrangeRecords);
            result.ShouldBeEquivalentTo(expected);
        } 
    }
}