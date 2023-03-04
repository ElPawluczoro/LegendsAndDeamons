using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Area3HeroScript : MonoBehaviour
{
    public Unit activeHero;

   /* private void Awake()
    {
        activeHero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Unit>();
        LoadHero();
    }*/

    private void OnEnable()
    {
        activeHero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Unit>();
        LoadHero();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject heroPortriat;
    public TextMeshProUGUI heroName;
    public TextMeshProUGUI stamina;
    public TextMeshProUGUI strenght;
    public TextMeshProUGUI agility;
    public TextMeshProUGUI inteligence;
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;

    public void LoadHero()
    {
        heroName.text = activeHero.stats.name;
        stamina.text = activeHero.stats.stamina.ToString();
        strenght.text = activeHero.stats.strenght.ToString();
        agility.text = activeHero.stats.agility.ToString();
        inteligence.text = activeHero.stats.inteligence.ToString();
        health.text = activeHero.stats.healthPoints.ToString() + "/" + activeHero.stats.maxHealthPoints.ToString();
        damage.text = activeHero.stats.minDamage.ToString() + " - " + activeHero.stats.maxDamage.ToString();

        //heroPortriat.GetComponent<Image>().sprite = activeHero.GetComponent<Image>().sprite;
    }


}
