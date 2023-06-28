using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stone : MonoBehaviour
{ 
    //Viên đá rơi xuống khi Nhân vật va chạm với biển báo Switch
    public float moveSpeed = 1f;
    Rigidbody2D rb;
    bool m_isGround;//check xem đá có ở mặt đất không
    public bool isGround { get => m_isGround; }
    public PlayerController player;
    public SoundManager sound;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    private void FixedUpdate() //Viên đá chỉ rơi khi nhân vật va chạm với biển báo switch
    {
        if (rb)
            rb.velocity = Vector3.down * moveSpeed;//gán cho đá 1 vận tốc theo chiều hướng xuống
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))//Nếu đá va chạm với Tag Ground
        {           
            m_isGround = true;//Đá đã va chạm
            Destroy(gameObject, 1f);//biến mất sau 1 giây
            
        }
        if (col.gameObject.CompareTag("Player"))//Khi người chơi va chạm với đá 
        {
            player.Damaged(1);//trừ 1 máu
            sound.Playsound("bleed");//phát ra âm thanh bị mất máu
        }
    }

}
