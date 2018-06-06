using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    public GameObject ballPrefab;

    public GameObject slingGO; //slingGameObject

    private GameObject currBall;
    private bool ready = true; //tell us whether the slingshot is loaded or not

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ready)
        {
            currBall = Instantiate(ballPrefab);
            currBall.transform.parent = slingGO.transform;
            currBall.transform.localPosition = Vector3.zero;
            ready = false; // make it false here to make it don't keep sprawning a ball
        }
	}
}
