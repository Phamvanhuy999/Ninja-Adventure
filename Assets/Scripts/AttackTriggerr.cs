using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerr : MonoBehaviour
{
  
    public int dmg = 20;
	
	private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger!=true && col.CompareTag("Monster"))//Nếu quái không là Trigger và là là tag Monster
        {
            col.SendMessageUpwards("Damage", dmg);//gọi đến hàm tấn công quái
            
        }
    }
}