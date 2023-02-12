using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    void OnMouseDrag() 
    {
		Vector3 Screepoint = Camera.main.WorldToScreenPoint (transform.position);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Screepoint.z);
		Vector3 objposition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = objposition;
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
    }
}
