using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KunaiController : MonoBehaviour
{
    
    Rigidbody2D r2;
    public float speed;   
    public int dmg = 10;
    
    void Awake()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();

        if (transform.localRotation.z < 0)//nếu kunai quay theo trục z là -90

        {//ForceMode2d.Impulse là thêm 1 lực cho kunai có thể bay đi
            r2.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);//AddForce là thêm cho 1 lực theo chiều ngang và sang phải
        }
        else//nếu kunai quay theo trục z là 90
            r2.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);//AddForce là thêm cho 1 lực theo chiều ngang và sang trái
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Monster"))// nếu col không là trigger và là tag Monster
        {
            col.SendMessageUpwards("Damage", dmg);//gọi đến hàm Damage của các quái
        }
    }
}