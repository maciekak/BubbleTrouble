using SFML.System;

namespace GameEngine.Interfaces
{
    public interface ICanCollide : IGameObject
    {
        Vector2i Position { get; set; }
        Vector2i Size { get; set; }
        void WasCollision(IGameObject gameObject);
    }
}
