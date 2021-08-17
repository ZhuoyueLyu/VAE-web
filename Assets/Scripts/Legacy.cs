// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Rotate : MonoBehaviour
// {
//     // public float xRotationSpeed; // if we increase this, make sure to increase the gap between 260 and 271 to 250 and 271 for example
//     // public float yRotationSpeed;
//     // void FixedUpdate()
//     // {
//     //     float h1 = xRotationSpeed * OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
//     //     float v1 = yRotationSpeed * OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;

//     //     // zhuoyue: originalX is going from 270->360->0->90....and it stops rotating

//     //     // float h1 = xRotationSpeed;
//     //     // float v1 = yRotationSpeed;

//     //     float originalY = transform.eulerAngles.y;
//     //     float originalX = transform.eulerAngles.x;
//     //     float originalZ = transform.eulerAngles.z;

//     //     // Debug.Log("Checkininininin");
//     //     // Debug.Log(originalX);
//     //     // Debug.Log(Mathf.RoundToInt(originalX));
//     //     if ( 260 < Mathf.RoundToInt(originalX) && Mathf.RoundToInt(originalX) <= 271) { // 260 and 100 are just to make sure, it can be 200 and 150 respectively as well.
//     //         transform.eulerAngles = new Vector3(360 - originalX, originalY, originalZ);
//     //         Debug.Log("case 1");
//     //     } else if (100 >  Mathf.RoundToInt(originalX) && Mathf.RoundToInt(originalX) >= 89) {
//     //         transform.eulerAngles = new Vector3(360 - originalX, originalY, originalZ);
//     //         Debug.Log("case 2");
//     //     }

//     //     transform.eulerAngles += new Vector3(v1, h1, 0);
//     //     // transform.localEulerAngles += new Vector3(v1, h1, 0);
//     //     // Debug.Log(transform.eulerAngles);
//     // }



//     public bool isVR;
//     public float speed;

//     // private float h1;
//     // private float v1;

//      float smooth = 5.0f;
//     float tiltAngle = 50.0f;

//     private float direction = 1;
//     void FixedUpdate () //!!! DON'T USE Update() for this get input, rotate thing! If so, it's gonna be stucked, don't know why
    
// 	{
//         float h1 = 0;
//         float v1 = 0;
//         if (isVR) { 
//             h1 = speed * OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
//             v1 = speed * OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
//         } else { 
//             if (Input.GetKey("up"))
//             {
//                 v1 = speed;
//                 // Rotate the cube by converting the angles into a quaternion.
//             Quaternion target = Quaternion.Euler(originalY + tiltAroundY, originalX + tiltAroundX, 0);
//             transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
//             } else if (Input.GetKey("down"))
//             {
//                 v1 = -speed;
//             } else if (Input.GetKey("left"))
//             {
//                 h1 = -speed;
//             } else if  (Input.GetKey("right"))
//             {
//                 h1 = speed;
//             }
//         }

//         float originalY = transform.eulerAngles.y;
//         float originalX = transform.eulerAngles.x;
//         float originalZ = transform.eulerAngles.z;

//         // // if ( originalX + v1 <= 270) { // 260 and 100 are just to make sure, it can be 200 and 150 respectively as well.
//         // //     transform.eulerAngles = new Vector3(360 - (originalX + v1), originalY-h1, originalZ);
//         // //     Debug.Log("case 1");
//         // // } else if (originalX + v1 >= 90) {
//         // //     transform.eulerAngles = new Vector3(360 - (originalX + v1), originalY-h1, originalZ);
//         // //     Debug.Log("case 2");
//         // // }

//         // Debug.Log("Checking rotation");
//         // Debug.Log(originalX);
//         // Debug.Log(originalY);
//         // Debug.Log(originalZ);
//         // // 现在看下来，好像是Z和Y都会变化，在X接近90 270的时候，所以我想去探测Z是否是0或者180，但是好像进不了下面的case，下一步需要单独print这个Z来看看咋回事
//         // Debug.Log("Checking Z by itself");
//         // Debug.Log(Mathf.RoundToInt(originalZ));
//         // if ( 90 <= (originalX + v1) && (originalX + v1) <= 270 && (Mathf.RoundToInt(originalZ) == 0 || Mathf.RoundToInt(originalZ) == 180) ) { // 260 and 100 are just to make sure, it can be 200 and 150 respectively as well.
//         //     // transform.eulerAngles = new Vector3(360 - (originalX + v1), originalY-h1, originalZ);
//         //     Debug.Log("cccc");
//         //     direction = -direction;
//         // } 
//         // Debug.Log(direction);
//         // // else { 
//         // //     transform.eulerAngles = new Vector3(originalX + v1, originalY-h1, originalZ);
//         // // }

//         // // this.transform.Rotate(new Vector3(h1,v1,0));
//         // this.transform.eulerAngles += new Vector3(direction * v1, -h1, 0);
//         // // Or prefer create a Quaternion and assign the rotation
//         // // transform.rotation = Quaternion.LookRotation(h1 * Vector3.right, v1 * Vector3.up);

//         // if (h1 != 0 || v1 != 0) { 
//         //     // Smoothly tilts a transform towards a target rotation.
//         //     float tiltAroundY = v1 * tiltAngle;
//         //     float tiltAroundX = h1 * tiltAngle;

//         //     // Rotate the cube by converting the angles into a quaternion.
//         //     Quaternion target = Quaternion.Euler(originalX + tiltAroundX, originalY + tiltAroundY, 0);

//         //     // Dampen towards the target rotation
//         //     transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
//         // }

//         // // Smoothly tilts a transform towards a target rotation.
//         // float tiltAroundY = v1 * tiltAngle;
//         // float tiltAroundX = h1 * tiltAngle;

//         // // Rotate the cube by converting the angles into a quaternion.
//         // Quaternion target = Quaternion.Euler(originalY + tiltAroundY, originalX + tiltAroundX, 0);

//         // // Dampen towards the target rotation
//         // transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
//     }
// }




