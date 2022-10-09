using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2UpgradeSword : MonoBehaviour
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
        spawnButton = GameObject.Find("Player2-SpawnSword");
        multiplier = 2;
    }

    void Update()
    {
        count = spawnButton.GetComponent<Player2SpawnSword>().count;
    }

    public void UpgradeObject()
    {
        /*prefabObject.GetComponent<CubeSwordPlayer2>().GetUpgrade(multiplier);*/ //prefabi degistirmek yerine spawna upgradeli deger gecirilebilir

        spawnButton.GetComponent<Player2SpawnSword>().modifier = spawnButton.GetComponent<Player2SpawnSword>().modifier * multiplier;
        for (int i = 1; i < count; i++)
        {
            cloneObject = GameObject.Find("CubeSwordPlayer2-" + i);

            cloneObject.GetComponent<CubeSwordPlayer2>().GetUpgrade(multiplier);
        }
    }
}
