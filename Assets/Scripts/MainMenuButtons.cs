using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject creteHeroPanel;
    public GameObject loadHeroPanel;
    public GameObject loadHeroHolder;
    public GameObject gameCanvas;
    public GameObject mainMenuCanvas;
    public TMP_InputField heroName;

    public static async Task SaveFile(string[] t, string name)
    {
        await File.WriteAllLinesAsync(name, t);
    }

   
    void Awake()
    {
        creteHeroPanel.SetActive(false);
        gameCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateHeroPanel()
    {
        creteHeroPanel.SetActive(true);
    }
    public void ExitCreateHeroPanel()
    {
        creteHeroPanel.SetActive(false);
    }

    public void CreateHeroButton()
    {
        CreateHero(new Unit(heroName.text).stats, "saves/" + heroName.text + ".save");
    }

    public void LoadHeroButton()
    {
        /*GameObject.FindGameObjectWithTag("Hero").AddComponent<Unit>();

        Unit.PlayerStats heroToLoad = (Unit.PlayerStats)LoadHero("saves/" + "Wojtek" + ".save");
        Unit hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Unit>();*/

        Instantiate(loadHeroHolder);

        DirectoryInfo d = new("saves/");

        foreach (var file in d.GetFiles("*.save"))
        { 
            var heroHolder = Instantiate(loadHeroHolder);
            heroHolder.transform.SetParent(loadHeroPanel.transform);
            //heroHolder.transform.localScale = Vector2.one;
            if (heroHolder.CompareTag("EmptyHeroHolder"))
            {
                heroHolder.AddComponent<Unit>();
                heroHolder.GetComponent<Unit>().stats = (Unit.PlayerStats)LoadHero(file.FullName);
            }
            heroHolder.tag = "FilledGeroHolder";


            //loadHeroHolder.transform.parent = loadHeroPanel.transform;
        }



        /*hero.stats.name = heroToLoad.name;
        hero.stats.stamina = heroToLoad.stamina;
        hero.stats.strenght = heroToLoad.strenght;
        hero.stats.agility = heroToLoad.agility;
        hero.stats.inteligence = heroToLoad.inteligence;*/

        //hero.stats = heroToLoad;

        /*gameCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);*/

        /*string[] lines = System.IO.File.ReadAllLines("saves/Wojtek.save");

        GameObject.FindGameObjectWithTag("Hero").AddComponent<Unit>();
        Unit hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Unit>();
        hero.stats.name = lines[0];
        hero.stats.stamina = Int32.Parse(lines[1]);
        hero.stats.strenght = Int32.Parse(lines[2]);
        hero.stats.agility = Int32.Parse(lines[3]);
        hero.stats.inteligence = Int32.Parse(lines[4]);

        gameCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);*/

    }

    public void CreateHero(Unit.PlayerStats data, string filePath)
    {
        FileStream fileStream;
        BinaryFormatter bf = new();
        if (File.Exists(filePath)) File.Delete(filePath);
        fileStream = File.Create(filePath);
        bf.Serialize(fileStream, data);
        fileStream.Close();

        /*string[] save = { data.stats.name, data.stats.stamina.ToString(), data.stats.strenght.ToString(), data.stats.agility.ToString(), data.stats.inteligence.ToString() };
        SaveFile(save, filePath);*/
    }

    public object LoadHero(string filePath)
    {
        object obj = null;

        FileStream fileStream;
        BinaryFormatter bf = new();
        if (File.Exists(filePath))
        {
            fileStream = File.OpenRead(filePath);
            obj = bf.Deserialize(fileStream);
            fileStream.Close();
        }

        return obj;
    }



}
