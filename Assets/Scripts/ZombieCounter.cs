using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKill() {
        CoinText.Coin += 1;
        PlayerPrefs.SetInt("Coins", CoinText.Coin);
    }
}
