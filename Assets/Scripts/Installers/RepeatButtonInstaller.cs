using UI.Buttons;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class RepeatButtonInstaller : MonoInstaller
    {
        [SerializeField] private RepeatButton _button;
        
        public override void InstallBindings()
        {
            Container.Bind<RepeatButton>().FromInstance(_button).AsSingle();
        }
    }
}