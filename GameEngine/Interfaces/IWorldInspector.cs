using System.Collections.Generic;
using GameEngine.Enums;

namespace GameEngine.Interfaces
{
    public interface IWorldInspector
    {
        void Inspect();
        void AddToRegister(string key, ICanCollide gameObject, RegisterSide side);
        void AddRegister(string key, 
            IList<ICanCollide> left, 
            IList<ICanCollide> right,
            CollisionRegisterType registerType, 
            CollisionCheckingEnd checkingEnd);

        void AddObjectToUpdate(IGameObject gameObject);
        bool AddObjectWithKeyToUpdate(string key, IGameObject gameObject);
        void RemoveObjectFromAllRegisters(ICanCollide gameObject);
        void RemoveRegister(string key);
        void RemoveObjectFromAllRegisterBySide(ICanCollide gameObject, RegisterSide side);
        void RemoveObjectFromRegisterBySide(string key, ICanCollide gameObject, RegisterSide side);
    }
}
