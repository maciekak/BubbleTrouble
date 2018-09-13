using System;
using System.Collections.Generic;
using GameEngine.Enums;
using GameEngine.Interfaces;

namespace GameEngine
{
    internal class CollisionRegister
    {
        public Tuple<IList<IGameObject>, IList<IGameObject>> RegistredItems { get; }
        private readonly CollisionRegisterType _collisionRegisterType;
        private readonly CollisionCheckingEnd _collisionCheckingEnd;

        public CollisionRegister(
            IList<IGameObject> first,
            IList<IGameObject> second,
            CollisionRegisterType collisionRegisterType, 
            CollisionCheckingEnd collisionCheckingEnd)
        {
            _collisionRegisterType = collisionRegisterType;
            _collisionCheckingEnd = collisionCheckingEnd;
            RegistredItems = new Tuple<IList<IGameObject>, IList<IGameObject>>(first, second);
        }

        public bool CheckForCollision()
        {
            IEnumerable<IGameObject> left;
            IEnumerable<IGameObject> right;
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
