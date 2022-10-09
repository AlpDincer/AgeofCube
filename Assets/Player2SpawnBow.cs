using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2SpawnBow : MonoBehaviour
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

        tmpObj.name = "CubeBowPlayer2-" + count.ToString();

        tmpObj.GetComponent<CubeBowPlayer2>().count = count;

        tmpObj.transform.GetChild(1).gameObject.name = "CubeBowPlayer2HealthCanvas" + count.ToString();

        tmpObj.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.name = "CubeBowPlayer2HealthBar" + count.ToString();

        tmpObj.GetComponent<CubeBowPlayer2>().maxhealth = tmpObj.GetComponent<CubeBowPlayer2>().maxhealth * modifier;

        tmpObj.GetComponent<CubeBowPlayer2>().health = tmpObj.GetComponent<CubeBowPlayer2>().health * modifier;

        tmpObj.GetComponent<CubeBowPlayer2>().damage = tmpObj.GetComponent<CubeBowPlayer2>().damage * modifier;

        tmpObj.transform.position = new Vector3(0, 50, 1950);

        count++;
    }
}