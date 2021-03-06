
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndSnap : MonoBehaviour
{
   	public bool isVR;
    public bool isCenter;
	public Transform SnapCube;
	public bool isGrabbed = false;
    Vector3 mOffset;

    Vector3 localOldPos;
	float mZCoord;

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
        if (SwitchBackground.isEncoderMode) { // only allow moving cubes if it's encoder mode
            if (!isCenter) { 
                isGrabbed = false;
                SnapCube.gameObject.SetActive(false);
                if (CollideWithBox.isRed) { // if the target postion already has a box
                    transform.localPosition = localOldPos;
                } else {
                    SnapToGrid(transform); // move the real cube on not grab
                }
            }
        }
    }

	void OnMouseDown() {
        if (SwitchBackground.isEncoderMode || isCenter) { // only allow moving cubes if it's encoder mode
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            if (!isCenter) {
                localOldPos = transform.localPosition;
                SnapCube.gameObject.SetActive(true);
                isGrabbed = true;
            }            
        }
	}

	private Vector3 GetMouseAsWorldPoint() {
		// Pixel coordinates of mouse (x,y)
		Vector3 mousePoint = Input.mousePosition;
		// z coordinate of game object on screen
		mousePoint.z = mZCoord;
		// Convert it to world points
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	void OnMouseDrag() {
        if (SwitchBackground.isEncoderMode || isCenter) { // only allow moving cubes if it's encoder mode
		    this.transform.position = GetMouseAsWorldPoint() + mOffset;
        }
	}

void Update() { // !!! DON'T USE FixedUpdate() for SnapToGrid()!!! Wasted 10 hours on this
    /* if we use FixedUpdate, the cube will not be able to perfectly aligh with each other, 
    since it shifts a little bit after the fixedUpdate done but Update hasn't */

    if (!isCenter) {
        if (isVR) {
                // enable the followings in VR mode
                // if (!transform.GetComponent<OVRGrabbable>().isGrabbed) {
                //     SnapToGrid();
                // }
            } else {
                if (isGrabbed) {
                    SnapToGrid(SnapCube); // move the snap cube on grab		
                }
            }
        }
    }

}
