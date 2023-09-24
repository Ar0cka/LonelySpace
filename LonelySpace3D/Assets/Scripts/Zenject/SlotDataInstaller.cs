using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class SlotDataInstaller :MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISlotSaved>().To<SlotSaved>().AsSingle();
    }
}
