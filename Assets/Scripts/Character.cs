using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract void Initialize();

    protected int _health;
    protected int _mana;
    protected int _defense;
    protected float _speed;

    protected abstract void Attack();
    protected abstract void Heal();
    protected abstract void Dash();
    protected abstract void Move();
}
