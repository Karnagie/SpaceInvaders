using System.Linq;
using AliveObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PausableInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            IPausable[] pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>().ToArray();

            Container.Bind<IPausable[]>().FromInstance(pausables).AsSingle();
        }
    }
}