using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _afterToasts;
    [SerializeField] private AudioClip _beforeToast;
    [SerializeField] private AudioClip _startThief;
    [SerializeField] private AudioClip _catchThief;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _click;

    public void StartThief()
    {
        _source.PlayOneShot(_startThief);
    }
    public void CatchThief()
    {
        _source.PlayOneShot(_catchThief);
    }
    public void ClickStartToaster()
    {
        _source.PlayOneShot(_afterToasts);
    }

    public void StopToaster()
    {
        _source.PlayOneShot(_beforeToast);
    }
    public void Click()
    {
        _source.PlayOneShot(_click);
    }
}
