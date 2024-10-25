using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource; // Audio source component to play the sound
    public AudioClip hitSurfaceClip; // Sound when paper ball hits any surface
    public AudioClip hitDustbinClip; // Sound when paper ball hits the dustbin
    public AudioClip insideDustbinClip; // Sound when paper ball goes inside the dustbin
    
    public GameObject dustbin; // Reference to the dustbin object
    
    // This function is called when the paper ball collides with any object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with is the dustbin
        if (collision.gameObject == dustbin)
        {
            PlaySound(hitDustbinClip); // Play dustbin hit sound
        }
        else
        {
            PlaySound(hitSurfaceClip); // Play general hit sound for other surfaces
        }
    }

    // This function is called when the paper ball enters a trigger collider (e.g., the dustbin trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the dustbin
        if (other.gameObject == dustbin)
        {
            PlaySound(insideDustbinClip); // Play "inside dustbin" sound
        }
    }

    // Function to play the assigned audio clip
    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
