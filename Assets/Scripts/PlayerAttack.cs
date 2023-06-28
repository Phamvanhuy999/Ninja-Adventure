using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = true,jumpattacking=true;
    public Animator anim;
    public Collider2D trigger;
    public SoundManager sound;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }
     void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    void Update()
    {
        anim.SetBool("JumpAttacking", jumpattacking);
        if (Input.GetKeyDown(KeyCode.Z) && !attacking && !jumpattacking)
        {

            jumpattacking = true;
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
            sound.Playsound("chem");
        }
		if (attacking && jumpattacking)
		{
			if (attackdelay > 0)
			{
				attackdelay -= Time.deltaTime;
			}
			else
			{
				jumpattacking = false;
				attacking = false;
				trigger.enabled = false;
				GetComponent<PlayerController>().grounded = true;
			}
		}
		anim.SetBool("Attacking", attacking);
	}
}
