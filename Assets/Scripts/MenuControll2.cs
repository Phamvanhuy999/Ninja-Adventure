using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControll2 : MonoBehaviour
{
    private bool allowQuitting = false;
    public GameObject Paneldlg;
    public void LoadMain1()///hàm load màn chơi 1
    {
        SceneManager.LoadScene("Main1");
    }
    public void LoadMain2()//hàm load màn chơi 1;
{
        SceneManager.LoadScene("Main2");
    }
    public void LoadMenu()//hàm load màn chơi Menu
{
        SceneManager.LoadScene("Menu");
    }
  
}
