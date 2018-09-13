using System;
using System.Collections.Generic;
using System.Linq;
using GameEngine.Enums;
using GameEngine.Exceptions;
using GameEngine.Interfaces;

namespace GameEngine
{
    public class WorldInspector : IWorldInspector
    {
        private readonly IDictionary<string, CollisionRegister> _collisionRegisters;
        private readonly IDictionary<string, IList<IGameObject>> _gameObjectsToUpdate;

        public WorldInspector()
        {
            _collisionRegisters = new Dictionary<string, CollisionRegister>();
            _gameObjectsToUpdate = new Dictionary<string, IList<IGameObject>>();
        }

        public void Inspect()
        {
            
            //Move everything
            //Collide everything
            //
            throw new System.NotImplementedException();
        }

        public void AddObjectToUpdate(IGameObject gameObject)
        {
            CheckObjectForNull(gameObject);

            if (_gameObjectsToUpdate.Values.Any(d => d.Contains(gameObject)))
                throw new GameObjectAlreadyExistsInRegisterException();

            _gameObjectsToUpdate[string.Empty].Add(gameObject);
        }

        public bool AddObjectWithKeyToUpdate(string key, IGameObject gameObject)
        {
            CheckObjectForNull(gameObject);

            if (_gameObjectsToUpdate.Values.Any(d => d.Contains(gameObject)))
                throw new GameObjectAlreadyExistsInRegisterException();
            if (!_gameObjectsToUpdate.ContainsKey(key))
            {
                _gameObjectsToUpdate.Add(key, new List<IGameObject> {gameObject});
                return true;
            }

            _gameObjectsToUpdate[key].Add(gameObject);
            return false;
        }

        public void AddToRegister(string key, IGameObject gameObject, RegisterSide side)
        {
            CheckObjectForNull(gameObject);

            var register = _collisionRegisters[key];
            if (side == RegisterSide.Left)
            {
                if(register.RegistredItems.Item1.Contains(gameObject))
                    throw new GameObjectAlreadyExistsInRegisterException();

                register.RegistredItems.Item1.Add(gameObject);
            }
            else
            {
                if (register.RegistredItems.Item2.Contains(gameObject))
                    throw new GameObjectAlreadyExistsInRegisterException();

                register.RegistredItems.Item2.Add(gameObject);
            }
        }

        public void AddRegister(string key, 
            IList<IGameObject> left, 
            IList<IGameObject> right, 
            CollisionRegisterType registerType,
            CollisionCheckingEnd checkingEnd)
        {
            if (_collisionRegisters.ContainsKey(key))
                throw new KeyAlreadyExistsInRegisterException();
            if(left == null || right == null)
                throw new NullReferenceException();

            var register = new CollisionRegister(left, right, registerType, checkingEnd);
            _collisionRegisters.Add(key, register);
        }

        public void RemoveObjectFromAllRegisters(IGameObject gameObject)
        {
            CheckObjectForNull(gameObject);

            foreach (var register in _collisionRegisters.Values)
            {
                register.RegistredItems.Item1.Remove(gameObject);
                register.RegistredItems.Item2.Remove(gameObject);
            }
        }

        public void RemoveRegister(string key)
        {
            if (!_collisionRegisters.ContainsKey(key))
                throw new KeyNotFoundInRegisterException();

            _collisionRegisters.Remove(key);
        }

        public void RemoveObjectFromAllRegisterBySide(IGameObject gameObject, RegisterSide side)
        {
            CheckObjectForNull(gameObject);

            foreach (var register in _collisionRegisters.Values)
            {
                if (side == RegisterSide.Left)
                {
                    register.RegistredItems.Item1.Remove(gameObject);
                }
                else
                {
                    register.RegistredItems.Item2.Remove(gameObject);
                }
            }
        }

        public void RemoveObjectFromRegisterBySide(string key, IGameObject gameObject, RegisterSide side)
        {
            CheckObjectForNull(gameObject);

            if (!_collisionRegisters.ContainsKey(key))
                throw new KeyNotFoundInRegisterException();

            var register = _collisionRegisters[key];

            if (side == RegisterSide.Left)
            {
                register.RegistredItems.Item1.Remove(gameObject);
            }
            else
            {
                register.RegistredItems.Item2.Remove(gameObject);
            }
        }

        private void CheckObjectForNull(IGameObject gameObject)
        {
            if (gameObject == null)
                throw new NullReferenceException();
        }
    }
}
