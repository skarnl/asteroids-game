using UnityEngine;
 using System.Collections;
 
 public class FollowObject : MonoBehaviour {
     
     public float dampTime = 0.15f;
     private Vector3 velocity = Vector3.zero;
     public Transform target;

     private Camera cam;
 
    void Start ()
    {
        cam = GetComponent<Camera>();

        if (target) {
            //this is a little bullshit, but currently no idea (read: time) to make this correct
		    Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = destination;
         }
     }

     // Update is called once per frame
     void Update () 
     {
         if (target) {
			 Vector3 point = cam.WorldToViewportPoint(target.position);
             Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }     
     }
 }