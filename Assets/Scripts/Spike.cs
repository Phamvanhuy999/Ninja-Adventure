using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spike : MonoBehaviour
{
    public PlayerController player;
    public SoundManager sound;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))//khi người chơi va chạm với Spike
        {
            player.Damaged(1);//trừ 1 máu
            sound.Playsound("bleed");//phát ra âm thanh bị mất máu
        }
    }
    void Update()
    {
        
    }
}
