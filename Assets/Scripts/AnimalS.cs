using UnityEngine;

public class AnimalS : MonoBehaviour
{
    public Canvas ui;
    public AnimalSO animal;
    private Vector2 size;
    public bool clicked = false;
    public bool workerTending = false;
    public bool sleeping = false;

    void Start()
    {
        size = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        animal.hpRate = 0f;
        animal.attention = animal.attentionMax;
        animal.hunger = animal.hungerMax;
        animal.energy = animal.energyMax;
        animal.cleanliness = animal.cleanlinessMax;
        animal.health = animal.healthMax;
    }

    private void Update()
    {
        if (workerTending == false && sleeping == false)
        {
            animal.loseStats();

        } else if (sleeping == true)
        {
            while (animal.energy < animal.energyMax)
            {
                animal.energy += animal.eneRate * Time.deltaTime;
            }
            sleeping = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((mouse.x >= transform.position.x && mouse.x < transform.position.x + size.x ||
                mouse.x <= transform.position.x && mouse.x > transform.position.x - size.x) &&
                (mouse.y >= transform.position.y && mouse.y < transform.position.y + size.y ||
                mouse.y <= transform.position.y && mouse.y > transform.position.y - size.y))
            {
                if (clicked == false) 
                {
                    clicked = true;
                    ui.GetComponent<UIScript>().animalToDisplay = this.gameObject;
                    ui.GetComponent<UIScript>().animalAssigned = true;
                } else if (clicked == true)
                {
                    clicked = false;
                    //ui.GetComponent<UIScript>().animalToDisplay = null;
                    ui.GetComponent<UIScript>().animalAssigned = false;
                }
            }
        }
    }
}
