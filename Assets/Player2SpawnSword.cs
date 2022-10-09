using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2SpawnSword : MonoBehaviour
{
    public GameObject sampleObject;

    public int count;
    public int modifier;

    void Start()

    {
        modifier = 1;
        count = 1;
    }

    public void AddObject()
    {
        GameObject tmpObj = Instantiate(sampleObject);

        tmpObj.name = "CubeSwordPlayer2-" + count.ToString();

        tmpObj.GetComponent<CubeSwordPlayer2>().count = count;

        tmpObj.transform.GetChild(1).gameObject.name = "CubeSwordPlayer2HealthCanvas" + count.ToString();

        tmpObj.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.name = "CubeSwordPlayer2HealthBar" + count.ToString();

        tmpObj.GetComponent<CubeSwordPlayer2>().maxhealth = tmpObj.GetComponent<CubeSwordPlayer2>().maxhealth * modifier;

        tmpObj.GetComponent<CubeSwordPlayer2>().health = tmpObj.GetComponent<CubeSwordPlayer2>().health * modifier;

        tmpObj.GetComponent<CubeSwordPlayer2>().damage = tmpObj.GetComponent<CubeSwordPlayer2>().damage * modifier;

        tmpObj.transform.position = new Vector3(0, 50, 1950);

        count++;
    }
}