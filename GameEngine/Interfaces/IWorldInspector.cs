using System.Collections.Generic;
using GameEngine.Enums;

namespace GameEngine.Interfaces
{
    public interface IWorldInspector
    {
        void Inspect();
        void AddToRegister(string key, IGameObject gameObject, RegisterSide side);
        void AddRegister(string key, 
            IList<IGameObject> left, 
            IList<IGameObject> right,
            CollisionRegisterType registerType, 
            CollisionCheckingEnd checkingEnd);

        void AddObjectToUpdate(IGameObject gameObject);
        bool AddObjectWithKeyToUpdate(string key, IGameObject gameObject);
        void RemoveObjectFromAllRegisters(IGameObject gameObject);
        void RemoveRegister(string key);
        void RemoveObjectFromAllRegisterBySide(IGameObject gameObject, RegisterSide side);
        void RemoveObjectFromRegisterBySide(string key, IGameObject gameObject, RegisterSide side);
    }
}
