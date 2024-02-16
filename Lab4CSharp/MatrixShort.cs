using System;

public class MatrixShort
{
    protected ushort[,] ShortArray;
    protected int n, m;
    protected int codeError;
    protected static int num_m;
    protected int Length => ShortArray.Length;

    // Конструктор без параметрів
    public MatrixShort()
    {
        n = 1;
        m = 1;
        ShortArray = new ushort[n, m];
        num_m++;
    }

    // Конструктор з двома параметрами
    public MatrixShort(int n, int m)
    {
        this.n = n;
        this.m = m;
        ShortArray = new ushort[n, m];
        num_m++;
    }

    // Конструктор з трьома параметрами
    public MatrixShort(int n, int m, ushort initialValue)
    {
        this.n = n;
        this.m = m;
        ShortArray = new ushort[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortArray[i, j] = initialValue;
            }
        }
        num_m++;
    }

    // Деструктор
    ~MatrixShort()
    {
        Console.WriteLine("Destructor is called");
    }

    // Ввести елементи вектора з клавіатури
    public void InputElements()
    {
        Console.WriteLine("Enter the elements of the matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Enter element [{i},{j}]: ");
                ShortArray[i, j] = Convert.ToUInt16(Console.ReadLine());
            }
        }
    }

    // Вивести елементи вектора на екран
    public void DisplayElements()
    {
        Console.WriteLine("Matrix elements:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(ShortArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Присвоєння всім елементам масиву вектора деякого значення
    public void AssignElements(ushort value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortArray[i, j] = value;
            }
        }
    }

    // Статичний метод, що підраховує кількість матриць даного типу
    public static int CountMatrices()
    {
        return num_m;
    }

    // Присвоїти елементам масиву деяке значення (параметр)
    public void SetElements(ushort[,] elements)
    {
        if (elements.GetLength(0) != n || elements.GetLength(1) != m)
        {
            Console.WriteLine("Cannot assign elements: dimensions do not match.");
            return;
        }

        ShortArray = elements;
    }

    public int GetLength(int dimension)
    {
        if (dimension == 0)
            return n;
        else if (dimension == 1)
            return m;
        else
            throw new IndexOutOfRangeException();
    }

    // Властивість для отримання та встановлення значення поля codeError (доступна для читання і запису)
    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор для доступу до елементів матриці
    public ushort this[int i, int j]
    {
        get
        {
            if (IsValidIndex(i, j))
                return ShortArray[i, j];
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (IsValidIndex(i, j))
                ShortArray[i, j] = value;
            else
                codeError = -1;
        }
    }

    // Індексатор з одним індексом для доступу до елементів за формулою k = i * m + j
    public ushort this[int k]
    {
        get
        {
            int i = k / m;
            int j = k % m;
            if (IsValidIndex(i, j))
                return ShortArray[i, j];
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            int i = k / m;
            int j = k % m;
            if (IsValidIndex(i, j))
                ShortArray[i, j] = value;
            else
                codeError = -1;
        }
    }

    // Перевірка на дійсність індексів
    private bool IsValidIndex(int i, int j)
    {
        return i >= 0 && i < n && j >= 0 && j < m;
    }

    public static MatrixShort operator ++(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortArray[i, j]++;
            }
        }
        return matrix;
    }

    public ushort[,] ToArray()
    {
        ushort[,] arrayCopy = new ushort[n, m];
        Array.Copy(ShortArray, arrayCopy, n * m);
        return arrayCopy;
    }

    public static MatrixShort operator --(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                if (matrix.ShortArray[i, j] == 0)
                    return false;
            }
        }
        return true;
    }

    public static bool operator false(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                if (matrix.ShortArray[i, j] == 0)
                    return true;
            }
        }
        return false;
    }

    public static bool operator !(MatrixShort matrix)
    {
        return matrix.n != 0 || matrix.m != 0;
    }

    public static MatrixShort operator ~(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortArray[i, j] = (ushort)~matrix.ShortArray[i, j];
            }
        }
        return matrix;
    }
    public static MatrixShort operator +(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Matrix dimensions must be the same for addition.");

        MatrixShort result = new MatrixShort(matrix1.GetLength(0), matrix1.GetLength(1));

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix1[i, j] + matrix2[i, j]);
            }
        }

        return result;
    }

    public static MatrixShort operator +(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.GetLength(0), matrix.GetLength(1));

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix[i, j] + scalar);
            }
        }

        return result;
    }

    public static MatrixShort operator -(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Matrix dimensions must be the same for subtraction.");

        MatrixShort result = new MatrixShort(matrix1.GetLength(0), matrix1.GetLength(1));

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix1[i, j] - matrix2[i, j]);
            }
        }

        return result;
    }

    public static MatrixShort operator -(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.GetLength(0), matrix.GetLength(1));

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix[i, j] - scalar);
            }
        }

        return result;
    }

    public static MatrixShort operator *(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
            throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix.");

        MatrixShort result = new MatrixShort(matrix1.GetLength(0), matrix2.GetLength(1));

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                ushort sum = 0;
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    sum += (ushort)(matrix1[i, k] * matrix2[k, j]);
                }
                result[i, j] = sum;
            }
        }

        return result;
    }

    public static MatrixShort operator *(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.GetLength(0), matrix.GetLength(1));

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix[i, j] * scalar);
            }
        }

        return result;
    }

    public static MatrixShort operator /(MatrixShort matrix1, MatrixShort matrix2)
    {
        throw new NotImplementedException(); // Implementation for matrix division is not provided in this example
    }

    public static MatrixShort operator /(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.GetLength(0), matrix.GetLength(1));

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix[i, j] / scalar);
            }
        }

        return result;
    }

    public static MatrixShort operator %(MatrixShort matrix1, MatrixShort matrix2)
    {
         if (matrix1.GetLength(1) != matrix2.GetLength(0))
            throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix.");
      MatrixShort result = new MatrixShort(matrix1.GetLength(0), matrix1.GetLength(1));

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix1[i, j] % matrix2[i,j]);
            }
        }

        return result;
    }

    public static MatrixShort operator %(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.GetLength(0), matrix.GetLength(1));

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = (ushort)(matrix[i, j] % scalar);
            }
        }

        return result;
    }

    public static MatrixShort operator |(MatrixShort matrix1, MatrixShort matrix2)
{
    if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        throw new ArgumentException("Matrix dimensions must be the same for bitwise OR operation.");

    MatrixShort result = new MatrixShort(matrix1.GetLength(0), matrix1.GetLength(1));

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            result[i, j] = (ushort)(matrix1[i, j] | matrix2[i, j]);
        }
    }

    return result;
}

