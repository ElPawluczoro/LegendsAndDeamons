using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadHeroScript : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject mainMenuCanvas;
    public void LoadHero()
    {
        Unit hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Unit>();
        hero.stats = this.GetComponent<Unit>().stats;

        gameCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }
}
