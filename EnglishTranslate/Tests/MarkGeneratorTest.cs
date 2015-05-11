using EnglishTranslate;
using Xunit;

namespace Tests
{
    public class MarkGeneratorTest
    {
        [Fact]
        public void should_generate_mark_if_choose_right_translation()
        {
            //Arrange
            var markGenerator = new MarkGenerator();
            markGenerator.RecordCount = 10;
            //Act
            var result = markGenerator.GetMark(true);
            //Assert

        } 
    }
}