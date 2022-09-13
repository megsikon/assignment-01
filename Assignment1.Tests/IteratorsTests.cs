namespace Assignment1.Tests;

public class IteratorsTests
{
 
    [Fact]
    public void Flatten_when_given_stream_of_stream_of_T_should_return_stream_of_T() {
        //arrange
        var stream_of_streams = new List<List<int>>();
        stream_of_streams.Add(new List<int>() {1,2,3});
        stream_of_streams.Add(new List<int>() {4,5,6});

        var expected = new List<int>(){1,2,3,4,5,6};
        //act
        var actual = Iterators.Flatten(stream_of_streams);

        //assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Filter_when_given_stream_of_numbers_should_return_evens() {
        //arrange
        var stream_of_numbers = new List<int>(){1,2,3,4,5};
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;
        
        var expected = new List<int>(){2,4};
        
        //act
        var actual = Iterators.Filter(stream_of_numbers, even);
        
        //assert
        Assert.Equal(expected, actual);
    }
}