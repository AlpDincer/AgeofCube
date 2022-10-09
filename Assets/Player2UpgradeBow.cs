using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2UpgradeBow : MonoBehaviour
{
    public GameObject spawnButton;

    //public GameObject prefabObject;

    public GameObject cloneObject;


    public int count;
    public int maxhealth;
    public int health;
    public int damage;
    public int multiplier;

    void Start()
    {
        spawnButton = GameObject.Find("Player2-SpawnBow");
        multiplier = 2;
    }

    void Update()
    {
        count = spawnButton.GetComponent<Player2SpawnBow>().count;
    }

    public void UpgradeObject()
    {
        /*prefabObject.GetComponent<CubeBowPlayer2>().GetUpgrade(multiplier);*/ //prefabi degistirmek yerine spawna upgradeli deger gecirilebilir

        spawnButton.GetComponent<Player2SpawnBow>().modifier = spawnButton.GetComponent<Player2SpawnBow>().modifier * multiplier;
        for (int i = 1; i < count; i++)
        {
            cloneObject = GameObject.Find("CubeBowPlayer2-" + i);

            cloneObject.GetComponent<CubeBowPlayer2>().GetUpgrade(multiplier);
        }
    }
}
