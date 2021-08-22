using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{
    public static bool isEncoderMode = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) {
            isEncoderMode = true;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        } else if (Input.GetKeyDown("d")) {
            isEncoderMode = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
