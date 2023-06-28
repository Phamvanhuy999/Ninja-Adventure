using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDragonWalk : MonoBehaviour
{
    public float speed = 0.01f, changeDirection = 0;
    Vector3 Move;
    public int Heath = 100;
    public bool faceright = true;
    public Animator anim;
    public PlayerController player;
    public SoundManager sound;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        Move = this.transform.position;
    }
    void Update()
    {
        Move.x += speed;
        transform.position = Move;
        if (Heath <= 0)
        {
            Dead();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
            Flip();
        }
    }
    public void Dead()
    {
        speed = 0;
        anim.SetTrigger("MDead");
        Destroy(gameObject, 2f);//quái bi?n m?t
    }
    public void Damage(int damage)
    {
        Heath -= damage;
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Kunai"))
        {
            Destroy(col.gameObject);
        }
    }
    
}
