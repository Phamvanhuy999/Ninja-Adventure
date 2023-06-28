using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlat1 : MonoBehaviour//Di chuyển bậc thềm theo chiều x
{
    public float speed = 0.03f;
    Vector3 Move;
    void Start()
    {
        Move = this.transform.position;
    }
    void Update()
    {
        Move.x += speed;//Vị trí ban đầu cộng dần với speed theo chiều x
        transform.position = Move;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *=-1;//Khi va chạm với Ground thì speed sẽ là âm và Flat sẽ di chuyển ngược lại vị trí ban đầu
        }
    }
}
