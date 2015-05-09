using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    public enum TranslationState
    {
        FromEnglishToRussian,
        FromRussianToEnglish
    }

    public static class Constants
    {
        public const string EnglishIdentifier = "английский";
        public const string RussianIdentifier = "русский";
    }
}
