using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : Character
{
    public Assassin()
    {
        Initialize();
    }
    public override void Initialize()
    {
        _health = 90;
        _mana = 100;
        _defense = 70;
        _speed = 110;
    }

    protected override void Attack()
    {
        Debug.Log("Attack");
    }

    protected override void Heal()
    {
        Debug.Log("Heal");
    }

    protected override void Dash()
    {
        Debug.Log("Dash");
    }

    protected override void Move()
    {
        Debug.Log("Move");
    }
}
