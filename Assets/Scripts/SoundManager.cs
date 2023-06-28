using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public AudioClip sword, coins,stone,bleed,Phi,chem;
    public AudioSource adio;
    void Start()
    {
        chem = Resources.Load<AudioClip>("Chem");
        Phi = Resources.Load<AudioClip>("phi");
        coins = Resources.Load<AudioClip>("EatCoin");
        sword = Resources.Load<AudioClip>("Sword");
        stone = Resources.Load<AudioClip>("StoneDrop");
        bleed = Resources.Load<AudioClip>("Bleed");
        adio = GetComponent<AudioSource>();      
    }
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adio.clip = coins;
                adio.PlayOneShot(coins, 2f);
                break;
            case "sword":
                adio.clip = sword;
                adio.PlayOneShot(sword, 2f);
                break;
            case "stone":
                adio.clip = stone;
                adio.PlayOneShot(stone, 2f);
                break;
            case "bleed":
                adio.clip = bleed;
                adio.PlayOneShot(bleed, 4f);
                break;
            case "Phi":
                adio.clip = Phi;
                adio.PlayOneShot(Phi, 2f);
                break;
            case "chem":
                adio.clip = chem;
                adio.PlayOneShot(chem, 0.17f);
                break;
        }
    }
}
