using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AreaControll : MonoBehaviour
{
    public GameObject leftMenu;
    public GameObject upperMenu;

    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    public GameObject area4;
    public GameObject area5;
    public GameObject area6;
    public GameObject area7;

    public Button area1Button;
    public Button area2Button;
    public Button area3Button;
    public Button area4Button;
    public Button area5Button;
    public Button area6Button;
    public Button area7Button;

    public List<GameObject> areas = new();

    void Awake()
    {
        area1.SetActive(false);
        area2.SetActive(false);
        area3.SetActive(false);
        area4.SetActive(false);
        area5.SetActive(false);
        area6.SetActive(false);
        area7.SetActive(false);

        leftMenu.SetActive(true);
        upperMenu.SetActive(true);

        areas.Add(area1);
        areas.Add(area2);
        areas.Add(area3);
        areas.Add(area4);
        areas.Add(area5);
        areas.Add(area6);
        areas.Add(area7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveArea1()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }
        area1.SetActive(true);
    }
    public void ActiveArea2()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }
        area2.SetActive(true);
    }public void ActiveArea3()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }
        area3.SetActive(true);
    }public void ActiveArea4()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }
        area4.SetActive(true);
    }public void ActiveArea5()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }
        area5.SetActive(true);
    }public void ActiveArea6()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }
        area6.SetActive(true);
    }public void ActiveArea7()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }
        area7.SetActive(true);
    }
}
