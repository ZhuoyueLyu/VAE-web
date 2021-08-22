using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Transform z; // the latent space object
    public Transform Outputs;

    int outputIndex = 0;

    // remove all the components of this object such that it won't move with the latent object
    void destroyComponents(GameObject obj) {
        foreach (var comp in obj.GetComponents<Component>()) {
            if (comp is MeshRenderer) {
                MeshRenderer compNew = comp as MeshRenderer;
                compNew.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            } else if(!(comp is Transform) && !(comp is MeshFilter)) {
                Destroy(comp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d")) {
            Transform thatChild = Outputs.GetChild(outputIndex % Outputs.childCount);
            foreach (Transform child in thatChild) {
                // remove all previous attached children
                GameObject.Destroy(child.gameObject);
            }
            GameObject duplicate = Instantiate(z.gameObject);
            destroyComponents(duplicate);
            foreach(Transform child in duplicate.transform) {
                destroyComponents(child.gameObject);
            }
            duplicate.transform.parent = thatChild;
            duplicate.transform.localPosition = new Vector3(0, 0, 0);
            outputIndex += 1;
        }
    }
}
