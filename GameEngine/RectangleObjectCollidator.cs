﻿using GameEngine.Interfaces;
using SFML.System;

namespace GameEngine
{
    public static class RectangleObjectCollidator
    {
        public static bool CheckForCollision(ICanCollide first, ICanCollide second)
        {
            var firstFarVerticle = new Vector2i(first.Position.X + first.Size.X, first.Position.Y + first.Size.Y);
            var secondFarVerticle = new Vector2i(second.Position.X + second.Size.X, second.Position.Y + second.Size.Y);


            return SecondCollideWithFirstOnX(first, second, firstFarVerticle, secondFarVerticle)
                && SecondCollideWithFirstOnY(first, second, firstFarVerticle, secondFarVerticle);
        }

        private static bool SecondCollideWithFirstOnY(ICanCollide first, ICanCollide second, Vector2i firstFarVerticle, Vector2i secondFarVerticle)
        {
            return ValueBeetweenValues(first.Position.Y, second.Position.Y, firstFarVerticle.Y)
                   || ValueBeetweenValues(first.Position.Y, secondFarVerticle.Y, firstFarVerticle.Y)
                   || ValueBeetweenValues(second.Position.Y, first.Position.Y, secondFarVerticle.Y);
        }

        private static bool SecondCollideWithFirstOnX(ICanCollide first, ICanCollide second, Vector2i firstFarVerticle, Vector2i secondFarVerticle)
        {
            return ValueBeetweenValues(first.Position.X, second.Position.X, firstFarVerticle.X)
                   || ValueBeetweenValues(first.Position.X, secondFarVerticle.X, firstFarVerticle.X)
                   || ValueBeetweenValues(second.Position.X, first.Position.X, secondFarVerticle.X);
        }

        private static bool ValueBeetweenValues(int left, int middle, int right)
        {
            return left <= middle && middle <= right;
        }
    }
}
