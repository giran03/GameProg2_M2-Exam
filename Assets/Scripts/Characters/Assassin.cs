using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : Character
{
    int health;
    int mana;
    int defense;
    float speed;
    static (int, int, int, float) charStats;

    protected Assassin(int _health, int _mana, int _defense, float _speed) : base(_health, _mana, _defense, _speed)
    {
        this.health = _health;
        this.mana = _mana;
        this.defense = _defense;
        this.speed = _speed;
    }

    public static Assassin Create(GameObject target, int _health, int _mana, int _defense, float _speed)
    {
        Assassin assassin = target.AddComponent<Assassin>();
        assassin.health = _health;
        assassin.mana = _mana;
        assassin.defense = _defense;
        assassin.speed = _speed;
        charStats = (_health, _mana, _defense, _speed);
        return assassin;
    }
    public static (int, int, int, float) GetVal()
    {
        return charStats;
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
