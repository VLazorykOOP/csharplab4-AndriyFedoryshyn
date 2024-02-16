using System;
using Xunit;

public class MatrixShortTests
{
    [Fact]
    public void DefaultConstructor_CreatesMatrixWithSizeOneOne()
    {
        // Arrange & Act
        var matrix = new MatrixShort();

        // Assert
        Assert.Equal(1, matrix.GetLength(0));
        Assert.Equal(1, matrix.GetLength(1));
    }


    [Theory]
    [InlineData(2, 3)]
    [InlineData(3, 2)]
    [InlineData(4, 4)]
    public void ParameterizedConstructor_CreatesMatrixWithSpecifiedSize(int n, int m)
    {
        // Arrange & Act
        var matrix = new MatrixShort(n, m);

        // Assert
        Assert.Equal(n, matrix.GetLength(0));
        Assert.Equal(m, matrix.GetLength(1));
    }


    [Theory]
    [InlineData(2, 3)]
    [InlineData(3, 2)]
    [InlineData(4, 4)]
    public void InitializeConstructor_CreatesMatrixWithSpecifiedSizeAndInitialValue(int n, int m)
    {
        // Arrange
        ushort initialValue = 5;

        // Act
        var matrix = new MatrixShort(n, m, initialValue);

        // Assert
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Assert.Equal(initialValue, matrix[i, j]);
            }
        }
    }


    [Fact]
    public void InputElements_Method_UpdatesMatrixElements()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);

        // Set up console input
        string input = "1\n2\n3\n4\n";
        using (var stringReader = new System.IO.StringReader(input))
        {
            Console.SetIn(stringReader);

            // Act
            matrix.InputElements();
        }

        // Assert
        Assert.Equal(1, matrix[0, 0]);
        Assert.Equal(2, matrix[0, 1]);
        Assert.Equal(3, matrix[1, 0]);
        Assert.Equal(4, matrix[1, 1]);
    }


    [Fact]
    public void DisplayElements_Method_PrintsMatrixElements()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);
        matrix.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        var expectedOutput = "Matrix elements:\n1 2 \n3 4 \n";
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        matrix.DisplayElements();

        // Assert
        Assert.Equal(expectedOutput, consoleOutput.ToString());
    }


    [Fact]
    public void AssignElements_Method_SetsAllMatrixElementsToGivenValue()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);
        ushort value = 5;

        // Act
        matrix.AssignElements(value);

        // Assert
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Assert.Equal(value, matrix[i, j]);
            }
        }
    }

    [Fact]
    public void CountMatrices_StaticMethod_ReturnsCorrectNumberOfMatrices()
    {
        // Arrange
        int initialCount = MatrixShort.CountMatrices();
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(3, 3);

        // Act
        int finalCount = MatrixShort.CountMatrices();

        // Assert
        Assert.Equal(initialCount + 2, finalCount);
    }


    // ... other tests

    [Fact]
    public void IncrementOperator_IncrementsAllMatrixElements()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);
        matrix.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act
        matrix++;

        // Assert
        Assert.Equal((ushort)2, matrix[0, 0]);
        Assert.Equal((ushort)3, matrix[0, 1]);
        Assert.Equal((ushort)4, matrix[1, 0]);
        Assert.Equal((ushort)5, matrix[1, 1]);
    }

    [Fact]
    public void DecrementOperator_DecrementsAllMatrixElements()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);
        matrix.SetElements(new ushort[,] { { 5, 6 }, { 7, 8 } });

        // Act
        matrix--;

        // Assert
        Assert.Equal((ushort)4, matrix[0, 0]);
        Assert.Equal((ushort)5, matrix[0, 1]);
        Assert.Equal((ushort)6, matrix[1, 0]);
        Assert.Equal((ushort)7, matrix[1, 1]);
    }


    [Fact]
    public void LogicalNotOperator_ReturnsTrueIfMatrixIsNotEmpty()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);
        matrix.SetElements(new ushort[,] { { 1, 0 }, { 3, 4 } });

        // Act & Assert
        Assert.True(!matrix);
    }

     [Fact]
    public void AdditionOperator_AddsTwoMatrices_ElementWise()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 5, 6 }, { 7, 8 } });

        // Act
        var result = matrix1 + matrix2;

        // Assert
        Assert.Equal(new ushort[,] { { 6, 8 }, { 10, 12 } }, result.ToArray());
    }

    [Fact]
    public void AdditionOperator_AddsScalarToMatrix_ElementWise()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);
        matrix.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        short scalar = 5;

        // Act
        var result = matrix + scalar;

        // Assert
        Assert.Equal(new ushort[,] { { 6, 7 }, { 8, 9 } }, result.ToArray());
    }

    // Subtraction operator tests
    [Fact]
    public void SubtractionOperator_SubtractsTwoMatrices_ElementWise()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 5, 6 }, { 7, 8 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act
        var result = matrix1 - matrix2;

        // Assert
        Assert.Equal(new ushort[,] { { 4, 4 }, { 4, 4 } }, result.ToArray());
    }

    [Fact]
    public void SubtractionOperator_SubtractsScalarFromMatrix_ElementWise()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);
        matrix.SetElements(new ushort[,] { { 5, 6 }, { 7, 8 } });
        short scalar = 2;

        // Act
        var result = matrix - scalar;

        // Assert
        Assert.Equal(new ushort[,] { { 3, 4 }, { 5, 6 } }, result.ToArray());
    }
    
    [Fact]
    public void Multiply_Operator_MultiplicationWithAnotherMatrix()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);

        // Fill matrices with values
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 5, 6 }, { 7, 8 } });

        // Act
        var result = matrix1 * matrix2;

        // Assert
        Assert.Equal(19, result[0, 0]);
        Assert.Equal(22, result[0, 1]);
        Assert.Equal(43, result[1, 0]);
        Assert.Equal(50, result[1, 1]);
    }


    [Fact]
    public void Multiply_Operator_MultiplicationWithScalar()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);

        // Fill matrix with values
        matrix.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act
        var result = matrix * 2;

        // Assert
        Assert.Equal(2, result[0, 0]);
        Assert.Equal(4, result[0, 1]);
        Assert.Equal(6, result[1, 0]);
        Assert.Equal(8, result[1, 1]);
    }

    [Fact]
    public void Modulus_Operator_ModulusWithAnotherMatrix()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);

        // Fill matrices with values
        matrix1.SetElements(new ushort[,] { { 5, 6 }, { 7, 8 } });
        matrix2.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });

        // Act
        var result = matrix1 % matrix2;

        // Assert
        Assert.Equal(1, result[0, 0]);
        Assert.Equal(0, result[0, 1]);
        Assert.Equal(3, result[1, 0]);
        Assert.Equal(3, result[1, 1]);
    }

    [Fact]
    public void Modulus_Operator_ModulusWithScalar()
    {
        // Arrange
        var matrix = new MatrixShort(2, 2);

        // Fill matrix with values
        matrix.SetElements(new ushort[,] { { 5, 6 }, { 7, 8 } });

        // Act
        var result = matrix % 3;

        // Assert
        Assert.Equal(2, result[0, 0]);
        Assert.Equal(0, result[0, 1]);
        Assert.Equal(1, result[1, 0]);
        Assert.Equal(2, result[1, 1]);
    }

     [Fact]
    public void EqualityOperator_ReturnsTrueWhenMatricesAreEqual()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act & Assert
        Assert.True(matrix1 == matrix2);
    }

    [Fact]
    public void EqualityOperator_ReturnsFalseWhenMatricesAreNotEqual()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 5 } });

        // Act & Assert
        Assert.False(matrix1 == matrix2);
    }

    [Fact]
    public void InequalityOperator_ReturnsTrueWhenMatricesAreNotEqual()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 5 } });

        // Act & Assert
        Assert.True(matrix1 != matrix2);
    }

    [Fact]
    public void InequalityOperator_ReturnsFalseWhenMatricesAreEqual()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act & Assert
        Assert.False(matrix1 != matrix2);
    }

    //
     [Fact]
    public void GreaterThanOperator_ReturnsTrueWhenMatrix1IsGreaterThanMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act & Assert
        Assert.True(matrix1 > matrix2);
    }

    [Fact]
    public void GreaterThanOperator_ReturnsFalseWhenMatrix1IsNotGreaterThanMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });

        // Act & Assert
        Assert.False(matrix1 > matrix2);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_ReturnsTrueWhenMatrix1IsGreaterThanOrEqualToMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act & Assert
        Assert.True(matrix1 >= matrix2);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_ReturnsFalseWhenMatrix1IsNotGreaterThanOrEqualToMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });

        // Act & Assert
        Assert.False(matrix1 >= matrix2);
    }
    
    [Fact]
    public void LessThanOperator_ReturnsTrueWhenMatrix1IsLessThanMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });

        // Act & Assert
        Assert.True(matrix1 < matrix2);
    }

    [Fact]
    public void LessThanOperator_ReturnsFalseWhenMatrix1IsNotLessThanMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act & Assert
        Assert.False(matrix1 < matrix2);
    }

    [Fact]
    public void LessThanOrEqualOperator_ReturnsTrueWhenMatrix1IsLessThanOrEqualToMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });
        matrix2.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });

        // Act & Assert
        Assert.True(matrix1 <= matrix2);
    }

    [Fact]
    public void LessThanOrEqualOperator_ReturnsFalseWhenMatrix1IsNotLessThanOrEqualToMatrix2()
    {
        // Arrange
        var matrix1 = new MatrixShort(2, 2);
        var matrix2 = new MatrixShort(2, 2);
        matrix1.SetElements(new ushort[,] { { 2, 3 }, { 4, 5 } });
        matrix2.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

        // Act & Assert
        Assert.False(matrix1 <= matrix2);
    }
}
