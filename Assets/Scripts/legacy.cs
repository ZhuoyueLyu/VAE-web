

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
    
    
    // void OnTriggerEnter(Collider other) {
    //     Debug.Log("Enter");
    //     Debug.Log(other.gameObject.GetComponent<DragAndSnap>().isGrabbed);
    //     // if (other.gameObject.GetComponent<DragAndSnap>().isGrabbed) {
    //     //     Debug.Log("Enter myself");
    //     //     return;
    //     // } 
    //     // Debug.Log("Enter another object");
    //     //  ChangeMaterial(red);
    // }

    // void OnTriggerExit (Collider other) {
    //     Debug.Log("Exit");
    //     Debug.Log(other.gameObject.GetComponent<DragAndSnap>().isGrabbed);
    //     // if (other.gameObject.GetComponent<DragAndSnap>().isGrabbed) {
    //     //     Debug.Log("exit myself");
    //     //     return;
    //     // } 
    //     // Debug.Log("Exit another object");
    //     // ChangeMaterial(green);
    // }



// SnapCube.gameObject.GetComponent<BoxCollider>().enabled = false; // disable the box collider so it won't colide with other cubes
// 		    isGrabbed = true;