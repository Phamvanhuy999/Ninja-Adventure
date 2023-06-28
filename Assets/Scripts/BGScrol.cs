using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrol : MonoBehaviour
{
    public PlayerController player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void FixedUpdate()
    {
        Vector2 offset = GetComponent<MeshRenderer>().material.mainTextureOffset;
        offset.x = player.transform.position.x;
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset * Time.deltaTime/10f;
    }
}
