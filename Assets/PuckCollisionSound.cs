using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PuckCollisionSound : MonoBehaviour
{
    public AudioClip hitClip;
    [Range(0f, 1f)] public float volume = 0.8f;

    // Evita tocar 200 vezes por segundo quando fica “tremendo” na parede.
    public float minInterval = 0.05f;

    private AudioSource src;
    private float lastTime;

    void Awake()
    {
        src = GetComponent<AudioSource>();
        src.playOnAwake = false;
        src.loop = false;
        lastTime = -999f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitClip == null) return;
        if (Time.time - lastTime < minInterval) return;

        lastTime = Time.time;
        src.PlayOneShot(hitClip, volume);
    }
}