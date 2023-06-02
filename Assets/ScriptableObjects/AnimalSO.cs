using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class AnimalSO : ScriptableObject
{
    public string animalName;
    public string description;

    public Sprite appearance;
    public bool losingHP = false;

    public float attentionMax;
    public float attention;
    public float hungerMax;
    public float hunger;
    public float energyMax;
    public float energy;
    public float cleanlinessMax;
    public float cleanliness;
    public float healthMax;
    public float health;

    public float attRate;
    public float hunRate;
    public float eneRate;
    public float cleanRate;
    public float hpRate;

    public void loseStats()
    {
        if (attention >= 0)
        {
            attention -= attRate * Time.deltaTime;
        }

        if (hunger >= 0)
        {
            hunger -= hunRate * Time.deltaTime;
        }

        if (energy >= 0)
        {
            energy -= eneRate * Time.deltaTime;
        }

        if (cleanliness >= 0)
        {
            cleanliness -= cleanRate * Time.deltaTime;
        }

        if (attention <= 0)
        {
            losingHP = true;
            hpRate = attRate / 2;
            if (health >= 0)
            {
                health -= hpRate * Time.deltaTime;
            }
        }
        else if (hunger <= 0)
        {
            losingHP = true;
            hpRate = hunRate / 2;
            if (health >= 0)
            {
                health -= hpRate * Time.deltaTime;
            }

        }
        else if (energy <= 0)
        {
            losingHP = true;
            hpRate = eneRate / 2;
            if (health >= 0)
            {
                health -= hpRate * Time.deltaTime;
            }

        }
        else if (cleanliness <= 0)
        {
            losingHP = true;
            hpRate = cleanRate / 2;
            if (health >= 0)
            {
                health -= hpRate * Time.deltaTime;
            }
        }
    }

    /*public float getAtt()
    { return attention; }

    public float getHun()
    { return hunger; }

    public float getEne()
    { return energy; }

    public float getClean()
    { return cleanliness; }

    public float getHP()
    { return health; }

    public void setAtt(float val)
    { attention = val; }

    public void setHun(float val)
    { hunger = val; }

    public void setEne(float val)
    { energy = val; }

    public void setClean(float val)
    { cleanliness = val; }

    public void setHP(float val)
    { health = val; }*/
}
