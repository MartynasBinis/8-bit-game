using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectCoinsToContinue : MonoBehaviour
{
    public string sceneName;
    public static int maxCoins = 5;
    public int MaxCoinsToCollect;
    public static bool allCoinsCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        maxCoins= MaxCoinsToCollect;
    }

    // Update is called once per frame
    void Update()
    {
        if(SC_2DCoin.totalCoins==maxCoins){
            allCoinsCollected = true;
        }
    }
}
