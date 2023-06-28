using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door1 : MonoBehaviour
{
      
    public Gamemaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
			savescore();
			gm.inputtext.text = ("Chúc mừng bạn đã nhận được kĩ năng mới là phi Kunai " +"\n"+
                "                        Nhấn E để sang màn tiếp theo");          
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
				savescore();
				SceneManager.LoadScene("Main2");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.inputtext.text = ("");
        }
    }
	void savescore()
	{
		PlayerPrefs.SetInt("Point", gm.Points);
    }
}
