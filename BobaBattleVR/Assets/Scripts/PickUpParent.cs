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
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger) && col.name =="Ball(Clone)")
        {
            Debug.Log("col.name" + col.name);
            //pick up a ball, the ball transform is now with the controller
            Debug.Log("You have collided with " + col.name + " while holding down touch");
            col.attachedRigidbody.isKinematic = true; //makethe ridgid body not affected by the physic system
            col.gameObject.transform.SetParent(gameObject.transform);
            Slingshot.ballHolding = true;

            // ***** Now need to make it load to the bandbone and stay there********
            //mulitiple on triggr stay, if the object is this blah blah??
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && col.name == "Ball(Clone)")
        {
            //drop the ball 
            Debug.Log("object released");
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;
            col.attachedRigidbody.useGravity = true;
            Slingshot.ballHolding = false;

        }
    }
}
