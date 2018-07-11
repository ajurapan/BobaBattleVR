using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickUpParent : MonoBehaviour {

    public static SteamVR_TrackedObject trackedObj;
    public static SteamVR_Controller.Device device;

    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	void FixedUpdate () {
      
	}

    void OnTriggerStay(Collider col)
    {
        GetComponent<Slingshot>();
        device = SteamVR_Controller.Input((int)trackedObj.index);

        Debug.Log("You have collided with " + col.name + " and activated OnTriggerStay");

        //pick up a ball, the ball transform is now with the controller
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && col.name =="Ball(Clone)" )// && !Slingshot.ballHolding && !Slingshot.inSlingShot)
        {
            Debug.Log("You have collided with " + col.name + " while holding down touch");
            col.attachedRigidbody.isKinematic = true; //make the ridgid body not affected by the physic system
            col.gameObject.transform.SetParent(gameObject.transform);
            Slingshot.ballHolding = true; 
            //this one 
        }


        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && !Slingshot.inSlingShot && Slingshot.ballHolding)
        {
            //load the ball to the slingshot, now the ball is in SlingShot
            if  (col.name == "Band Bone")
            {
                Debug.Log("load the ball");
                Slingshot.inSlingShot = true;
            }
            else //if (col.name == "Ball(Clone)" )
            {
                //drop the ball to the ground
                Debug.Log("object released");
                col.gameObject.transform.SetParent(null);
                col.attachedRigidbody.isKinematic = false;
                col.attachedRigidbody.useGravity = true;
                Slingshot.ballHolding = false;
            }
        }
    }      
}
