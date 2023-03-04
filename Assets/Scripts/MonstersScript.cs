using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MonstersScript : MonoBehaviour
{
    System.Random random = new();

    public TMP_Text heroText;
    public TMP_Text monsterText;



    private void Awake()
    {
        
    }
    public void Fight(string monsterString)
    {
        Unit h = GameObject.FindGameObjectWithTag("Hero").GetComponent<Unit>();
        Monster m = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
        foreach (var monster in GameObject.FindGameObjectsWithTag("Monster"))
        {
            if (monster.GetComponent<Monster>().name == monsterString)
            {
                m = monster.GetComponent<Monster>();
                break;
            }
        }
        heroText.text = "";
        monsterText.text = "";
        while (h.IsAlive() && m.IsAlive())
        {
            int heroDamage = random.Next(h.stats.minDamage, h.stats.maxDamage);
            int monsterDamage = random.Next(m.minDamage, m.maxDamage);
            m.GetDamage(heroDamage);
            heroText.text +=  h.stats.name +" deals " + heroDamage + " damage\n";
            monsterText.text += m.healthPoints + "/" + m.maxHealthPoints + "\n";
            h.GetDamage(monsterDamage);
            monsterText.text += m.name + "deals " + monsterDamage + " damage\n";
            heroText.text += h.stats.healthPoints + "/" + h.stats.maxHealthPoints + "\n";

            if (!m.IsAlive())
            {
                monsterText.text += "Dead";
            }

            if (!h.IsAlive())
            {
                heroText.text += "You got injured! Visit hospital";
            }

        }

        m.healthPoints = m.maxHealthPoints;
    }
}
