using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public interface IShuffler
    {
    }

    public class Shuffler : IShuffler
    {
        public static Random random = new Random();
        public List<RecordEntity> ShuffleItems(List<RecordEntity> records)
        {
            return records.OrderBy( x => ( random.Next() ) ).ToList();
        } 
    }
}