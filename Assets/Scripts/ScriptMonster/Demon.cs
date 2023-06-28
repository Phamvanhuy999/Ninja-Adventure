using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public Gamemaster gm;
    public Animator anim;
    public int Heath = 100;//T?o l??ng máu cho quái là 100
	 void Start()
	{
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
        anim = gameObject.GetComponent<Animator>();

    }
    void Update()
    {
        if (Heath<= 0)//n?u máu nh? h?n 0 
        {
            
            Dead();
        }     
    }
    public void Damage(int damage)//Hàm quái bị mất máu khi nhân vật tấn công
    {
        Heath -= damage;
    }
	private void OnTriggerEnter2D(Collider2D col)//Khi kunai va chạm vào quái vật thì kunai sẽ biến mất
	{
		if(col.CompareTag("Kunai"))
		{
            Destroy(col.gameObject);

		}            
	}
    public void Dead()
	{
        anim.SetTrigger("MDead");//Set trạng thái Dead của quái vật
        Destroy(gameObject,2f);//quái biến mất sau 2s
    }        
}

