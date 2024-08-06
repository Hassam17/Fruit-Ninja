using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AudioClip explodeSound; // The sound to play when the bomb explodes
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // Add an AudioSource component if not already attached
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the volume if desired, e.g., audioSource.volume = 0.5f;
        audioSource.volume = 0.5f; // You can adjust this as needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;

            // Play the explosion sound
            PlayExplosionSound();

            // Trigger the explosion in the game manager
            GameManager.Instance.Explode();
        }
    }

    private void PlayExplosionSound()
    {
        if (explodeSound != null)
        {
            audioSource.PlayOneShot(explodeSound);
        }
    }
}
