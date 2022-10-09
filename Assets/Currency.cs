using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    private float nextIncreaseTime = 0.0f;
    public float period;

    public int coins;

    GameObject coinUI;
    // Start is called before the first frame update
    void Start()
    {
        coins = 150;
        period = 5.0f;
        coinUI = GameObject.Find("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        coinUI.GetComponent<Text>().text = "Coins: " + coins.ToString();
        if (Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + period;
            coins = coins + 10;
        }
    }
}
