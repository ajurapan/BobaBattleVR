using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Slingshot : MonoBehaviour {

   

    public GameObject ballPrefab;
    public GameObject slingGO; //slingGameObject
    public GameObject ballStand;

    private GameObject currBall;
    private Vector3 slingShotStart; //use to remember the start position

    public static bool ballHolding = false;
    private bool inSlingShot = false;
    private bool ready = true; //spawn a ball when true
     

    void  Start() {
        slingShotStart = slingGO.transform.position;
	}

   
    void FixedUpdate() {
        Debug.Log("In fixed update");

        if (ready)
        {
            Debug.Log("In SlingShot.cs ready");
            currBall = Instantiate(ballPrefab);
            currBall.transform.parent = ballStand.transform;
            currBall.transform.localPosition = Vector3.zero; 
            ready = false; // make it false here to make it don't keep sprawning a ball
        }

            //if (!inSlingShot) //when the ball is not in Slingshot
            //{
            //    if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            //    {
                    
            //    }

            //    //when the ball touch the slingshot (collider) OnTriggerEnter? 
            //    //change the ball transform on the slingshot (coded), inSlingShot = true, shot the ball(coded)
            //}
	}

  

    //void OnTriggerEnter(Collider other)
    //{
    //    trackedController = other.GetComponent<SteamVR_TrackedObject>();
    //    if (trackedController != null)
    //    {
    //        inSlingShot = true;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    trackedController = other.GetComponent<SteamVR_TrackedObject>();
    //    if (trackedController != null)
    //    {
    //        inSlingShot = false;
    //    }
    //}
}
