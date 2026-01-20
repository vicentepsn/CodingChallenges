using System.Text;

namespace CodingChallenges.Strings.Test;

public class TextJustificationTest
{
    [Fact]
    public void Test01()
    {
        string[] words = ["This", "is", "an", "example", "of", "text", "justification."];
        int maxWidth = 16;
        List<string> expected =
        [
            "This    is    an",
            "example  of text",
            "justification.  "
        ];

        List<string> output = TextJustification.FullJustify(words, maxWidth);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        string[] words = ["What", "must", "be", "acknowledgment", "shall", "be"];
        int maxWidth = 16;
        List<string> expected =
        [
            "What   must   be",
            "acknowledgment  ",
            "shall be        "
        ];

        List<string> output = TextJustification.FullJustify(words, maxWidth);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        string[] words = ["Science", "is", "what", "we", "understand", "well", "enough", 
            "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"];
        int maxWidth = 20;
        List<string> expected =
        [
            "Science  is  what we",
            "understand      well",
            "enough to explain to",
            "a  computer.  Art is",
            "everything  else  we",
            "do                  "
        ];

        List<string> output = TextJustification.FullJustify(words, maxWidth);

        Assert.Equal(expected, output);
    }
}
