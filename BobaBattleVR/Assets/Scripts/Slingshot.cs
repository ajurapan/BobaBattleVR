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
    public static bool inSlingShot = false;
    private bool ready = true; //spawn a ball when true
     

    void  Start() {
        slingShotStart = slingGO.transform.position;
	}

   
    void FixedUpdate() {
        if (ready)
        {
            Debug.Log("In SlingShot.cs ready");
            currBall = Instantiate(ballPrefab);
            currBall.transform.parent = ballStand.transform;
            currBall.transform.localPosition = Vector3.zero; 
            ready = false; // make it false here to make it don't keep sprawning a ball
        }

        if(inSlingShot && ballHolding)
        {
            Debug.Log("In Slingshot true ");
            currBall.transform.parent = slingGO.transform;
            currBall.transform.localPosition = Vector3.zero;
            ballHolding = false;
        }

        if (inSlingShot && !ballHolding)
        {
            if (PickUpParent.device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {                
                Debug.Log("Shoot the ball");

                Vector3 ballPos = currBall.transform.position;

                slingGO.transform.position = slingShotStart;
                currBall.transform.parent = null;

                Rigidbody r = currBall.GetComponent<Rigidbody>();
                r.velocity = Vector3.forward * 50f; //The ball will move to the z direction Vector3.forward = Vector3(0,0,1)
                r.velocity = (slingShotStart - ballPos) * 5f;
                r.isKinematic = false;
                r.useGravity = true;
                inSlingShot = false;
                ready = true;

            }
            if (PickUpParent.device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Moving the ball");
                slingGO.transform.position = PickUpParent.trackedObj.transform.position;
            }
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
    //-------this doesn't work-------
    //    if (ballHolding == true && other.name == "slingGO")
    //    {
    //        Debug.Log("collided with slingshot while holding a ball");
    //        Debug.Log("enter " + other.name);
    //        currBall.transform.parent = slingGO.transform;
    //        currBall.transform.localPosition = Vector3.zero;
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
