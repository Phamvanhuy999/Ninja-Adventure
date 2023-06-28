using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;//Gọi đến chuyển động của Nhân vật
    /*public float dis;*/
    void Start()
    {
        /*dis = Mathf.Abs(player.transform.position.y-transform.position.y);*/
    }
    void Update()
    {
        // Camera bằng chuyển động của Nhân vật theo chiều x và y
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
