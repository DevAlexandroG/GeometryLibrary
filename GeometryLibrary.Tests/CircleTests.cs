using GeometryLibrary.Models;
using GeometryLibrary.Services;

namespace GeometryLibrary.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void Create_WithValidRadius_ReturnsSuccessResult()
        {
            double radius = 5;
        
            var result = Circle.Create(radius);
        
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void Create_WithZeroRadius_ReturnsFailureResult()
        {
            double radius = 0;

            var result = Circle.Create(radius);

            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorMessage, Is.EqualTo(Errors.ErrorDictionary[ErrorCode.InvalidRadiusFormat]));
        }

        [Test]
        public void Create_WithNegativeRadius_ReturnsFailureResult()
        {
            double radius = -5;

            var result = Circle.Create(radius);

            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorMessage, Is.EqualTo(Errors.ErrorDictionary[ErrorCode.InvalidRadiusFormat]));
        }

        [Test]
        public void CalculateArea_WithValidRadius_ReturnsCorrectArea()
        {
            double radius = 3;
            double expectedArea = Math.PI * Math.Pow(radius, 2);
            var circle =  Circle.Create(radius);

            double area = circle.Value.CalculateArea();

            Assert.That(area, Is.EqualTo(expectedArea));
        }
    }
}