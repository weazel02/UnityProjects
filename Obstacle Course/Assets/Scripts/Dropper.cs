using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody dropperBody;
    [SerializeField] float timeToWait = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        dropperBody = GetComponent<Rigidbody>();
        dropperBody.useGravity = false;
    }   

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToWait)
        {
            renderer.enabled = true;
            dropperBody.useGravity = true;
        }
    }
}
