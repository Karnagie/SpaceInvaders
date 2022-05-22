using UI.TestEssence;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class RemainderInstaller : MonoInstaller
    {
        [SerializeField] private Remainder _remainder;
        
        public override void InstallBindings()
        {
            Container.Bind<Remainder>().FromInstance(_remainder).AsSingle();
        }
    }
}