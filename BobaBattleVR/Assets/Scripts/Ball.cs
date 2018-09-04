using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject ballStand;

    private GameObject currBall;

    public static bool ballHolding = false;
    private bool ready;
    public static bool inSlingShot = false;


    private Slingshot slingshot;
    private PickUpParent pickUpParent;
 
    void Awake()
    {
       slingshot = GetComponent<Slingshot>();
        pickUpParent = GetComponent<PickUpParent>();
    }
   
    void Start () {
        ready = true;
	}
	
	
	void FixedUppdate () {
        if (ready)
        {
            Debug.Log("In SlingShot.cs ready");
            currBall = Instantiate(ballPrefab);
            currBall.transform.parent = ballStand.transform;
            currBall.transform.localPosition = Vector3.zero;
            ready = false; // make it false here to make it don't keep sprawning a ball
        }

        if (inSlingShot && ballHolding)
        {
            Debug.Log("In Slingshot true ");
            currBall.transform.parent = slingshot.slingGO.transform;
            currBall.transform.localPosition = Vector3.zero;
            ballHolding = false;
        }  
        
        //void shootTheBall()
    //{
    //    Vector3 ballPos = currBall.transform.position;

    //    slingGO.transform.position = slingShotStart;
    //    currBall.transform.parent = null;

    //    Rigidbody r = currBall.GetComponent<Rigidbody>();
    //    r.velocity = Vector3.forward * 50f; //The ball will move to the z direction Vector3.forward = Vector3(0,0,1)
    //    r.velocity = (slingShotStart - ballPos) * 5f;
    //    r.isKinematic = false;
    //    r.useGravity = true;
    //    inSlingShot = false;
    //    //try to destory the ball after 1 sec it hit the ground

    //    ready = true;
    //}


        if (inSlingShot && !ballHolding)
        {
            if (PickUpParent.device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Shoot the ball");
               // slingshot.shootTheBall();
            }
            if (PickUpParent.device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Moving the ball");
                slingshot.slingGO.transform.position = PickUpParent.trackedObj.transform.position;
            }
        }
    }

    
}
