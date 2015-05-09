using System;
using System.Linq;
using BL;
using Common;

namespace EnglishTranslate
{
    public interface ITranslationChecker
    {
        CheckedResult CheckTranslation(string basicWord, string translation, string state);
    }

    public class TranslationChecker : ITranslationChecker
    {
        private readonly IRecordRepository _recordRepository;

        public TranslationChecker(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public CheckedResult CheckTranslation(string basicWord,string translation, string state)
        {
            if (_recordRepository == null || !_recordRepository.RecordList.Any())
                throw new Exception("Record repository is empry.");
            
            if (state == TranslationState.FromEnglishToRussian.ToString())
            {
                var checkWord = _recordRepository.RecordList.SingleOrDefault(word => word.EnglishWord == basicWord);
                return checkWord != null && checkWord.RussianWord == translation
                    ? new CheckedResult {IsRight = true}
                    : new CheckedResult{IsRight = false, RightTranslation = checkWord.RussianWord};
            }
            else if ( state == TranslationState.FromRussianToEnglish.ToString() )
            {
                var checkWord = _recordRepository.RecordList.SingleOrDefault( word => word.RussianWord == basicWord );
                return checkWord != null && checkWord.EnglishWord == translation
                    ? new CheckedResult { IsRight = true }
                    : new CheckedResult { IsRight = false, RightTranslation = checkWord.EnglishWord };
            }
            return null;
        }
    }
}