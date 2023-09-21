using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterAttributInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ICharacterAttributes>().To<CharacterAttributes>().AsSingle();
    }
}
