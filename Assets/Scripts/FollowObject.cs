using UnityEngine;
 using System.Collections;
 
 public class FollowObject : MonoBehaviour {
     
     public Transform target;

     private Camera cam;
 
    void Start ()
    {
        Update();
     }

     // Update is called once per frame
     void Update () 
     {
         if (target) {

             Vector3 targetPosition = target.position;
             targetPosition.z = transform.position.z;

             transform.position = targetPosition;
         }     
     }
 }