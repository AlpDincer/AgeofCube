using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1UpgradeSword : MonoBehaviour
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
        spawnButton = GameObject.Find("Player1-SpawnSword");
        multiplier = 2;
        cost = 500;

        coinObject = GameObject.Find("Coins");
    }

    void Update()
    {
        count = spawnButton.GetComponent<Player1SpawnSword>().count;
        coins = coinObject.GetComponent<Currency>().coins;
    }

    public void UpgradeObject()
    {
        /*prefabObject.GetComponent<CubeSwordPlayer1>().GetUpgrade(multiplier);*/ //prefabi degistirmek yerine spawna upgradeli deger gecirilebilir
        if (coins >= cost)
        {
            spawnButton.GetComponent<Player1SpawnSword>().modifier = spawnButton.GetComponent<Player1SpawnSword>().modifier * multiplier;
            for (int i = 1; i < count; i++)
            {
                cloneObject = GameObject.Find("CubeSwordPlayer1-" + i);

                cloneObject.GetComponent<CubeSwordPlayer1>().GetUpgrade(multiplier);
            }

            coinObject.GetComponent<Currency>().coins = coinObject.GetComponent<Currency>().coins - cost;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
