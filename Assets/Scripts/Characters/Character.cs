using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // protected abstract void Initialize();
    protected int _health;
    protected int _mana;
    protected int _defense;
    protected float _speed;
    protected Character(int _health, int _mana, int _defense, float _speed)
    {
        this._health = _health;
        this._mana = _mana;
        this._defense = _defense;
        this._speed = _speed;
    }

    protected abstract void Attack();
    protected abstract void Heal();
    protected abstract void Dash();
    protected abstract void Move();
}
