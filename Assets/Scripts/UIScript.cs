using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    public GameObject animalToDisplay;
    public GameObject currentWorker;
    public Canvas UI;
    public UnityEngine.UI.Button feedButton;
    public UnityEngine.UI.Button playButton;
    public UnityEngine.UI.Button cleanButton;
    public UnityEngine.UI.Button healButton;
    public UnityEngine.UI.Button sleepButton;
    public GameObject StatPanel;
    public GameObject workerPanel;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI workerStatus;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Attention;
    public TextMeshProUGUI Hunger;
    public TextMeshProUGUI Energy;
    public TextMeshProUGUI Cleanliness;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI workerName;
    public UnityEngine.UI.Slider AttBar;
    public UnityEngine.UI.Slider HunBar;
    public UnityEngine.UI.Slider EneBar;
    public UnityEngine.UI.Slider CleanBar;
    public UnityEngine.UI.Slider HPBar;

    public bool animalAssigned;
    public bool workerAssigned;

    void Start()
    {
        StatPanel.SetActive(false);
    }

    public void feedUI()
    {
        currentWorker.GetComponent<WorkerS>().feed(animalToDisplay);
    }

    public void playUI()
    {
        currentWorker.GetComponent<WorkerS>().play(animalToDisplay);
    }

    public void cleanUI()
    {
        currentWorker.GetComponent<WorkerS>().clean(animalToDisplay);
    }

    public void healUI()
    {
        currentWorker.GetComponent<WorkerS>().heal(animalToDisplay);
    }

    public void sleepUI()
    {
        currentWorker.GetComponent<WorkerS>().putToSleep(animalToDisplay);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (animalAssigned == true)
        {
            displayAnimalStats();
            StatPanel.SetActive(true);
        } else
        {
            StatPanel.SetActive(false);
        }

        if (workerAssigned == true)
        {
            workerPanel.SetActive(true);
            workerName.text = currentWorker.name;
        } else
        {
            workerPanel.SetActive(false);
        }

        timerDisplaying();
    }

    public void timerDisplaying()
    {
        int hours = (int)(Time.time/60);
        int minutes = (int)(Time.time%60);

        if (minutes >= 0 && minutes <= 30)
        {
            workerStatus.text = "Workers Available";
        } else if (minutes > 30 && minutes <= 60)
        {
            workerStatus.text = "Workers Unavailable";
        }

        Timer.text = "Time: " + string.Format("{0:00} : {1:00}", hours, minutes);
    }

    public void displayAnimalStats()
    {
        Name.text = "Name: " + animalToDisplay.GetComponent<AnimalS>().animal.animalName;
        Description.text = "Description: " + animalToDisplay.GetComponent<AnimalS>().animal.description;
        Attention.text = "Attention: " + animalToDisplay.GetComponent<AnimalS>().animal.attention.ToString("F0");
        Hunger.text = "Hunger: " + animalToDisplay.GetComponent<AnimalS>().animal.hunger.ToString("F0");
        Energy.text = "Energy: " + animalToDisplay.GetComponent<AnimalS>().animal.energy.ToString("F0");
        Cleanliness.text = "Cleanliness: " + animalToDisplay.GetComponent<AnimalS>().animal.cleanliness.ToString("F0");
        Health.text = "Health: " + animalToDisplay.GetComponent<AnimalS>().animal.health.ToString("F0");

        AttBar.maxValue = animalToDisplay.GetComponent<AnimalS>().animal.attentionMax;
        HunBar.maxValue = animalToDisplay.GetComponent<AnimalS>().animal.hungerMax;
        EneBar.maxValue = animalToDisplay.GetComponent<AnimalS>().animal.energyMax;
        CleanBar.maxValue = animalToDisplay.GetComponent<AnimalS>().animal.cleanlinessMax;
        HPBar.maxValue = animalToDisplay.GetComponent<AnimalS>().animal.healthMax;

        AttBar.value = animalToDisplay.GetComponent<AnimalS>().animal.attention;
        HunBar.value = animalToDisplay.GetComponent<AnimalS>().animal.hunger;
        EneBar.value = animalToDisplay.GetComponent<AnimalS>().animal.energy;
        CleanBar.value = animalToDisplay.GetComponent<AnimalS>().animal.cleanliness;
        HPBar.value = animalToDisplay.GetComponent<AnimalS>().animal.health;
    }
}
