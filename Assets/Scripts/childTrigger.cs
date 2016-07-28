using UnityEngine;
using System.Collections;

public class childTrigger : MonoBehaviour {
   
	// Use this for initialization
	void OnTriggerEnter(Collider collide)
    {
        if(collide.tag == "playerCam")
        {
            gameObject.SetActive(false);
        }
    }
}
