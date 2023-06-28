using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed, maxspeed = 3, jumpow = 220f,throwRate=5f,nextThrow=0;
    public bool grounded = true, faceright = true,doublejump=false;
    public Rigidbody2D r2;
    public Animator anim;
    public Collider2D col;
    public int OurHealth=8;
    public int Lives = 3;
    public Gamemaster gm;
    public GameObject PanelGameOVer,Player, Kunai,PanelEnd;
    public SoundManager sound;  
    public Transform kunaiTip;//vi tri cua kunai duoc ban ra
    public Text End;
    public Button button1;
    void Start()//Ánh xạ
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<Collider2D>();
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    void Update()
    {              
    }
    IEnumerator DelayGround()
    {
        if (!grounded)
        {
            yield return new WaitForSeconds(1f);//dợi sau 1 giây
            grounded = true;
        }
    }      
    void FixedUpdate()
    {
        float h = Input.GetAxis("Game");
        anim.SetFloat("Speed", Mathf.Abs(h));//gọi đến Parameter Spees để tạo ra animation cho nhân vật
        r2.velocity = new Vector2(h * speed, r2.velocity.y); //tạo ra vận tốc cho nhân vật   
       

        if (h > 0 && !faceright) { Flip(); }//Nếu di chuyển sang phải và mặt quay sang trái thì gọi đến Hàm Flip để lật lại người
        if (h < 0 && faceright) { Flip(); }//Nếu di chuyển sang phải và mặt quay sang trái thì gọi đến Hàm Flip để lật lại người
        /*if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }*/
        if (OurHealth<=0)//Nếu máu nhỏ hơn hoặc bằng 0
        {               
            gm.UpdateLives(1);//Gọi đến hàm UpdateLive bên gm đề trừ đi 1 mạng
            OurHealth = 8;//Set lại máu ở trạng thái ban đầu bằng 8          
        }  
        if(Lives<=0)//Nếu Mạng của nhân vật nhỏ hơn bằng 0
        {
            Death();//gọi đến hàm Death
        }
        //Nhân vật nhảy
        anim.SetBool("Grounded", grounded);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (grounded)//nếu nhận vật đang dưới đất   
            {
                grounded = false;//chân sẽ không chạm đất
                doublejump = true;
                r2.AddForce(Vector2.up * jumpow);//thêm lực theo chiều hướng lên
                StartCoroutine(DelayGround());
            }
            else//nếu chân không chạm đất
            {
                if (doublejump)//nếu đang nhảy thêm lần
                {
                    doublejump = false;//không nhảy thêm được nữa
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpow);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (anim)
                anim.SetTrigger("Throw");
            Throw();
            sound.Playsound("Phi");
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void Death()
    {
        if (anim)
            anim.SetTrigger("Die");
        PanelGameOVer.SetActive(true);
        speed = 0;
        
    }
    public void Damaged(int damage)//hàm nhân vật bị trừ máu khi va phải chướng ngại vật
    {
        OurHealth -= damage;       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Coin"))//Khi va chạm các Tag Coin
        {
           
            Destroy(col.gameObject);//Phá hủy Coin
            gm.Points += 1;//Tăng Coin lên 1
            sound.Playsound("coins");//Phát âm thanh ăn Coin
        }
        if(col.CompareTag("HP"))
        {
            Destroy(col.gameObject);
            OurHealth += 1;
        }
        if(col.CompareTag("End"))
        {
            //PanelEnd.SetActive(true);
            gm.Endtext.text = ("Chúc mừng bạn đã giải cứu thành công Yakura!"+"\n"+
                                            "Cảm ơn bạn đã trải nghiệm game!");   
        }
    }
    void Throw()
    {
        if (Time.time > nextThrow)
            nextThrow = Time.time + throwRate;
		{
            if (faceright)//nếu mặt quay sang phải
            {
                //quay kunai theo hướng của mặt là -90 theo trục z
                Instantiate(Kunai, kunaiTip.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            }
            else//nếu mặt quay sang trái
            {
                //quay kunai theo hướng của mặt là 90 theo trục z
                Instantiate(Kunai, kunaiTip.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            }
        }   
    }
}
