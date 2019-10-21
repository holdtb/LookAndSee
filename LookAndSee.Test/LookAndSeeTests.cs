using NUnit.Framework;
using LookAndSee.Core;
using Shouldly;

namespace LookAndSee.Test
{
    public class Tests
    {

        //1 is read off as "one 1" or 11.
        //11 is read off as "two 1s" or 21.
        //21 is read off as "one 2, then one 1" or 1211.
        //1211 is read off as "one 1, one 2, then two 1s" or 111221.
        //111221 is read off as "three 1s, two 2s, then one 1" or 312211

        [Test]
        public void FirstInSequence()
        {
            // Arrange
            var generator = new Generator();

            // Act
            var result = generator.Current;

            // Assert
            result.ShouldBe("1");
        }

        [Test]
        public void SecondInSequence()
        {
            // Arrange
            var generator = new Generator();
            // Act
            var result = generator.Next(1);
            // Assert
            result.ShouldBe("11");
        }

        [Test]
        public void ThirdInSequence()
        {
            // Arrange
            var generator = new Generator();

            // Act
            var result = generator.Next(2);

            // Assert
            result.ShouldBe("21");
        }

        [Test]
        public void FourthInSequence()
        {
            // Arrange
            var generator = new Generator();

            // Act
            var result = generator.Next(3);

            // Assert
            result.ShouldBe("1211");
        }

        [Test]
        public void FifthInSequence()
        {
            // Arrange
            var generator = new Generator();
            // Act
            var result = generator.Next(4);
            // Assert
            result.ShouldBe("111221");
        }

        [Test]
        public void SixthInSequence()
        {
            // Arrange
            var generator = new Generator();
            // Act
            var result = generator.Next(5);
            // Assert
            result.ShouldBe("312211");
        }
    }
}