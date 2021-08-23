using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{


    public Transform zEasy; // the latent space object
    public Transform zHard; // the latent space object
    public Transform OutputsEasy;
    public Transform OutputsHard;
    public GameObject Timer;

    Transform z; // the latent space object
    Transform Outputs;

    public static int gameIndex = 0;

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

    void Start(){
        z = zEasy;
        Outputs = OutputsEasy;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d")) {
            if (outputIndex > 2) {
                return; // if there are already three outputs, stop producing more
            }
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
            if (outputIndex == 3) {
                Timer.GetComponent<Timer>().TimerStop(); // if there are already three outputs, stop the timer.
            }
        } else if (Input.GetKeyDown("e") || Input.GetKeyDown("n")) { // destroy outputs if the user try to move the objects (in encoder mode)
            if (Input.GetKeyDown("n"))
            { 
                if (gameIndex == 0) {    
                    // Switch game
                    transform.GetChild(gameIndex).gameObject.SetActive(false);
                    gameIndex += 1;
                    transform.GetChild(gameIndex).gameObject.SetActive(true);
                    Timer.GetComponent<Timer>().TimerReset(); // reset timer
                    z = zHard;
                    Outputs = OutputsHard;
                } else {
                    // prevent the user from switch back and forth between difficulties.
                    return;
                }
            } else { // Input.GetKeyDown("e") 
                if (outputIndex > 2) { // if the timer was paused on three outputs
                    Timer.GetComponent<Timer>().TimerResume(); // if we resume
                }
            }
            outputIndex = 0;
            // remove all previous attached children
            for (int i = 0; i < Outputs.childCount; i++) {
                Transform thatChild = Outputs.GetChild(i);
                foreach (Transform child in thatChild) {
                    GameObject.Destroy(child.gameObject);
                }
            }
        }
    }
}
