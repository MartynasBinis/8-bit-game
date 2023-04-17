using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectCoinsToContinue : MonoBehaviour
{
    public string sceneName;
    public static int maxCoins = 5;
    public int giveMaxCoins;
    // Start is called before the first frame update
    void Start()
    {
        maxCoins=giveMaxCoins;
    }

    // Update is called once per frame
    void Update()
    {
        if(SC_2DCoin.totalCoins==maxCoins){
            Load();
        }
    }
    void Load(){
        SC_2DCoin.totalCoins=0;
        SceneManager.LoadScene(sceneName);
    }
}
