using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] Slider hungerSlider;
    [SerializeField] int maxHunger;
    private int currentHunger;
    // private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FeedAnimal(int amount)
    {
        currentHunger += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentHunger;

        if (currentHunger >= maxHunger)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
