using GeometryLibrary.Helpers;
using GeometryLibrary.Interfaces;
using GeometryLibrary.Models;

namespace GeometryLibrary.Services;

public class Circle : IShape
{
    private readonly double _radius;

    /// <summary>
    /// Private constructor to initialize the radius of the circle.
    /// </summary>
    private Circle(double radius)
    {
        _radius = radius;
    }

    /// <summary>
    /// Creates a new instance of the Circle class with the specified radius.
    /// </summary>
    /// <returns>A GeometryResult object containing either a successful instance of Circle or an error message.</returns>
    public static GeometryResult<Circle> Create(double radius)
    {
        if (radius <= 0)
        {
            return GeometryResult<Circle>.Failure(Errors.ErrorDictionary[ErrorCode.InvalidRadiusFormat]);
        }

        var circle = new Circle(radius);
        return GeometryResult<Circle>.Success(circle);
    }

    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public double CalculateArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}