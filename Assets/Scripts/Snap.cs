using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
   	public bool isVR;
	public Transform SnapCube;

	bool isGrabbed = false;
    

    void OnDrawGizmos() {
        // SnapToGrid();
    }

    void Start() {
        SnapCube.gameObject.SetActive(false);
    }

    void SnapToGrid(Transform localTransform) {
        // !! it's quite important to use localPosition, localRotation instead of Position and Rotation.
        // Since the whole thing is going to rotate
        var pos = new Vector3(
            Mathf.RoundToInt(transform.localPosition.x),
            Mathf.RoundToInt(transform.localPosition.y),
            Mathf.RoundToInt(transform.localPosition.z)
        );

        localTransform.localPosition = pos;
        localTransform.localRotation = Quaternion.identity;
    }


    void OnMouseUp() {
        isGrabbed = false;
		SnapCube.gameObject.SetActive(false);
    }


	void OnMouseDown()

	{
        SnapCube.gameObject.SetActive(true);
		isGrabbed = true;
	}

void Update() { // !!! DON'T USE FixedUpdate() for SnapToGrid()!!! Wasted 10 hours on this
    /* if we use FixedUpdate, the cube will not be able to perfectly aligh with each other, 
    since it shifts a little bit after the fixedUpdate done but Update hasn't */

        if (isVR) {
            // enable the followings in VR mode
            // if (!transform.GetComponent<OVRGrabbable>().isGrabbed) {
            //     SnapToGrid();
            // }
        } else {
            if (isGrabbed) {
                SnapToGrid(SnapCube); // move the snap cube on grab		
            } else {
				SnapToGrid(transform); // move the real cube on not grab
			}
        }
}

}
