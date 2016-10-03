using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class childTrigger : MonoBehaviour {
    Vector3 initialPos;
   public testPopup testRef;
    void Start()
    {
        initialPos = transform.position;
        
    }
    void Update()
    {
        testPopup testRef = GetComponent<testPopup>();
    }
	// Use this for initialization
	void OnTriggerEnter(Collider collide)
    {
        //if (testPopup.Selected == true)
        //{
        if (collide.tag == "playerCam"/* && testRef.selectedChoice == true*/)
            {
                gameObject.SetActive(false);
                gameObject.transform.position = initialPos;
                SceneManager.LoadScene(1);
            }
        //}
    }
}
