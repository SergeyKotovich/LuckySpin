using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource1;
    [SerializeField] private AudioSource _audioSource2;
    
    [SerializeField] private AudioClip _insertTicketSound;
    [SerializeField] private AudioClip _drumSpinSound;
    [SerializeField] private AudioClip _defeatSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _collectPrize;
    
    public void PlayInsertTicketSound()
    {
        _audioSource1.clip = _insertTicketSound;
        _audioSource1.Play();
    }

    public void PlayDrumSpinSound(bool staySound)
    {
        _audioSource2.clip = _drumSpinSound;
        if (staySound)
        {
            _audioSource2.Play();
            _audioSource2.loop = true;
        }
        else
        {
            _audioSource2.Stop();
            _audioSource2.loop = false;
        }
    }

    public void PlayWinSound()
    {
        _audioSource1.clip = _winSound;
        _audioSource1.Play(); 
    }

    public void PlayDefeatSound()
    {
        _audioSource1.clip = _defeatSound;
        _audioSource1.Play();
    }

    public void PlayCollectPrizeSound()
    {
        _audioSource1.clip = _collectPrize;
        _audioSource1.Play();
    }
    
}
