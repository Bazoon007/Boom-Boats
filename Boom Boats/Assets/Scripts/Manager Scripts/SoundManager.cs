using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public MasterManager masterManager;
    public AudioClip ThreeTwoOneSound;
    public AudioClip GameEndedSound;
    public AudioClip Cannon0Shoot;
    public AudioClip Island0Hit;
    public AudioClip Island0Dead;
    public AudioClip Cannon1Shoot;
    public AudioClip Island1Hit;
    public AudioClip Island1Dead;
    public AudioClip Cannon2Shoot;
    public AudioClip Island2Hit;
    public AudioClip Island2Dead;
    public AudioClip Cannon3Shoot;
    public AudioClip Island3Hit;
    public AudioClip Island3Dead;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void CannonShootSound(int cannonIndex)
    {
        switch (cannonIndex)
        {
            case 0:
                audioSource.clip = Cannon0Shoot;
                break;
            case 1:
                audioSource.clip = Cannon1Shoot;
                break;
            case 2:
                audioSource.clip = Cannon2Shoot;
                break;
            case 3:
                audioSource.clip = Cannon3Shoot;
                break;
            default:
                break;
        }

        playSound();
    }

    public void PlayIslandHitButNotDeadSound(int islandIndex)
    {
        switch (islandIndex)
        {
            case 0:
                audioSource.clip = Island0Hit;
                break;
            case 1:
                audioSource.clip = Island1Hit;
                break;
            case 2:
                audioSource.clip = Island2Hit;
                break;
            case 3:
                audioSource.clip = Island3Hit;
                break;
            default:
                break;
        }

        playSound();
    }

    public void PlayIslandDeadSound(int islandIndex)
    {
        switch (islandIndex)
        {
            case 0:
                audioSource.clip = Island0Dead;
                break;
            case 1:
                audioSource.clip = Island1Dead;
                break;                    
            case 2:                       
                audioSource.clip = Island2Dead;
                break;                    
            case 3:                       
                audioSource.clip = Island3Dead;
                break;
            default:
                break;
        }

        playSound();
    }

    public void PlayThreeTwoOne()
    {
        audioSource.clip = ThreeTwoOneSound;
        playSound();
    }

    public void PlayGameEnd()
    {
        audioSource.clip = GameEndedSound;
        playSound();
    }

    private void playSound()
    {
        if (masterManager.IsGameRunning())
        {
            audioSource.Play();
        }
    }
}
