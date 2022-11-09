using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger2 : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int hunger;

    private int currentFeed;

    private void Start()
    {
        slider.maxValue = hunger;
        slider.value = 0;
        slider.fillRect.gameObject.SetActive(false);
    }

    public void FeedAnimal(int amount)
    {
        currentFeed += amount;
        slider.fillRect.gameObject.SetActive(true);
        slider.value = currentFeed;

        if (currentFeed >= hunger)
        {
            Destroy(gameObject);
            PlayerController2.score++;
            Debug.Log("Score: " + PlayerController2.score);
        }
    }
}
