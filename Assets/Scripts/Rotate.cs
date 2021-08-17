using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public bool isVR;
    public float speed = 100.0f;
    void FixedUpdate () //!!! DON'T USE Update() for this get input, rotate thing! If so, it's gonna be stucked, don't know why
    
	{
        float h1 = 0;
        float v1 = 0;
        float originalX = transform.eulerAngles.x;
        float originalY = transform.eulerAngles.y;
        if (isVR) { 
             // enable the followings in VR mode
            // h1 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
            // v1 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
        } else { 
            if (Input.GetKey("up"))
            {
                Debug.Log("here");
                v1 = 1;
            } else if (Input.GetKey("down"))
            {
                v1 = -1;
            } 
            
            if (Input.GetKey("left"))
            {
                h1 = -1;
            } else if  (Input.GetKey("right"))
            {
                h1 = 1;
            }

            if (Input.GetKeyDown("s")){ // snap to the position, should do this to the VR version as well
                transform.eulerAngles = new Vector3((Mathf.Round(transform.eulerAngles.x / 90) * 90), (Mathf.Round(transform.eulerAngles.y / 90) * 90), (Mathf.Round(transform.eulerAngles.z / 90) * 90));
            }
        }
        transform.RotateAround(transform.position, new Vector3(v1,-1 * h1,0), speed * Time.deltaTime);
    }
}
















// the following version is continuous rotating (without angle snapping)
// public class Rotate : MonoBehaviour
// {

//     public bool isVR;
//     public float speed = 100.0f;
//     void FixedUpdate () //!!! DON'T USE Update() for this get input, rotate thing! If so, it's gonna be stucked, don't know why
    
// 	{
//         float h1 = 0;
//         float v1 = 0;
//         float originalX = transform.eulerAngles.x;
//         float originalY = transform.eulerAngles.y;
//         if (isVR) { 
//             h1 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
//             v1 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
//         } else { 
//             if (Input.GetKey("up"))
//             {
//                 v1 = 1;
//             } else if (Input.GetKey("down"))
//             {
//                 v1 = -1;
//             } 
            
//             if (Input.GetKey("left"))
//             {
//                 h1 = -1;
//             } else if  (Input.GetKey("right"))
//             {
//                 h1 = 1;
//             }

//             if (Input.GetKeyDown("s")){ // snap to the position, should do this to the VR version as well
//                 transform.eulerAngles = new Vector3((Mathf.Round(transform.eulerAngles.x / 90) * 90), (Mathf.Round(transform.eulerAngles.y / 90) * 90), (Mathf.Round(transform.eulerAngles.z / 90) * 90));
//             }
//         }
//         transform.RotateAround(transform.position, new Vector3(v1,-1 * h1,0), speed * Time.deltaTime);
//     }
// }




