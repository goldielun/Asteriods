using UnityEngine;

public class titleaudio : MonoBehaviour

{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip explode;
    public AudioClip Engines;
    public AudioClip fire;
    public AudioClip teleport;
    public AudioClip titlemusic;

    private void Start()
    {
        musicSource.clip = titlemusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
