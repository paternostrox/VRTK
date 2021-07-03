using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaker : MonoBehaviour
{
    public AudioClip[] sounds;
    public float duration = 5;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(MakeSound());
    }

    // Update is called once per frame
    IEnumerator MakeSound()
    {
        for (; ; )
        {
            source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
            yield return new WaitForSeconds(duration);
        }
    }
}
