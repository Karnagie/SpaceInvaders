using AliveObjects.EnemyEssence;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DefaultShipFactoryInstaller : MonoInstaller
    {
        [SerializeField] private DefaultShip _ship;
        
        public override void InstallBindings()
        {
            Container.BindFactory<DefaultShip, DefaultShip.Factory>().FromComponentInNewPrefab(_ship).AsSingle();
        }
    }
}