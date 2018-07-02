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
        //GetComponent<Slingshot>();
        device = SteamVR_Controller.Input((int)trackedObj.index);

        Debug.Log("You have collided with " + col.name + " and activated OnTriggerStay");

        //pick up a ball, the ball transform is now with the controller
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger) && col.name =="Ball(Clone)" && !Slingshot.ballHolding && !Slingshot.inSlingShot)
        {
            Debug.Log("col.name" + col.name);  
            Debug.Log("You have collided with " + col.name + " while holding down touch");
            col.attachedRigidbody.isKinematic = true; //make the ridgid body not affected by the physic system
            col.gameObject.transform.SetParent(gameObject.transform);
            Slingshot.ballHolding = true; 
            //this one 
        }

        //reload the ball, now the ball is in SlingShot
        if(Slingshot.ballHolding && col.name == "Band Bone" && !Slingshot.inSlingShot)
        {
            Debug.Log("collided with slingshot Band Bone while holding a ball");  
            Slingshot.inSlingShot = true;       
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && col.name == "Ball(Clone)")
        {
            //drop the ball to the ground
            if(!Slingshot.inSlingShot)
            {
                Debug.Log("object released");
                col.gameObject.transform.SetParent(null);
                col.attachedRigidbody.isKinematic = false;
                col.attachedRigidbody.useGravity = true;
                Slingshot.ballHolding = false;
            }

        }
    }
}
