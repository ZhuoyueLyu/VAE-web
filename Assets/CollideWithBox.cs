using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithBox : MonoBehaviour
{
    public Material red;
    public Material green;

    public static bool isRed = false;
    void ChangeMaterial(Material m) {
        foreach (Transform child in transform) {
            child.gameObject.GetComponent<MeshRenderer> ().material = m;
        }
    }

    bool isObjectHere(Vector3 position)
{
    Collider[] intersecting = Physics.OverlapSphere(position, 0.01f);
    if (intersecting.Length == 0)
    {
        return false;
    }
    else {
        foreach (Collider collidedBox in intersecting) {
            if (!collidedBox.gameObject.GetComponent<DragAndSnap>().isGrabbed) {
                return true;
            }
        }
        return false;
    }
}



    void Update(){
        if (isObjectHere(transform.position)){
            if (!isRed) {
                ChangeMaterial(red);
                isRed = true;
            }
        } else {
            if (isRed) {
                ChangeMaterial(green);
                isRed = false;
            }
        }
    }
}
