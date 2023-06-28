using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamemaster : MonoBehaviour
{
    public int Points = 0;
    public int Lives = 3;

    public PlayerController player;
    public Text pointtext,livestext,inputtext,WarningText,Endtext;  
    /*public bool gameover;*/
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		if (PlayerPrefs.HasKey("Point"))
		{
			Scene ActiveScreen = SceneManager.GetActiveScene();
			if (ActiveScreen.buildIndex == 1)//nếu có 1 scene 
			{
				PlayerPrefs.DeleteKey("Point");//xóa key poinq
				Points = 0;//
			}
			else
				Points = PlayerPrefs.GetInt("Point");//lưu point vào bộ nhớ
			
		}

	}
    void Update()
    {
        
        PlayerPrefs.SetInt("Point",Points);
        pointtext.text = ("Coins:x " + Points);//In số Coin ra màn hình
        livestext.text = ("Lives:x " + player.Lives);//In số mạng ra màn hình

    }
    public void UpdateLives(int livechange)
    {
            player.Lives -= livechange;    //Khi người chơi hết máu thì sẽ trừ đi 1 mạng   
    }
    
    
}
