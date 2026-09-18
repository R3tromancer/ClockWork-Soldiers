using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text playerHealth;
    [SerializeField] AudioClip playerHPLoseFx;

    void Start()
    {
        playerHealth.text = healthPoints.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerHPLoseFx);
        healthPoints = healthPoints - healthDecrease;
        playerHealth.text = healthPoints.ToString();

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            playerHealth.text = "0";

        }
    }
    

}
