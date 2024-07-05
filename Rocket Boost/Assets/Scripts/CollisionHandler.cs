using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;    
    float delayInSceconds = 1f;
    AudioSource audioSource;
    bool isTransitioning = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }
    void OnCollisionEnter(Collision other) 
    {

        if(isTransitioning) { return; }
        switch(other.gameObject.tag)
        {
            case "Friendly":

            break;
            case "Finished":
            StartNextLevelSequence();
            break;
            default: 
            StartCrashSequence();       
            break;

        }    
    }
    void StartCrashSequence()
    {   
        isTransitioning = true;
        audioSource.Stop();
        crashParticles.Play();
        audioSource.PlayOneShot(crashAudio);
        GetComponent<Movement>().enabled = false;  
        Invoke("ReloadLevel", delayInSceconds);
    }
     void StartNextLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        successParticles.Play();
        audioSource.PlayOneShot(successAudio);
        GetComponent<Movement>().enabled = false;  
        Invoke("LoadNextLevel", delayInSceconds);
    }
    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
