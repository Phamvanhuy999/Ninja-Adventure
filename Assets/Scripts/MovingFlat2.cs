using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingFlat2 : MonoBehaviour
{
    public float speed = 0.01f;
    Vector3 Move;
    void Start()
    {
       Move = this.transform.position;
    }
    void Update()
    {
        Move.y += speed;
        transform.position = Move;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= -1;
        }
    }
}
