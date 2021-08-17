using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjects : MonoBehaviour
{
    public bool isVR;
    int activeCount = 0;
    
    private void Start() {
    // enable the first child on start, disable the rest
    // so we only see the first shadow on start
    for ( int i = 0; i < transform.childCount; i++ ) {
        if (i == 0) {
            transform.GetChild(i).gameObject.SetActive(true);
        } else { 
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
        activeCount = 1;
    }
    private void Update() {
        bool XisPressed = false;
        bool YisPressed = false;
        if (isVR) { 
            // active the next shadow when both buttons pressed

             // enable the followings in VR mode
            // XisPressed = OVRInput.Get(OVRInput.Button.Three); // get() is on all frames
            // YisPressed = OVRInput.GetDown(OVRInput.Button.Four); // getDown() is only on that exact frame
        } else { 
            XisPressed = Input.GetKey("a");
            YisPressed = Input.GetKeyDown("d");
        }
        if (XisPressed && YisPressed && activeCount < transform.childCount) {
            transform.GetChild(activeCount).gameObject.SetActive(true);
            activeCount += 1;
        }
    }
}
