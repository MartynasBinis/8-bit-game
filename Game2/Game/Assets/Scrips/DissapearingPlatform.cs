using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingPlatform : MonoBehaviour
{
    public float timeToToggleplatform = 2;
    public float currenTime = 0;
    public bool enable = true;
    // Start is called before the first frame update
    void Start()
    {
        enable = true;
    }

    // Update is called once per frame
    void Update()
    {
        currenTime += Time.deltaTime;
        if (currenTime >= timeToToggleplatform)
        {
            currenTime = 0;
            TogglePlatform();
        }
    }
        void TogglePlatform()
        {
            enable = !enable;
            foreach (Transform child in gameObject.transform)
            {
                if (child.tag != "Player")
                {
                    child.gameObject.SetActive(enable);
                }
            }
        }
    
}
