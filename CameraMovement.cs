using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //target.transform.position.x -> follow on x plane
    //transform.position.y --> doesnt adjust height, add target transform for movement on y plane
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, -10);
    }
}
