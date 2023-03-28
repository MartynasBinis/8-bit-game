using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectCoinsToContinue : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(SC_2DCoin.totalCoins==5){
            Load();
        }
    }
    void Load(){
        SC_2DCoin.totalCoins=0;
        SceneManager.LoadScene(sceneName);
    }
}
