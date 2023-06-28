using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switch : MonoBehaviour
{
    public PlayerController player;
    public GameObject Vach;
    public Text Warning;
    public SoundManager sound;
    public Gamemaster gm;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))//Khi người chơi va chạm với biển báo Switch
        {
            
            Destroy(Vach);//Phá hủy vách chứa những viên đá bên trên
            
            gm.WarningText.text = ("Cảnh báo có đá rơi !!!");//Đồng thời xuất hiện cảnh báo trên màn hình
            sound.Playsound("stone");
        }
    }
	private void OnTriggerExit2D(Collider2D col)//Nếu người chơi đi ra khỏi biển báo thì sẽ mất cảnh báo
	{
		if (col.CompareTag("Player"))
		{
			
			gm.WarningText.text = ("");
		}
	}
}
