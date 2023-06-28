using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite[] Heartsprite;//Khai báo mảng để chứa các thanh máu
    public PlayerController player;
    public Image heart;
    void Start()
    {    
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void FixedUpdate()
    {
        heart.sprite = Heartsprite[player.OurHealth];//các thanh máu sẽ bằng với lượng máu của nhân vật
    }
}
