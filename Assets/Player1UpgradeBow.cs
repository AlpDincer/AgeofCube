using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1UpgradeBow : MonoBehaviour
{
    public GameObject spawnButton;

    //public GameObject prefabObject;

    public GameObject cloneObject;

    public GameObject coinObject;


    public int count;
    public int maxhealth;
    public int health;
    public int damage;
    public int multiplier;
    public int cost;

    private int coins;

    void Start()
    {
        spawnButton = GameObject.Find("Player1-SpawnBow");
        multiplier = 2;
        cost = 750;

        coinObject = GameObject.Find("Coins");
    }

    void Update()
    {
        count = spawnButton.GetComponent<Player1SpawnBow>().count;
        coins = coinObject.GetComponent<Currency>().coins;
    }

    public void UpgradeObject()
    {
        /*prefabObject.GetComponent<CubeBowPlayer1>().GetUpgrade(multiplier);*/ //prefabi degistirmek yerine spawna upgradeli deger gecirilebilir
        if (coins >= cost)
        {
            spawnButton.GetComponent<Player1SpawnBow>().modifier = spawnButton.GetComponent<Player1SpawnBow>().modifier * multiplier;
            for (int i = 1; i < count; i++)
            {
                cloneObject = GameObject.Find("CubeBowPlayer1-" + i);

                cloneObject.GetComponent<CubeBowPlayer1>().GetUpgrade(multiplier);
            }

            coinObject.GetComponent<Currency>().coins = coinObject.GetComponent<Currency>().coins - cost;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
