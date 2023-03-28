using Leopotam.Ecs;
using UnityEngine;


public sealed class EcsGameStartUp : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        if (_systems == null)
            return;

        _systems.Destroy();
        _systems = null;
        _world.Destroy();
        _world = null;
    }
}
