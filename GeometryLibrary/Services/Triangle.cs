using GeometryLibrary.Helpers;
using GeometryLibrary.Interfaces;
using GeometryLibrary.Models;

namespace GeometryLibrary.Services;

public class Triangle : IShape
{
    private readonly double _side1;
    private readonly double _side2;
    private readonly double _side3;

    /// <summary>
    /// Private constructor to initialize the sides of the triangle.
    /// </summary>
    private Triangle(double side1, double side2, double side3)
    {
        _side1 = side1;
        _side2 = side2;
        _side3 = side3;
    }

    /// <summary>
    /// Creates a new instance of the Triangle class with the specified side lengths.
    /// </summary>
    /// <returns>A GeometryResult object containing either a successful instance of Triangle or an error message.</returns>
    public static GeometryResult<Triangle> Create(double side1, double side2, double side3)
    {
        string errorMessage;
        if (IsTriangleSideNegative(side1, side2, side3))
        {
            errorMessage = Errors.ErrorDictionary[ErrorCode.InvalidTriangleSideFormat];
            return GeometryResult<Triangle>.Failure(errorMessage);
        }

        if (!IsTriangleValid(side1, side2, side3))
        {
            errorMessage = Errors.ErrorDictionary[ErrorCode.InvalidTriangleSides];
            return GeometryResult<Triangle>.Failure(errorMessage);
        }

        var triangle = new Triangle(side1, side2, side3);
        return GeometryResult<Triangle>.Success(triangle);
    }

    /// <summary>
    /// Calculates the area of the triangle using Heron's formula.
    /// </summary>
    /// <returns>The area of the triangle.</returns>
    public double CalculateArea()
    {
        double semiPerimeter = (_side1 + _side2 + _side3) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - _side1) * (semiPerimeter - _side2) *
                         (semiPerimeter - _side3));
    }

    /// <summary>
    /// Checks if the triangle is valid based on the triangle inequality theorem.
    /// </summary>
    /// <returns>True if the triangle is valid, false otherwise.</returns>
    private static bool IsTriangleValid(double side1, double side2, double side3)
    {
        return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
    }

    /// <summary>
    /// Checks if the triangle is a right-angled triangle.
    /// </summary>
    /// <returns>True if the triangle is right-angled, false otherwise.</returns>
    public bool IsRightAngled()
    {
        double a = Math.Pow(_side1, 2);
        double b = Math.Pow(_side2, 2);
        double c = Math.Pow(_side3, 2);

        return a + b == c || a + c == b || b + c == a;
    }

    /// <summary>
    /// Checks if any side of the triangle is negative.
    /// </summary>
    /// <returns>True if any side is negative, false otherwise.</returns>
    private static bool IsTriangleSideNegative(double side1, double side2, double side3)
    {
        return side1 <= 0 || side2 <= 0 || side3 <= 0;
    }
}