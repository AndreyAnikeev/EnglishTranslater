using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public interface IShuffler
    {
        List<RecordEntity> ShuffleItems(List<RecordEntity> records);
    }

    public class Shuffler : IShuffler
    {
        /// <summary>
        /// This parameter is static for getting unrepeatable result.
        /// </summary>
        public static Random random = new Random();

        public List<RecordEntity> ShuffleItems(List<RecordEntity> records)
        {
            return records.OrderBy( x => ( random.Next() ) ).ToList();
        } 
    }
}