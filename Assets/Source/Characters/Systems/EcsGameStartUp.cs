using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public sealed class EcsGameStartUp : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.ConvertScene();
        AddSystems();
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

    private void AddSystems()
    {
        _systems.
            Add(new InputSystem()).
            Add(new MovementSystem()).
            Add(new AnimationSystem());
    }
}
