using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MenuController1 : MonoBehaviour
{
    public GameObject Paneldlg;
    public void StartGame()
    {
        SceneManager.LoadScene("Main1");//Load m�n 1
    }
    public void StartGame2()
    {
        SceneManager.LoadScene("Main2");//Load m�n 2
    }
    public void StartLevel()
    {
        SceneManager.LoadScene("Level");//Load Level
    }
    public void LoadMenu()
	{
        
        SceneManager.LoadScene("Menu");//Load Menu
	}   
    public void GameInstructions()//Load H??ng d?n c�ch ch?i
	{
        SceneManager.LoadScene("Game Instructions");
	} 
    public void LoadDIL()
	{
        Paneldlg.SetActive(true);
	}        
}
