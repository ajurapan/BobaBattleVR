using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickUpParent : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

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
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger) && col.name =="Ball(Clone)" && Slingshot.ballHolding == false)
        {
            Debug.Log("col.name" + col.name);
            //pick up a ball, the ball transform is now with the controller
            Debug.Log("You have collided with " + col.name + " while holding down touch");
            col.attachedRigidbody.isKinematic = true; //make the ridgid body not affected by the physic system
            col.gameObject.transform.SetParent(gameObject.transform);
            Slingshot.ballHolding = true; 
        }

        if(Slingshot.ballHolding == true && col.name == "Band Bone")
        {
            Debug.Log("collided with slingshot Band Bone while holding a ball");  
            Slingshot.inSlingShot = true;       
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && col.name == "Ball(Clone)")
        {
            //drop the ball to the ground
            if(Slingshot.inSlingShot == false)
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
