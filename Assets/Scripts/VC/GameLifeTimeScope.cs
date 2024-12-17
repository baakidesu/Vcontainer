using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MessageService>(Lifetime.Singleton);
        //builder.Register<MessagePrinter>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<GameInjector>().AsSelf();
        //builder.RegisterComponentInHierarchy<PrefabInstantiator>().AsSelf();
        builder.RegisterComponentInHierarchy<PrefabFactory>().AsSelf();
        builder.RegisterComponentInHierarchy<PrefabFactory>().As<IPrefabFactory>();
        builder.RegisterComponentInHierarchy<PoolFactory>().As<IPoolFactory>();
        
    }
}