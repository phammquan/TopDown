using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audicontroller : Singleton<Audicontroller>
{
    [SerializeField] AudioSource _audioSourcePF;
    [SerializeField] List<AudioClip> _listAudio = new List<AudioClip>();
    List<AudioSource> _soundPool = new List<AudioSource>();
    void Start()
    {

    }
    void Update()
    {

    }
    public void PlaySound(String soundname)
    {
        AudioClip _audioClip = null;
        foreach (AudioClip a in _listAudio)
        {
            if (a.name.ToLower().Equals(soundname.ToLower()))
            {
                _audioClip = a;
                break;
            }
        }
        if (_audioClip == null)
        {
            Debug.LogError("Khong ton tai");
        }

        AudioSource audioChild = null;
        foreach (AudioSource s in _soundPool)
        {
            if (s.gameObject.activeSelf)
                continue;
            audioChild = s;
        }

        if (audioChild == null)
        {
            audioChild = Instantiate<AudioSource>(_audioSourcePF,
            this.transform.position, Quaternion.identity, this.transform);

            _soundPool.Add(audioChild);
        }

        audioChild.gameObject.SetActive(false);
        audioChild.clip = _audioClip;
        audioChild.gameObject.SetActive(true);

    }
}
