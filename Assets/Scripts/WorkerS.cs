using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkerS : MonoBehaviour
{
    public WorkerSO worker;
    public Canvas ui;
    public TextMeshProUGUI workerStatus;
    public TextMeshProUGUI feedback;

    public Vector3 startPos;
    public Vector3 targetPos;
    private Vector2 size;
    public Vector3 offset = new Vector3 (0, 3, 0);
    public float moveSpeed = 1f;
    public bool clicked = false;
    public bool active = true;

    public void Start()
    {
        size = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        startPos = transform.position;
    }

    public void Update()
    {
        if (workerStatus.text == "Workers Available")
        {
            active = true;
        } else if (workerStatus.text == "Workers Unavailable")
        {
            active = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((mouse.x >= transform.position.x && mouse.x < transform.position.x + size.x ||
                mouse.x <= transform.position.x && mouse.x > transform.position.x - size.x) &&
                (mouse.y >= transform.position.y && mouse.y < transform.position.y + size.y ||
                mouse.y <= transform.position.y && mouse.y > transform.position.y - size.y))
            {
                if (clicked == false && active == true)
                {
                    clicked = true;
                    ui.GetComponent<UIScript>().currentWorker = this.gameObject;
                    ui.GetComponent<UIScript>().workerAssigned = true;

                }
                else if (clicked == true && active == true)
                {
                    clicked = false;
                    ui.GetComponent<UIScript>().currentWorker = null;
                    ui.GetComponent<UIScript>().workerAssigned = false;
                } else
                {
                    ui.GetComponent<UIScript>().workerAssigned = false;
                }
            }

        }
    }

    public void feed(GameObject animalTendingTo)
    {
        transform.position = animalTendingTo.transform.position + offset;

        feedback.text = "Last action:\n" + worker.pseudonym + " has fed " + animalTendingTo.name + " until their energy or hunger was full";

        Debug.Log(worker.pseudonym);
        Debug.Log("Has Started Feeding");
        Debug.Log(animalTendingTo.name);

        while (animalTendingTo.GetComponent<AnimalS>().animal.hunger < animalTendingTo.GetComponent<AnimalS>().animal.hungerMax
                && animalTendingTo.GetComponent<AnimalS>().animal.energy < animalTendingTo.GetComponent<AnimalS>().animal.energyMax)
        {
            animalTendingTo.GetComponent<AnimalS>().workerTending = true;
            animalTendingTo.GetComponent<AnimalS>().animal.hunger += worker.feedRate * Time.deltaTime;
            animalTendingTo.GetComponent<AnimalS>().animal.energy += worker.feedRate * Time.deltaTime;
        }

        Debug.Log(worker.pseudonym);
        Debug.Log("Has Stopped Feeding");
        Debug.Log(animalTendingTo.name);
        animalTendingTo.GetComponent<AnimalS>().workerTending = false;
    }

    public void play(GameObject animalTendingTo)
    {
        transform.position = animalTendingTo.transform.position + offset;

        feedback.text = "Last action:\n" + worker.pseudonym + " has played with " + animalTendingTo.name + " until their energy ran out or their attention was full";

        Debug.Log(worker.pseudonym);
        Debug.Log("Has Started Playing With");
        Debug.Log(animalTendingTo.name);

        while (animalTendingTo.GetComponent<AnimalS>().animal.attention < animalTendingTo.GetComponent<AnimalS>().animal.attentionMax 
                && animalTendingTo.GetComponent<AnimalS>().animal.energy > 0)
        {
            animalTendingTo.GetComponent<AnimalS>().workerTending = true;
            animalTendingTo.GetComponent<AnimalS>().animal.attention += worker.playRate * Time.deltaTime;
            animalTendingTo.GetComponent<AnimalS>().animal.energy -= worker.playRate * Time.deltaTime;
        }

        Debug.Log(worker.pseudonym);
        Debug.Log("Has stopped Playing With");
        Debug.Log(animalTendingTo.name);
        animalTendingTo.GetComponent<AnimalS>().workerTending = false;
    }

    public void clean(GameObject animalTendingTo)
    {
        transform.position = animalTendingTo.transform.position + offset;

        feedback.text = "Last action:\n" + worker.pseudonym + " has cleaned " + animalTendingTo.name + " until their cleanliness was full";

        Debug.Log(worker.pseudonym);
        Debug.Log("Has Started Cleaning");
        Debug.Log(animalTendingTo.name);

        while (animalTendingTo.GetComponent<AnimalS>().animal.cleanliness < animalTendingTo.GetComponent<AnimalS>().animal.cleanlinessMax)
        {
            animalTendingTo.GetComponent<AnimalS>().workerTending = true;
            animalTendingTo.GetComponent<AnimalS>().animal.cleanliness += worker.cleanRate * Time.deltaTime;
        }

        Debug.Log(worker.pseudonym);
        Debug.Log("Has Stopped Cleaning");
        Debug.Log(animalTendingTo.name);
        animalTendingTo.GetComponent<AnimalS>().workerTending = false;

    }

    public void heal(GameObject animalTendingTo)
    {
        transform.position = animalTendingTo.transform.position + offset;

        feedback.text = "Last action:\n" + worker.pseudonym + " has healed " + animalTendingTo.name + " until their health was full";

        Debug.Log(worker.pseudonym);
        Debug.Log("Has Started Healing");
        Debug.Log(animalTendingTo.name);

        while (animalTendingTo.GetComponent<AnimalS>().animal.health < animalTendingTo.GetComponent<AnimalS>().animal.healthMax)
        {
            animalTendingTo.GetComponent<AnimalS>().workerTending = true;
            animalTendingTo.GetComponent<AnimalS>().animal.health += worker.healRate * Time.deltaTime;
        }

        Debug.Log(worker.pseudonym);
        Debug.Log("Has Started Healing");
        Debug.Log(animalTendingTo.name);
        animalTendingTo.GetComponent<AnimalS>().workerTending = false;
    }

    public void putToSleep(GameObject animalTendingTo)
    {
        feedback.text = "Last action:\n" + worker.pseudonym + " has put " + animalTendingTo.name + " to sleep until their energy was full";
        transform.position = animalTendingTo.transform.position + offset;
        animalTendingTo.GetComponent<AnimalS>().sleeping = true;
    }
}
