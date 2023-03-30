using Leopotam.Ecs;

public sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;

    public void Run()
    {
        foreach (var component in _movableFilter)
        {
            ref var modelComponent = ref _movableFilter.Get1(component);
            ref var movableComponent = ref _movableFilter.Get2(component);
            ref var directionalComponent = ref _movableFilter.Get3(component);

            ref var direction = ref directionalComponent.Direction;
            ref var transform = ref modelComponent.Transform;

            ref var characterController = ref movableComponent.Controller;
            ref var speed = ref movableComponent.Speed;

            var rawDirection = (transform.up * direction.x) + (transform.right * direction.y);
            characterController.Move(rawDirection * speed);
            movableComponent.IsMoving = directionalComponent.Direction.sqrMagnitude > 0;
        }
    }
}
