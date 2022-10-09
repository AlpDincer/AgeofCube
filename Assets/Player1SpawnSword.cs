using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1SpawnSword : MonoBehaviour
{
    public GameObject sampleObject;
    public GameObject coinObject;

    public int count;
    public int modifier;
    private int coins;
    public int cost;

    void Start()

    {
        modifier = 1;
        count = 1;
        cost = 100;

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

            tmpObj.name = "CubeSwordPlayer1-" + count.ToString();

            tmpObj.GetComponent<CubeSwordPlayer1>().count = count;

            tmpObj.transform.GetChild(1).gameObject.name = "CubeSwordPlayer1HealthCanvas" + count.ToString();

            tmpObj.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.name = "CubeSwordPlayer1HealthBar" + count.ToString();

            tmpObj.GetComponent<CubeSwordPlayer1>().maxhealth = tmpObj.GetComponent<CubeSwordPlayer1>().maxhealth * modifier;

            tmpObj.GetComponent<CubeSwordPlayer1>().health = tmpObj.GetComponent<CubeSwordPlayer1>().health * modifier;

            tmpObj.GetComponent<CubeSwordPlayer1>().damage = tmpObj.GetComponent<CubeSwordPlayer1>().damage * modifier;

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