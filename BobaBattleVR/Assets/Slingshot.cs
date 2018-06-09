using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject slingGO; //slingGameObject

    private Vector3 slingShotStart; //use to remember the start position

    private GameObject currBall;
    private bool ready = true; //tell us whether the slingshot is loaded or not

    private SteamVR_TrackedObject trackedController;
    private bool inSlingShot = false;

	// Use this for initialization
	void Start () {
        slingShotStart = slingGO.transform.position;
       // ready = true;
	}

    // Update is called once per frame
    void Update() {
        if (ready)
        {
            currBall = Instantiate(ballPrefab);
            currBall.transform.parent = slingGO.transform;
            currBall.transform.localPosition = Vector3.zero;
            ready = false; // make it false here to make it don't keep sprawning a ball
        }

        if (trackedController != null)
        {
            var device = SteamVR_Controller.Input((int)trackedController.index);
            if (inSlingShot)
            {
                if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ready = true;
                    inSlingShot = false;

                    Vector3 ballPos = currBall.transform.position;

                    slingGO.transform.position = slingShotStart;
                    currBall.transform.parent = null;
                  
                   

                    Rigidbody r = currBall.GetComponent<Rigidbody>();
                    // r.velocity = Vector3.forward * 100f; //The ball will move to the z direction Vector3.forward = Vector3(0,0,1)
                    r.velocity = (slingShotStart - ballPos) * 5f;
                    r.useGravity = true;
                                               
                }
                else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
                {
                    slingGO.transform.position = trackedController.transform.position;
                }
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        trackedController = other.GetComponent<SteamVR_TrackedObject>();
        if(trackedController != null)
        {
            inSlingShot = true;
        }     
    }

    void OnTriggerExit(Collider other)
    {
        trackedController = other.GetComponent<SteamVR_TrackedObject>();
        if (trackedController != null)
        {
            inSlingShot = false;
        }
    }
}
