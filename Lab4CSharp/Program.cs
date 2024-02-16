namespace Lab4CSharp;

internal class Program
{
    public static void task1()
    {


        Console.Write($"Enter side A of rectangle: ");
        int sideA = Convert.ToInt32(Console.ReadLine());
        Console.Write($"Enter side B of rectangle: ");
        int sideB = Convert.ToInt32(Console.ReadLine());
        Console.Write($"Enter color of rectangle: ");
        int color = Convert.ToInt32(Console.ReadLine());

        Rectangle rectangle = new(sideA, sideB, color);


        // Test functionality
        Console.WriteLine($"Rect: Side A = {rectangle.SideA}, Side B = {rectangle.SideB}, Color = {rectangle.Color}");
        Console.WriteLine($"Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.CalculatePerimeter()}, Is Square: {rectangle.IsSquare()}");
        Console.WriteLine($"Accessing sides using index: {rectangle[0]} (Side A), {rectangle[1]} (Side B), {rectangle[2]} (Color)");
        rectangle++;
        Console.WriteLine($"After ++ operation: Side A = {rectangle.SideA}, Side B = {rectangle.SideB}");
        rectangle *= 2;
        Console.WriteLine($"After * 2 operation: Side A = {rectangle.SideA}, Side B = {rectangle.SideB}");
        Console.WriteLine($"Rect to string: {(string)rectangle}");


        Rectangle rectangle1 = (Rectangle)"10, 20, 130";
        Console.WriteLine($"Rect from string: Side A = {rectangle1.SideA}, Side B = {rectangle1.SideB}, Color = {rectangle.Color}");
    }

    public static void task2()
    {
        // Creating vectors
        VectorShort v1 = new VectorShort(3, 5);
        VectorShort v2 = new VectorShort(3, 10);

        // Displaying vector elements
        Console.WriteLine("Vector 1:");
        v1.DisplayElements();

        Console.WriteLine("Vector 2:");
        v2.DisplayElements();

        // Performing arithmetic operations
        VectorShort sum = v1 + v2;
        VectorShort difference = v1 - v2;
        VectorShort product = v1 * v2;
        VectorShort division = v1 / v2;
        VectorShort remainder = v1 % v2;

        // Displaying results
        Console.WriteLine("Sum:");
        sum.DisplayElements();

        Console.WriteLine("Difference:");
        difference.DisplayElements();

        Console.WriteLine("Product:");
        product.DisplayElements();

        Console.WriteLine("Division:");
        division.DisplayElements();

        Console.WriteLine("Remainder:");
        remainder.DisplayElements();

        // Bitwise operations
        VectorShort bitwiseAnd = v1 & v2;
        VectorShort bitwiseOr = v1 | v2;
        VectorShort bitwiseXor = v1 ^ v2;
        VectorShort leftShift = v1 << 2;
        VectorShort rightShift = v2 >> 1;

        // Displaying bitwise operation results
        Console.WriteLine("Bitwise AND:");
        bitwiseAnd.DisplayElements();

        Console.WriteLine("Bitwise OR:");
        bitwiseOr.DisplayElements();

        Console.WriteLine("Bitwise XOR:");
        bitwiseXor.DisplayElements();

        Console.WriteLine("Left Shift:");
        leftShift.DisplayElements();

        Console.WriteLine("Right Shift:");
        rightShift.DisplayElements();

        // Comparison operations
        Console.WriteLine($"v1 == v2 : {v1 == v2}");
        Console.WriteLine($"v1 != v2 : {v1 != v2}");
        Console.WriteLine($"v1 > v2 : {v1 > v2}");
        Console.WriteLine($"v1 >= v2 : {v1 >= v2}");
        Console.WriteLine($"v1 < v2 : {v1 < v2}");
        Console.WriteLine($"v1 <= v2 : {v1 <= v2}");

        // Unary operators
        Console.WriteLine("Vector 1 incremented:");
        (++v1).DisplayElements();

        Console.WriteLine("Vector 2 decremented:");
        (--v2).DisplayElements();

        // Input elements
        VectorShort v3 = new VectorShort(4);
        Console.WriteLine("Enter elements for Vector 3:");
        v3.InputElements();
        Console.WriteLine("Vector 3:");
        v3.DisplayElements();

        // Assign value
        v3.AssignValue(8);
        Console.WriteLine("Vector 3 after assigning value 8 to all elements:");
        v3.DisplayElements();

        // Number of vectors
        Console.WriteLine($"Number of vectors created: {VectorShort.NumVectors()}");

        // Destructor will be called automatically when objects go out of scope
    }

    public static void task3()
        {
            // Create a MatrixShort object using the constructor with two parameters
            MatrixShort matrix1 = new MatrixShort(2, 2);
            matrix1.SetElements(new ushort[,] { { 1, 2 }, { 3, 4 } });

            // Create another MatrixShort object using the constructor with three parameters
            MatrixShort matrix2 = new MatrixShort(2, 2, 5);

            // Display the elements of matrix1
            Console.WriteLine("Matrix 1:");
            matrix1.DisplayElements();
            Console.WriteLine();

            // Display the elements of matrix2
            Console.WriteLine("Matrix 2:");
            matrix2.DisplayElements();
            Console.WriteLine();

            // Perform some operations
            // Increment all elements of matrix1
            matrix1++;
            Console.WriteLine("After incrementing all elements of matrix1:");
            matrix1.DisplayElements();
            Console.WriteLine();

            // Multiply matrix2 by a scalar value
            MatrixShort multipliedMatrix = matrix2 * 2;
            Console.WriteLine("After multiplying matrix2 by 2:");
            multipliedMatrix.DisplayElements();
            Console.WriteLine();

            // Convert matrix2 to a 2D array
            ushort[,] array = matrix2.ToArray();
            Console.WriteLine("Matrix 2 converted to 2D array:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    static void Main(string[] args)
    {
        Console.WriteLine("Lab 3 ");

        try
        {
            Console.WriteLine("Input number of task(1,2,3): ");
            int task = Convert.ToInt32(Console.ReadLine());
            switch (task)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                case 3:
                    task3();
                    break;
                default:
                    Console.WriteLine("Task not found");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}

