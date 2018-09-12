using GameEngine;
using GameEngine.Interfaces;
using SFML.System;

namespace BubbleTrouble.Items
{
    public class Ball : IGravityInteraction
    {
        private Vector2i _speed;

        public Ball(int speedX)
        {
            _speed = new Vector2i(speedX, 0);
        }

        public void Gravitate()
        {
            _speed.Y += Constants.Gravity;
        }
    }
}
