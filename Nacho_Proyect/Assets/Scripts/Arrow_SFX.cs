using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_SFX : MonoBehaviour
{
    public static Arrow_SFX Instance;

    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ejecutarSonido(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
