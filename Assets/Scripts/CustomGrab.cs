using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrab : MonoBehaviour
{
    public GameObject s_indicator;
    // Update is called once per frame
    void Update()
    {   
        // s_indicator.material.SetColor("_Color", Color.red);

         // enable the followings in VR mode
        // if (OVRInput.Get(OVRInput.Button.One)) {
        //     Debug.Log("pressed!");
        //      s_indicator.GetComponent<Renderer>().enabled = true;
        //     transform.GetComponent<OVRGrabbable>().enabled = true;
        // } else {
        //     Debug.Log("unpressed!");
        //      s_indicator.GetComponent<Renderer>().enabled = false;
        //     transform.GetComponent<OVRGrabbable>().enabled = false;
        //  }
    }
}
