using System;
using UnityEngine;

[Serializable]
public struct MovableComponent
{
    public CharacterController Controller;
    public float Speed;
    public bool IsMoving;
}