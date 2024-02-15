using System;

public class VectorShortTests
{

    private readonly VectorShort vector;

    public VectorShortTests()
    {
        // This constructor runs before each test
        vector = new VectorShort(5);
    }

    [Fact]
    public void Constructor_WithSize_SetsSizeCorrectly()
    {
        Assert.Equal(5u, vector.Size);
    }

    [Fact]
    public void Constructor_WithInitValue_SetsAllElementsToInitValue()
    {
        short initValue = 10;
        VectorShort vectorWithInitValue = new VectorShort(5, initValue);

        Assert.All(vectorWithInitValue.ShortArray, element => Assert.Equal(initValue, element));
    }


    [Fact]
    public void DisplayElements_Method_WritesElementsToConsole()
    {
    
        VectorShort vector1 = new VectorShort(4,5);
        string expectedOutput = "Vector elements: 5 5 5 5";
        string actualOutput = vector1.DisplayElements();
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void AssignValue_Method_SetsAllElementsToGivenValue()
    {
        short value = 7;
        vector.AssignValue(value);

        Assert.All(vector.ShortArray, element => Assert.Equal(value, element));
    }

    [Fact]
    public void NumVectors_Method_ReturnsCorrectNumberOfVectors()
    {
        uint initialNumVectors = VectorShort.NumVectors();

        var vector1 = new VectorShort(3);
        var vector2 = new VectorShort(2);

        Assert.Equal(initialNumVectors + 2, VectorShort.NumVectors());
    }
}
