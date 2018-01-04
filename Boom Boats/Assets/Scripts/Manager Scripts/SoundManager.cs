using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public MasterManager masterManager;
    public AudioSource audioSource;
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
    public AudioClip BoatDead;
    public AudioClip Boat0Hit;
    public AudioClip Boat1Hit;
    public AudioClip Boat2Hit;
    public AudioClip Boat3Hit;
    public AudioClip Island0Wins;
    public AudioClip Island1Wins;
    public AudioClip Island2Wins;
    public AudioClip Island3Wins;


    private void Start()
    {
        AudioListener.pause = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void PlayCannonShootSound(int cannonIndex)
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

    public void PlayThreeTwoOneSound()
    {
        audioSource.clip = ThreeTwoOneSound;
        playSound();
    }

    public void PlayGameEndSound(int islandIndex)
    {
        switch (islandIndex)
        {
            case 0:
                audioSource.clip = Island0Wins;
                break;

            case 1:
                audioSource.clip = Island1Wins;
                break;

            case 2:
                audioSource.clip = Island2Wins;
                break;

            case 3:
                audioSource.clip = Island3Wins;
                break;

            default:
                break;
        }

        playSound();
    }
    
    public void PlayBoatDeadSound()
    {
        audioSource.clip = BoatDead;
        playSound();
    }

    public void PlayBoatHitSound(int islandIndex)
    {
        switch (islandIndex)
        {
            case 0:
                audioSource.clip = Boat0Hit;
                break;

            case 1:
                audioSource.clip = Boat1Hit;
                break;

            case 2:
                audioSource.clip = Boat2Hit;
                break;

            case 3:
                audioSource.clip = Boat3Hit;
                break;

            default:
                break;
        }

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
