using GameEngine.Interfaces;
using SFML.System;

namespace GameEngine
{
    public static class RectangleObjectCollidator
    {
        public static bool CheckForCollision(IGameObject first, IGameObject second)
        {
            //2 < x < 5; 2 < y < 5;   ;;   1 < x < 6; 3 < y < 4
            var firstFarVer = new Vector2i(first.Position.X + first.Size.X, first.Position.Y + first.Size.Y);
            var secondFarVer = new Vector2i(second.Position.X + second.Size.X, second.Position.Y + second.Size.Y);

            return first.Position.X == 3;
        }
    }
}
