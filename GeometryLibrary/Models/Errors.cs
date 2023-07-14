namespace GeometryLibrary.Models;

public static class Errors
{
    public static readonly Dictionary<ErrorCode, string> ErrorDictionary = new()
    {
        { ErrorCode.Default, "Something went wrong." },
        { ErrorCode.InvalidRadiusFormat, "Радиус должен быть положительным числом." },
        { ErrorCode.InvalidRightTriangleSides, "Невозможно построить прямоугольный треугольник с указанными сторонами." },
        { ErrorCode.InvalidTriangleSideFormat, "Все стороны треугольника должны быть положительными числами." },
        { ErrorCode.InvalidTriangleSides, "Невозможно построить треугольник с указанными сторонами."}
    };
}