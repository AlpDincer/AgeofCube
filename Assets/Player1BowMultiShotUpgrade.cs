using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1BowMultiShotUpgrade : MonoBehaviour
{
    public GameObject spawnButton;

    //public GameObject prefabObject;

    public GameObject cloneObject;

    public GameObject coinObject;

    public int count;
    public int cost;

    private int coins;

    void Start()
    {
        spawnButton = GameObject.Find("Player1-SpawnBow");
        cost = 1500;

        coinObject = GameObject.Find("Coins");
    }

    void Update()
    {
        count = spawnButton.GetComponent<Player1SpawnBow>().count;
        coins = coinObject.GetComponent<Currency>().coins;
    }

    public void BuyMultiShot()
    {
        if (coins >= cost)
        {
            spawnButton.GetComponent<Player1SpawnBow>().multishotUpgrade = true; // Doesnt change prefab value

            //prefabObject.GetComponent<CubeBowPlayer1>().GetMultishot(); // Alternative upgrade vis changing prefab value
            for (int i = 1; i < count; i++)
            {
                cloneObject = GameObject.Find("CubeBowPlayer1-" + i);

                cloneObject.GetComponent<CubeBowPlayer1>().GetMultishot();
            }

            coinObject.GetComponent<Currency>().coins = coinObject.GetComponent<Currency>().coins - cost;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
