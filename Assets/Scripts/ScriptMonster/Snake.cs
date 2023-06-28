using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Animator anim;
    public float speed = 0.01f, changeDirection = 0;
    Vector3 Move;
    public int Heath = 100;
    public bool faceright = true;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
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
    public void Dead()
    {
        speed = 0;
        anim.SetTrigger("MDead");
        Destroy(gameObject, 2f);//quái bi?n m?t
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Kunai"))
        {
            Destroy(col.gameObject);
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
}
