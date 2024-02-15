using System;

public class VectorShort
{
    // protected short[] ShortArray;
    public short[] ShortArray;

    // protected uint n;
    public uint n;

    // protected uint codeError;
    public uint codeError;

    // protected static uint num_v;
    public static uint num_v;


    // Constructors
    public VectorShort()
    {
        ShortArray = new short[1];
        n = 1;
        codeError = 0;
        num_v++;
    }

    public VectorShort(uint size)
    {
        ShortArray = new short[size];
        n = size;
        codeError = 0;
        num_v++;
    }

    public VectorShort(uint size, short initValue)
    {
        ShortArray = new short[size];
        n = size;
        codeError = 0;
        for (int i = 0; i < size; i++)
        {
            ShortArray[i] = initValue;
        }
        num_v++;
    }

    // Destructor
    ~VectorShort()
    {
        Console.WriteLine("Vector destructed.");
    }

    // Methods
    public void InputElements()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            string input = Console.ReadLine();
            if (short.TryParse(input, out short value))
            {
                ShortArray[i] = value;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid short value.");
                i--; // Retry input for the same index
            }
        }
    }

    public String DisplayElements()
    {
        string outputData = "Vector elements:";
        for (int i = 0; i < n; i++)
        {
            outputData += " " + ShortArray[i];
        }
        Console.WriteLine(outputData);
        return outputData;

    }

    public void AssignValue(short value)
    {
        for (int i = 0; i < n; i++)
        {
            ShortArray[i] = value;
        }
    }

    public static uint NumVectors()
    {
        return num_v;
    }

    // Properties
    public uint Size => n;

    public uint CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public int Length { get; internal set; }

    // Indexer
    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= n)
            {
                codeError = 10;
                return 0;
            }
            else
            {
                return ShortArray[index];
            }
        }
        set
        {
            if (index < 0 || index >= n)
            {
                codeError = 10;
            }
            else
            {
                ShortArray[index] = value;
            }
        }
    }

    // Overloading unary operators
    public static VectorShort operator ++(VectorShort v)
    {
        for (int i = 0; i < v.Size; i++)
        {
            v[i]++;
        }
        return v;
    }

    public static VectorShort operator --(VectorShort v)
    {
        for (int i = 0; i < v.Size; i++)
        {
            v[i]--;
        }
        return v;
    }

    public static bool operator true(VectorShort v)
    {
        for (int i = 0; i < v.Size; i++)
        {
            if (v[i] == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(VectorShort v)
    {
        return v.Size == 0;
    }

    public static bool operator !(VectorShort v)
    {
        return v.Size != 0;
    }

    public static VectorShort operator +(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] + v2[i]);
        }
        return result;
    }

    public static VectorShort operator +(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.Size);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = (short)(v[i] + scalar);
        }
        return result;
    }

    public static VectorShort operator -(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] - v2[i]);
        }
        return result;
    }

    public static VectorShort operator -(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.Size);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = (short)(v[i] - scalar);
        }
        return result;
    }

    public static VectorShort operator *(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] * v2[i]);
        }
        return result;
    }

    public static VectorShort operator *(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.Size);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = (short)(v[i] * scalar);
        }
        return result;
    }

    public static VectorShort operator /(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] / v2[i]);
        }
        return result;
    }

    public static VectorShort operator /(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.Size);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = (short)(v[i] / scalar);
        }
        return result;
    }

    public static VectorShort operator %(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] % v2[i]);
        }
        return result;
    }

    public static VectorShort operator %(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.Size);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = (short)(v[i] % scalar);
        }
        return result;
    }

    public static VectorShort operator |(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] | v2[i]);
        }
        return result;
    }

    public static VectorShort operator &(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] & v2[i]);
        }
        return result;
    }

    public static VectorShort operator ^(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");

        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] ^ v2[i]);
        }
        return result;
    }

    public static VectorShort operator ^(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.Size);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = (short)(v[i] ^ scalar);
        }
        return result;
    }

    public static VectorShort operator >>(VectorShort v, int shift)
    {
        VectorShort result = new VectorShort(v.Size);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = (short)(v[i] >> shift);
        }
        return result;
    }

    public static VectorShort operator <<(VectorShort v1, int shift)
    {
        VectorShort result = new VectorShort(v1.Size);
        for (int i = 0; i < v1.Size; i++)
        {
            result[i] = (short)(v1[i] << shift);
        }
        return result;
    }

    public static bool operator ==(VectorShort v1, VectorShort v2)
    {
        if (ReferenceEquals(v1, v2))
            return true;
        if ((object)v1 == null || (object)v2 == null)
            return false;
        if (v1.Size != v2.Size)
            return false;
        for (int i = 0; i < v1.Size; i++)
        {
            if (v1[i] != v2[i])
                return false;
        }
        return true;
    }

    public static bool operator !=(VectorShort v1, VectorShort v2)
    {
        return !(v1 == v2);
    }

    public static bool operator >(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");
        for (int i = 0; i < v1.Size; i++)
        {
            if (v1[i] <= v2[i])
                return false;
        }
        return true;
    }

    public static bool operator >=(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");
        for (int i = 0; i < v1.Size; i++)
        {
            if (v1[i] < v2[i])
                return false;
        }
        return true;
    }

    public static bool operator <(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");
        for (int i = 0; i < v1.Size; i++)
        {
            if (v1[i] >= v2[i])
                return false;
        }
        return true;
    }

    public static bool operator <=(VectorShort v1, VectorShort v2)
    {
        if (v1.Size != v2.Size)
            throw new ArgumentException("Vectors must be of the same size.");
        for (int i = 0; i < v1.Size; i++)
        {
            if (v1[i] > v2[i])
                return false;
        }
        return true;
    }

    

}
