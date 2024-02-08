using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    int health;
    int mana;
    int defense;
    float speed;
    static (int,int,int,float) charStats;

    public Mage(int _health, int _mana, int _defense, float _speed) : base(_health, _mana, _defense, _speed)
    {
        this.health = _health;
        this.mana = _mana;
        this.defense = _defense;
        this.speed = _speed;
    }

    public static Mage Create(GameObject target, int _health, int _mana, int _defense, float _speed)
    {
        Mage mage = target.AddComponent<Mage>();
        mage.health = _health;
        mage.mana = _mana;
        mage.defense = _defense;
        mage.speed = _speed;
        charStats = (_health,_mana,_defense,_speed);
        return mage;
    }

    public static (int,int,int,float) GetVal()
    {
        return charStats;
    }

    public int Health { get { return health; } set { health = value; } }
    public int Mana { get { return mana; } set { mana = value; } }
    public int Defense { get { return defense; } set { defense = value; } }
    public float Speed { get { return speed; } set { speed = value; } }

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
