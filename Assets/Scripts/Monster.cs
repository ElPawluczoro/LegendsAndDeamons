using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public TMP_Text monsterInfo;

    public string name;
    public int healthPoints;
    public int maxHealthPoints;
    public int minDamage;
    public int maxDamage;

    public bool IsAlive()
    {
        if (healthPoints > 0) return true;
        else return false;
    }
    public void GetDamage(int damage)
    {
        healthPoints -= damage;
    }

    private void Awake()
    {
        monsterInfo.text = "HP: " + healthPoints + "\n" + "Damage: " + minDamage + " - " + maxDamage;
    }

}
