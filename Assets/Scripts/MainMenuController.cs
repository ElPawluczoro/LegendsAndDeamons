using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    public GameObject gameCanvas;
    public GameObject creteHeroPanel;
    public GameObject mainMenuCanvas;
    public GameObject heroesPanel;
    public TMP_InputField heroName;

    public TMP_Text hero1;
    public TMP_Text hero2;
    public TMP_Text hero3;

    public TMP_Text playCreateButton1Text;
    public TMP_Text playCreateButton2Text;
    public TMP_Text playCreateButton3Text;

    private string saveFile;

    void Awake()
    {
        UpdateHeroesNames();
        gameCanvas.SetActive(false);
        creteHeroPanel.SetActive(false);

    }

    public void CreateOrPlayButton(string fileName)
    {
        if (File.ReadAllText(fileName) == "")
        {
            CreateNewHero(fileName);
        }
        else
        {
            LoadHero(fileName);
            GameObject.FindGameObjectWithTag("Hero").AddComponent<Unit>();
            Unit hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Unit>();
            Unit.PlayerStats heroToLoad = (Unit.PlayerStats) LoadHero(fileName);
            hero.stats = heroToLoad;
            gameCanvas.SetActive(true);
            mainMenuCanvas.SetActive(false);
        }
    }

    public void DeleteHeroButton(string fileName)
    {
        File.Delete(fileName);
        FileStream fs = File.Create(fileName);
        fs.Close();
        UpdateHeroesNames();
    }

    public void CreateNewHero(string fileName)
    {
        saveFile = fileName;
        creteHeroPanel.SetActive(true);
        heroesPanel.SetActive(false);
    }

    public void CreateHeroButton()
    {
        CreateHero(new Unit(heroName.text).stats, saveFile);
        ExitCreateHeroPanel();
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

    public Unit.PlayerStats LoadHero(string filePath)
    {
        object obj = null;
        Unit.PlayerStats playerStats = new Unit("Sample").stats;

        BinaryFormatter bf = new();
        if (File.Exists(filePath))
        {
            FileStream fileStream;
            fileStream = File.OpenRead(filePath);
            obj = bf.Deserialize(fileStream);
            playerStats = (Unit.PlayerStats)obj;
            fileStream.Close();
        }

        return playerStats;
    }

    public void ExitCreateHeroPanel()
    {
        creteHeroPanel.SetActive(false);
        heroesPanel.SetActive(true);
        heroName.text = "";
        UpdateHeroesNames();
    }

    public void UpdateHeroesNames()
    {
        if (File.ReadAllText("saves/save_1.save") != "")
        {
            hero1.text = LoadHero("saves/save_1.save").name;
            playCreateButton1Text.text = "Play";
        }
        else
        {
            hero1.text = "Empty Hero Slot";
            playCreateButton1Text.text = "Create";
        }
        if (File.ReadAllText("saves/save_2.save") != "")
        {
            hero2.text = LoadHero("saves/save_2.save").name;
            playCreateButton2Text.text = "Play";
        }
        else
        {
            hero2.text = "Empty Hero Slot";
            playCreateButton2Text.text = "Create";
        }
        if (File.ReadAllText("saves/save_3.save") != "")
        {
            hero3.text = LoadHero("saves/save_3.save").name;
            playCreateButton3Text.text = "Play";
        }
        else
        {
            hero3.text = "Empty Hero Slot";
            playCreateButton3Text.text = "Create";
        }
    }
}
