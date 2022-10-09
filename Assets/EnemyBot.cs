using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : MonoBehaviour
{
    public GameObject sampleSword;

    public int count;
    public int modifier;

    void Start()

    {
        modifier = 1;
        count = 1;

        AddObject();
        StartCoroutine(SpawnDelay());
    }

    void Update()
    {

    }

    public void AddObject()
    {
        GameObject tmpObj = Instantiate(sampleSword);

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

    public IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(1.0f);

    }
}