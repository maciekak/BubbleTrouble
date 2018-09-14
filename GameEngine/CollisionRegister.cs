using System;
using System.Collections.Generic;
using GameEngine.Enums;
using GameEngine.Interfaces;

namespace GameEngine
{
    internal class CollisionRegister
    {
        public Tuple<IList<ICanCollide>, IList<ICanCollide>> RegistredItems { get; }
        private readonly CollisionRegisterType _collisionRegisterType;
        private readonly CollisionCheckingEnd _collisionCheckingEnd;

        public CollisionRegister(
            IList<ICanCollide> first,
            IList<ICanCollide> second,
            CollisionRegisterType collisionRegisterType, 
            CollisionCheckingEnd collisionCheckingEnd)
        {
            _collisionRegisterType = collisionRegisterType;
            _collisionCheckingEnd = collisionCheckingEnd;
            RegistredItems = new Tuple<IList<ICanCollide>, IList<ICanCollide>>(first, second);
        }

        public bool CheckForCollision()
        {
            IEnumerable<ICanCollide> left;
            IEnumerable<ICanCollide> right;
            if (_collisionRegisterType == CollisionRegisterType.RightSide)
            {
                left = RegistredItems.Item2;
                right = RegistredItems.Item1;
            }
            else
            {
                left = RegistredItems.Item1;
                right = RegistredItems.Item2;
            }

            var wasAnyCollision = false;

            foreach (var leftItem in left)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var rightItem in right)
                {
                    if (!RectangleObjectCollidator.CheckForCollision(leftItem, rightItem))
                        continue;

                    wasAnyCollision = true;
                    leftItem.WasCollision(rightItem);
                    if (_collisionRegisterType == CollisionRegisterType.BothSides)
                        rightItem.WasCollision(leftItem);

                    if (_collisionCheckingEnd == CollisionCheckingEnd.First)
                        return true;

                    if (_collisionCheckingEnd == CollisionCheckingEnd.Group)
                        break;
                }
            }

            return wasAnyCollision;
        }
    }
}
