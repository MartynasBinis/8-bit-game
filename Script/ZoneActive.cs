using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneActive : MonoBehaviour
{
    public Image image;


    // Update is called once per frame
    void Update()
    {
        if (Movement.hasGravity && Movement.enteredGravityZone)
        {
            image.color = new Color32(255, 255, 255, 100);
        }
        else
            image.color = new Color32(0, 0, 0, 100);
    }
}
