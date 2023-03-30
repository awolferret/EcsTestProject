using Leopotam.Ecs;
using UnityEngine;

public class AnimationSystem : IEcsRunSystem
{
    EcsFilter<AnimationComponent, MovableComponent, DirectionComponent, AttackComponent> AnimatedFilter = null;

    public void Run()
    {
        foreach (var item in AnimatedFilter)
        {
            var animatedCharacter = AnimatedFilter.Get1(item);
            var movableCharacter = AnimatedFilter.Get2(item);
            var directionalComponent = AnimatedFilter.Get3(item);
            var attackComponent = AnimatedFilter.Get4(item);
            ref var view = ref animatedCharacter.View;

            ChooseMovementAnimationToPlay(movableCharacter, animatedCharacter, attackComponent);
            PlayAttackAnimation(attackComponent, animatedCharacter);
            ChooseDirection(directionalComponent, view);
        }
    }

    private void ChooseDirection(DirectionComponent directionalComponent, Transform view)
    {
        Quaternion currentQuaternion = view.rotation;

        if (directionalComponent.Direction.y < 0)
        {
            currentQuaternion = new Quaternion(0, 180, 0, 0);
        }
        else if (directionalComponent.Direction.y > 0)
        {
            currentQuaternion = new Quaternion(0, 0, 0, 0);
        }

        view.rotation = currentQuaternion;
    }

    private void ChooseMovementAnimationToPlay(MovableComponent movableCharacter, AnimationComponent animatedCharacter, AttackComponent attackComponent)
    {
        if (movableCharacter.IsMoving && !attackComponent.IsAttacking)
        {
            animatedCharacter.Animator.Play("Walk");
        }
        else if (!movableCharacter.IsMoving && !attackComponent.IsAttacking)
        {
            animatedCharacter.Animator.Play("Idle");
        }
    }

    private void PlayAttackAnimation(AttackComponent attackComponent, AnimationComponent animatedCharacter)
    {
        if (attackComponent.IsAttacking)
        {
            animatedCharacter.Animator.Play("Attack");
        }
    }
}
