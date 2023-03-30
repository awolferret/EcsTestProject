using Leopotam.Ecs;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, DirectionComponent, AttackComponent> _actionsFilter = null;

    private float _moveX;
    private float _moveY;
    private bool _IsAttacking = false;
    private float _attackTime = 0.5f;
    private float _time = 0f;

    public void Run()
    {
        SetDirection();
        ReadAttack();

        foreach (var component in _actionsFilter)
        {
            ref var directionComponent = ref _actionsFilter.Get2(component);
            ref var attackComponent = ref _actionsFilter.Get3(component);
            ref var direction = ref directionComponent.Direction;
            attackComponent.IsAttacking = _IsAttacking;
            direction.x = _moveX;
            direction.y = _moveY;
        }

        if (_IsAttacking == true)
        {
            _time += Time.deltaTime;

            if (_time > _attackTime)
            {
                _IsAttacking = false;
                _time = 0;
            }
        }
    }

    private void SetDirection()
    {
        _moveX = Input.GetAxis("Vertical");
        _moveY = Input.GetAxis("Horizontal");
    }

    private void ReadAttack()
    {
        if (_IsAttacking == false && Input.GetMouseButton(0))
        {
            _IsAttacking = true;
        }
    }
}
