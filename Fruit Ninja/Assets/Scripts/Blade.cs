using UnityEngine;

public class Blade : MonoBehaviour
{
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;
    public AudioClip sliceSound; // Add this line for the slice sound

    private Camera mainCamera;
    private Collider sliceCollider;
    private TrailRenderer sliceTrail;
    private AudioSource audioSource; // Add this line for the audio source

    public Vector3 direction { get; private set; }
    public bool slicing { get; private set; }

    private void Awake()
    {
        mainCamera = Camera.main;
        sliceCollider = GetComponent<Collider>();
        sliceTrail = GetComponentInChildren<TrailRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // Add an AudioSource component if not already attached
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the volume to 0.5
        audioSource.volume = 0.20f;
    }

    private void OnEnable()
    {
        StopSlice();
    }

    private void OnDisable()
    {
        StopSlice();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlice();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlice();
        }
        else if (slicing)
        {
            ContinueSlice();
        }
    }

    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        transform.position = position;

        slicing = true;
        sliceCollider.enabled = true;
        sliceTrail.enabled = true;
        sliceTrail.Clear();

        // Play the slice sound
        PlaySliceSound();
    }

    private void StopSlice()
    {
        slicing = false;
        sliceCollider.enabled = false;
        sliceTrail.enabled = false;

        // Stop the slice sound
        StopSliceSound();
    }

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        sliceCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;

        // Play the slice sound if not already playing
        if (!audioSource.isPlaying)
        {
            PlaySliceSound();
        }
    }

    private void PlaySliceSound()
    {
        if (sliceSound != null)
        {
            audioSource.clip = sliceSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void StopSliceSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
