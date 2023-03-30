using System;
using UnityEngine;

[Serializable]
public struct AttackComponent
{
    public Collider2D collider;
    public bool IsAttacking;
}