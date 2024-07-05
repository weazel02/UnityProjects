using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    AudioSource audioSource;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {  
        if(Input.GetKey(KeyCode.Space))
        {   
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if(!rightBooster.isPlaying && !leftBooster.isPlaying)
            {
                rightBooster.Play();
                leftBooster.Play();
            }  
        }  
        else
        {
            audioSource.Stop();
            rightBooster.Stop();
            leftBooster.Stop();
        }     
    }
    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {   
            rb.freezeRotation = true;
            transform.Rotate(Vector3.back * rotationThrust * Time.deltaTime);
        }
        rb.freezeRotation = false;
    }
}
