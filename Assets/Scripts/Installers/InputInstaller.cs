using Input;
using Zenject;

namespace Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
#if UNITY_EDITOR
            Container.Bind<IInputHandler>().To<KeyboardInput>().AsSingle();
#endif
                //todo add android input
        }
    }
}