using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1SpawnBow : MonoBehaviour
{
    public GameObject sampleObject;
    public GameObject coinObject;

    public int count;
    public int modifier; //to spawn soldiers with stat upgrade
    public bool multishotUpgrade; // to spawn soldiers with multishot upgrade
    private int coins;
    public int cost;

    void Start()

    {
        modifier = 1;
        count = 1;
        multishotUpgrade = false;
        cost = 150;

        coinObject = GameObject.Find("Coins");
    }

    void Update()
    {
        coins = coinObject.GetComponent<Currency>().coins;
    }

    public void AddObject()
    {
        if (coins >= cost)
        {
            coinObject.GetComponent<Currency>().coins = coinObject.GetComponent<Currency>().coins - cost;

            GameObject tmpObj = Instantiate(sampleObject);

            tmpObj.name = "CubeBowPlayer1-" + count.ToString();

            tmpObj.GetComponent<CubeBowPlayer1>().count = count;

            tmpObj.transform.GetChild(1).gameObject.name = "CubeBowPlayer1HealthCanvas" + count.ToString();

            tmpObj.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.name = "CubeBowPlayer1HealthBar" + count.ToString();

            tmpObj.GetComponent<CubeBowPlayer1>().maxhealth = tmpObj.GetComponent<CubeBowPlayer1>().maxhealth * modifier;

            tmpObj.GetComponent<CubeBowPlayer1>().health = tmpObj.GetComponent<CubeBowPlayer1>().health * modifier;

            tmpObj.GetComponent<CubeBowPlayer1>().damage = tmpObj.GetComponent<CubeBowPlayer1>().damage * modifier;

            if (multishotUpgrade == true) //if its already bought spawn bows with multishot
            { GameObject wut = GameObject.Find("CubeBowPlayer1-" + count.ToString()); wut.GetComponent<CubeBowPlayer1>().GetMultishot(); }

            tmpObj.transform.position = new Vector3(0, 50, 50);

            count++;

            StartCoroutine(ButtonDelay()); // add slight delay so that troops are not on top of each other
        }

        else { Debug.Log("You don't have enough coins!!!"); }
    }

    public IEnumerator ButtonDelay()
    {
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(1.0f);
        gameObject.GetComponent<Button>().interactable = true;
    }
}