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
            public Vector2i Position { get; set; }
            public Vector2i Size { get; set; }
            public void WasCollision(IGameObject gameObject)
            {
            }
        }

        [TestMethod]
        [DataRow(2, 2, 3, 3, 1, 3, 5, 1)]
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

            //Assert
            Assert.IsTrue(result);
        }
    }
}
