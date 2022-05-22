using GameEssence;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Game _game;
        
        public override void InstallBindings()
        {
            Container.Bind<Game>().FromInstance(_game).AsSingle();
        }
    }
}