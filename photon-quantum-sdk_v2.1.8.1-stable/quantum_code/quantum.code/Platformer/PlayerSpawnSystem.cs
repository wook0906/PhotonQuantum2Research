using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Platformer
{
    unsafe class PlayerSpawnSystem : SystemSignalsOnly, ISignalOnPlayerDataSet
    {
        public void OnPlayerDataSet(Frame frame, PlayerRef player)
        {
            var data = frame.GetPlayerData(player);

            // resolve the reference to the prototpye.
            var prototype = frame.FindAsset<EntityPrototype>(data.CharacterPrototype.Id);

            // Create a new entity for the player based on the prototype.
            var entity = frame.Create(prototype);

            // Create a PlayerLink component. Initialize it with the player. Add the component to the player entity.
            var playerLink = new PlayerLink()
            {
                Player = player,
            };
            frame.Add(entity, playerLink);

            // Offset the instantiated object in the world, based in its ID.
            if (frame.Unsafe.TryGetPointer<Transform3D>(entity, out var transform))
            {
                transform->Position.X = 0 + player;
            }
        }
    }
}
