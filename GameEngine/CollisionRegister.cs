using System;
using System.Collections.Generic;
using GameEngine.Enums;
using GameEngine.Interfaces;

namespace GameEngine
{
    public class CollisionRegister
    {
        private readonly Tuple<IEnumerable<IGameObject>, IEnumerable<IGameObject>> _registredItems;
        private readonly CollisionRegisterType _collisionRegisterType;
        private readonly CollisionCheckingEnd _collisionCheckingEnd;

        public CollisionRegister(
            IEnumerable<IGameObject> first, 
            IEnumerable<IGameObject> second,
            CollisionRegisterType collisionRegisterType, 
            CollisionCheckingEnd collisionCheckingEnd)
        {
            _collisionRegisterType = collisionRegisterType;
            _collisionCheckingEnd = collisionCheckingEnd;
            _registredItems = new Tuple<IEnumerable<IGameObject>, IEnumerable<IGameObject>>(first, second);
        }

        public bool CheckForCollision()
        {
            IEnumerable<IGameObject> left;
            IEnumerable<IGameObject> right;
            if (_collisionRegisterType == CollisionRegisterType.RightSide)
            {
                left = _registredItems.Item2;
                right = _registredItems.Item1;
            }
            else
            {
                left = _registredItems.Item1;
                right = _registredItems.Item2;
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
