namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_when_given_stream_of_lines_returns_stream_of_words()
    {
        //arrange
        var lines = new List<String>{"Hej med dig", "Vi er gruppe 1", "@ os"};
        var expected = new List<String>{"Hej","med","dig","Vi","er","gruppe","1","os"};
        
        //act
        var actual = RegExpr.SplitLine(lines);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Resolution_when_given_1920x1080_returns_tuple_1920_1080()
    {
        //arrange
        var resolution = new List<String> {"1920x1080"};
        var expected = new List<(int, int)> {(1920, 1080)};

        //act
        var actual = RegExpr.Resolution(resolution);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Resolution_when_given_1024x768_800x600__returns_tuple_1024_768_and_800_600()
    {
        //arrange
        var resolution = new List<String> {"1024x768, 800x600"};
        var expected = new List<(int, int)> {(1024, 768), (800, 600)};

        //act
        var actual = RegExpr.Resolution(resolution);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InnerText_given_assignment_html_and_tag_a_return_assignment_output()
    {
        //arrange
        string html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=/wiki/Theoretical_computer_science title=Theoretical computer science>theoretical computer science</a> and <a href=/wiki/Formal_language title=Formal language>formal language</a> theory, a sequence of <a href=/wiki/Character_(computing) title=Character (computing)>characters</a> that define a <i>search <a href=/wiki/Pattern_matching title=Pattern matching>pattern</a></i>. Usually this pattern is then used by <a href=/wiki/String_searching_algorithm title=String searching algorithm>string searching algorithms</a> for find or find and replace operations on <a href=/wiki/String_(computer_science) title=String (computer science)>strings</a>.</p></div>";
        string tag = "a";
        var expected = new List<String>(){"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"};

        //act
        var actual = RegExpr.InnerText(html, tag);

        //assert
        Assert.Equal(expected,actual);
    }

    
    [Fact]
    public void InnerText_given_assignment_html_and_tag_p_return_assignment_output()
    {
        //arrange
        string html = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
        string tag = "p";
        var expected = new List<String>(){"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};

        //act
        var actual = RegExpr.InnerText(html, tag);

        //assert
        Assert.Equal(expected,actual);
    }

    [Fact]
    public void Urls_given_assignment_html_return_href_titles()
    {
        //arrange
        string html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>0.</p></div>";
        var expected = new List<(Uri, String)>(){
                (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
                (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
                (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
                (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching")
            };
        
        //act
        var actual = RegExpr.Urls(html);

        //assert
        Assert.Equal(expected,actual);
    }

    [Fact]
    public void Urls_when_html_has_missing_title_tags_uses_inner_text()
    {
        string html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\">pattern</a></i>0.</p></div>";
        var expected = new List<(Uri, String)>(){
                (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "theoretical computer science"),
                (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "formal language"),
                (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "characters"),
                (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "pattern")
            };
        
        //act
        var actual = RegExpr.Urls(html);

        //assert
        Assert.Equal(expected,actual);
    }

}