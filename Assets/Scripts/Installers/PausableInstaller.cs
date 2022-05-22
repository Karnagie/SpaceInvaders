using System.Collections.Generic;
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
            List<IPausable> pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>().ToList();

            Container.Bind<List<IPausable>>().FromInstance(pausables).AsSingle();
        }
    }
}