using GeometryLibrary.Models;
using GeometryLibrary.Services;

namespace GeometryLibrary.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void Create_WithValidSides_ReturnsSuccessResult()
        {
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;

            var result = Triangle.Create(side1, side2, side3);

            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void Create_WithNegativeSide_ReturnsFailureResult()
        {
            double side1 = 3;
            double side2 = -4;
            double side3 = 5;

            var result = Triangle.Create(side1, side2, side3);

            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorMessage, Is.EqualTo(Errors.ErrorDictionary[ErrorCode.InvalidTriangleSideFormat]));
        }

        [Test]
        public void Create_WithInvalidSides_ReturnsFailureResult()
        {
            double side1 = 1;
            double side2 = 2;
            double side3 = 10;

            var result = Triangle.Create(side1, side2, side3);

            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorMessage, Is.EqualTo(Errors.ErrorDictionary[ErrorCode.InvalidTriangleSides]));
        }

        [Test]
        public void CalculateArea_WithValidSides_ReturnsCorrectArea()
        {
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;

            double expectedArea = 6;

            var triangle = Triangle.Create(side1, side2, side3);

            double area = triangle.Value.CalculateArea();

            Assert.That(area, Is.EqualTo(expectedArea));
        }

        [Test]
        public void IsRightAngled_WithRightAngledTriangle_ReturnsTrue()
        {
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;

            var triangle =  Triangle.Create(side1, side2, side3);

            bool isRightAngled = triangle.Value.IsRightAngled();

            Assert.IsTrue(isRightAngled);
        }

        [Test]
        public void IsRightAngled_WithNonRightAngledTriangle_ReturnsFalse()
        {
            double side1 = 2;
            double side2 = 3;
            double side3 = 4;

            var triangle =  Triangle.Create(side1, side2, side3);

            bool isRightAngled = triangle.Value.IsRightAngled();

            Assert.IsFalse(isRightAngled);
        }
    }
}
