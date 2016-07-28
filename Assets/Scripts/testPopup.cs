using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class testPopup : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private bool mShowGUIButton = false;
    private Rect mButtonRect = new Rect(50, 50, 120, 60);
   // bool selectedChoice = false;
    bool Selected;
    Transform player;

    void Start()
    {

        Selected = false;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    void Update()
    {
        player = GameObject.Find("ARCamera").GetComponent<Transform>();
        ObjectTracker track = TrackerManager.Instance.GetTracker<ObjectTracker>();
        bool success = track.PersistExtendedTracking(true);
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            mShowGUIButton = true;
        }
        else
        {
            mShowGUIButton = false;
        }
    }


    void OnGUI()
    {
        if (mShowGUIButton)
        {
            // draw the GUI button
            IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetActiveTrackableBehaviours();
            foreach (TrackableBehaviour tb in tbs)
            {
                if (GUI.Button(mButtonRect, "Select Hero"))
                {
                    if(tb.name == "Samurai_Target")
                    {
                        Selected = true;
                        Debug.Log("Samurai Selected");
                    }
                    else if(tb.name == "Dragon_Target")
                    {
                        Selected = true;
                        Debug.Log("Dragon Selected");
                    }
                    else if(tb.name == "Knight_Target")
                    {
                        Selected = true;
                        Debug.Log("Knight Selected");
                    }
                    else if(tb.name == "Doctor_Target")
                    {
                        Selected = true;
                        Debug.Log("Doctor Selected");
                    }
                   
                }
            }
        }
        if(Selected)
        {
            Vector3 absorbField = player.position - transform.position;
            float index = (5 - absorbField.magnitude) / 5;
            GetComponentInChildren<Rigidbody>().AddForce(-100f*absorbField*index);
            Selected = false;
        }   
    }
}