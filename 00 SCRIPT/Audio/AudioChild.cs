using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChild : MonoBehaviour
{
    AudioSource _audiosource;
    private void Awake()
    {
        _audiosource = this.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        StartCoroutine(WaitSoundDone());
    }
    void Update()
    {

    }
    IEnumerator WaitSoundDone()
    {
        yield return new WaitUntil(() => !_audiosource.isPlaying);
        this.gameObject.SetActive(false);
    }


}
