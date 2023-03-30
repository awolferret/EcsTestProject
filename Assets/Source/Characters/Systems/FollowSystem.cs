using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class FollowSystem : IEcsRunSystem
{
    private readonly EcsFilter<FollowComponent, MovableComponent, ModelComponent, EnemyTag> _enemyFollowFilter = null;

    public void Run()
    {
        foreach (var item in _enemyFollowFilter)
        {
            ref var followComponent = ref _enemyFollowFilter.Get1(item);
            ref var movableComponent = ref _enemyFollowFilter.Get2(item);
            ref var modelComponent = ref _enemyFollowFilter.Get3(item);

            ref var characterController = ref movableComponent.Controller;

            if (followComponent.Target)
            {
              var direction = (followComponent.Target.position - modelComponent.Transform.position).normalized;

              characterController.Move(direction * movableComponent.Speed);
            }
        }
    }
}
