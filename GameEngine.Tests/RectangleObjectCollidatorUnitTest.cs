using GameEngine.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.System;

namespace GameEngine.Tests
{
    [TestClass]
    public class RectangleObjectCollidatorUnitTest
    {
        private class GameObject : IGameObject
        {
            public Vector2i Position
            { get; set; }
            public Vector2i Size { get; set; }
            public void WasCollision(IGameObject gameObject)
            {
            }
        }

        [TestMethod]
        [DataRow(2, 2, 3, 3, 1, 3, 5, 1)]
        [DataRow(5, 5, 3, 3, 6, 6, 1, 3)]
        [DataRow(1, 1, 2, 2, 0, 2, 4, 2)]
        [DataRow(2, 2, 2, 3, 3, 1, 3, 3)]
        [DataRow(0, 0, 3, 3, 1, 1, 1, 1)]
        [DataRow(0, 0, 3, 3, 1, 1, 3, 1)]
        [DataRow(1, 1, 2, 2, 0, 3, 2, 2)]
        [DataRow(0, 0, 2, 2, 0, 0, 2, 2)]
        [DataRow(2, 2, 2, 2, 0, 4, 2, 2)]
        public void CheckForCollision_ShouldBeTrue_Test(int fpx, int fpy, int fsx, int fsy, int spx, int spy, int ssx, int ssy)
        {
            //Arrange
            var first = new GameObject
            {
                Position = new Vector2i(fpx, fpy),
                Size = new Vector2i(fsx, fsy)
            };

            var second = new GameObject
            {
                Position = new Vector2i(spx, spy),
                Size = new Vector2i(ssx, ssy)
            };

            //Act
            var result = RectangleObjectCollidator.CheckForCollision(first, second);
            var resultReverse = RectangleObjectCollidator.CheckForCollision(second, first);

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(resultReverse);
        }

        [TestMethod]
        [DataRow(2, 2, 2, 2, 1, 5, 2, 1)]
        [DataRow(0, 6, 1, 1, 2, 0, 2, 2)]
        [DataRow(0, 0, 2, 2, 3, 1, 1, 4)]
        [DataRow(0, 0, 2, 2, 3, 2, 1, 4)]
        public void CheckForCollision_ShouldBeFalse_Test(int fpx, int fpy, int fsx, int fsy, int spx, int spy, int ssx, int ssy)
        {
            //Arrange
            var first = new GameObject
            {
                Position = new Vector2i(fpx, fpy),
                Size = new Vector2i(fsx, fsy)
            };

            var second = new GameObject
            {
                Position = new Vector2i(spx, spy),
                Size = new Vector2i(ssx, ssy)
            };

            //Act
            var result = RectangleObjectCollidator.CheckForCollision(first, second);
            var resultReverse = RectangleObjectCollidator.CheckForCollision(second, first);

            //Assert
            Assert.IsFalse(result);
            Assert.IsFalse(resultReverse);
        }
    }
}
