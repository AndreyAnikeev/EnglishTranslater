using BL;

namespace EnglishTranslate
{
    public interface ITranslationChecker
    {

    }

    public class TranslationChecker : ITranslationChecker
    {
        private readonly IRecordRepository _recordRepository;

        public TranslationChecker(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public CheckedResult CheckTranslation(string translation, string state)
        {
            if (state == Constants.EnglishState)
            {
//                translation
            }
            return null;
        }
    }
}