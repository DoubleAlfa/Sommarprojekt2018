using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas 
public class IO : MonoBehaviour
{

    // Hanterar input och output (save/load)

    #region Variabler
    Vector3 _playerPos;
    GameObject hej;

    #endregion

    #region Metoder

    void Start()
    {
        _playerPos = GameObject.Find("Player").transform.position;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("xPos", _playerPos.x);
        PlayerPrefs.SetFloat("yPos", _playerPos.y);
        PlayerPrefs.SetFloat("zPos", _playerPos.z);
    }

    public void Load()
    {
        _playerPos = new Vector3(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"), PlayerPrefs.GetFloat("zPos"));
    }
    #endregion
}
