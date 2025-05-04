using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_spaceInvaders.GameObjects;

namespace _4_spaceInvaders.GameObjectFactories
{
    internal abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }
        
        public GameObjectFactory(GameSettings gameSettings) 
        { 
            GameSettings = gameSettings;
        }

        public abstract GameObject GetGameObject(GameObjectPlace gameObjectPlace);
    }
}