public static MatrixShort operator |(MatrixShort matrix, ushort scalar)
{
    MatrixShort result = new MatrixShort(matrix.GetLength(0), matrix.GetLength(1));

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            result[i, j] = (ushort)(matrix[i, j] | scalar);
        }
    }

    return result;
}

public static MatrixShort operator ^(MatrixShort matrix1, MatrixShort matrix2)
{
    if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        throw new ArgumentException("Matrix dimensions must be the same for bitwise XOR operation.");

    MatrixShort result = new MatrixShort(matrix1.GetLength(0), matrix1.GetLength(1));

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            result[i, j] = (ushort)(matrix1[i, j] ^ matrix2[i, j]);
        }
    }

    return result;
}

public static MatrixShort operator ^(MatrixShort matrix, ushort scalar)
{
    MatrixShort result = new MatrixShort(matrix.GetLength(0), matrix.GetLength(1));

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            result[i, j] = (ushort)(matrix[i, j] ^ scalar);
        }
    }

    return result;
}

public static bool operator ==(MatrixShort matrix1, MatrixShort matrix2)
{
    if (ReferenceEquals(matrix1, matrix2)) // Check if both matrices reference the same object
        return true;

    if (matrix1 is null || matrix2 is null) // Check if either matrix is null
        return false;

    if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        return false; // Matrices must have the same dimensions for equality

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            if (matrix1[i, j] != matrix2[i, j])
                return false; // If any element is different, matrices are not equal
        }
    }

    return true; // If all elements are equal, matrices are equal
}

public static bool operator !=(MatrixShort matrix1, MatrixShort matrix2)
{
    return !(matrix1 == matrix2); // Return the negation of the equality operator
}

public static bool operator >(MatrixShort matrix1, MatrixShort matrix2)
{
    if (matrix1 is null || matrix2 is null)
        throw new ArgumentNullException(); // Handle null matrices

    if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        throw new ArgumentException("Matrix dimensions must be the same for comparison.");

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            if (matrix1[i, j] <= matrix2[i, j])
                return false; // If any element in matrix1 is not greater than the corresponding element in matrix2, return false
        }
    }

    return true; // All elements in matrix1 are greater than the corresponding elements in matrix2
}

public static bool operator >=(MatrixShort matrix1, MatrixShort matrix2)
{
    return matrix1 == matrix2 || matrix1 > matrix2; // Return true if matrices are equal or matrix1 is greater than matrix2
}

public static bool operator <(MatrixShort matrix1, MatrixShort matrix2)
{
    return !(matrix1 >= matrix2); // Return true if matrix1 is not greater than or equal to matrix2
}

public static bool operator <=(MatrixShort matrix1, MatrixShort matrix2)
{
    return matrix1 == matrix2 || matrix1 < matrix2; // Return true if matrices are equal or matrix1 is less than matrix2
}


    
}

