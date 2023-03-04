using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Serializable]
    public struct PlayerStats
    {
        public string name;
        public int stamina;
        public int strenght;
        public int agility;
        public int inteligence;
        public int maxHealthPoints;
        public int healthPoints;
        public int minDamage;
        public int maxDamage;
    }

    public PlayerStats stats;

    public Unit(string name)
    {
        stats.name = name;
        stats.stamina = 5;
        stats.strenght = 3;
        stats.agility = 3;
        stats.inteligence = 3;
        stats.maxHealthPoints = stats.stamina * 10;
        stats.healthPoints = stats.maxHealthPoints;
        SetDamage();
    }

    public void SetDamage()
    {
        stats.minDamage = (int)(stats.strenght * 1.5f) + (int)(stats.agility * 0.5f);
        stats.maxDamage = (int)(stats.strenght * 2) + (int)(stats.agility * 0.75f);
    }

    public bool IsAlive()
    {
        if (stats.healthPoints > 0) return true;
        else return false;
    }

    public void GetDamage(int damage)
    {
        stats.healthPoints -= damage;
    }


    
}
