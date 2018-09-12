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
        public void CheckForCollision_Should_BeTrue_Test()
        {
            //Arrange
            var first = new GameObject
            {
                Position = new Vector2i(2, 2),
                Size = new Vector2i(3, 3)
            };

            var second = new GameObject
            {
                Position = new Vector2i(1, 3),
                Size = new Vector2i(5, 1)
            };

            //Act
            var result = RectangleObjectCollidator.CheckForCollision(first, second);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
