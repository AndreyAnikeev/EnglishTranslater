using System.Collections.Generic;
using ApprovalTests;
using BL;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class ShufflerTest
    {
        [Fact]
        public void should_shuffle_items()
        {
            var arrangeItems = new List<RecordEntity>
            {
                new RecordEntity
                {
                    EnglishWord = "first",
                    RussianWord = "first"
                },
                new RecordEntity
                {
                    EnglishWord = "second",
                    RussianWord = "second"
                },
                new RecordEntity
                {
                    EnglishWord = "third",
                    RussianWord = "third"
                },
                new RecordEntity
                {
                    EnglishWord = "fourth",
                    RussianWord = "fourth"
                },

            };
            Shuffler shuffler = new Shuffler();
            var result1 = shuffler.ShuffleItems(arrangeItems);
            var result2 = shuffler.ShuffleItems( arrangeItems);
            result1[0].Should().NotBeSameAs(result2[0]);
        } 
    }
}