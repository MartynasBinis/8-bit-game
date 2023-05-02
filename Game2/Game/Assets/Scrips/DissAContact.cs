using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissAContact : MonoBehaviour
{
    public float timeToToggleplatform = 2;
    public float currenTime = 0;
    public bool enable = true;
    public bool startTimer = false;
    public ColliderDetector Collider;
    // Start is called before the first frame update
    void Start()
    {
        enable = true;
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == false)
        {
            startTimer = Collider.startTimer;
        }
        if (enable == false)
        {
            currenTime += Time.deltaTime;
        }
        if(startTimer == true)
        {
            currenTime += Time.deltaTime;
        }
        if(currenTime >= timeToToggleplatform)
        {
            startTimer = false;
            Collider.startTimer = false;
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
