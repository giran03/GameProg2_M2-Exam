using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    public Mage()
    {
        Initialize();
    }
    
    public override void Initialize()
    {
        _health = 100;
        _mana = 130;
        _defense = 70;
        _speed = 105;
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
