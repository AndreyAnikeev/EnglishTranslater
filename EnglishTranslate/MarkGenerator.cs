namespace EnglishTranslate
{
    public interface IMarkGenerator
    {
        int RecordCount { get; set; }

        string GetMark(bool isRighr);
    }

    public class MarkGenerator : IMarkGenerator
    {
        public int RecordCount { get; set; }

        public string GetMark(bool isRighr)
        {
            if (RecordCount == 0) return "";
            var translationMark = isRighr ? 1 : -1;
            var mark = (RecordCount + translationMark)*100/RecordCount;
            return string.Format("{0}%", mark);
        }     
    }
}