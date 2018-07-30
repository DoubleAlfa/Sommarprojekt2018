using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class DeathZone : MonoBehaviour
{
    #region Variabler
    GameManager _gm;
    #endregion

    #region Metoder

    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other) //Ifall spelaren faller ner för långt från spelplanen
    {
        if (other.gameObject.tag == "Player")
        {
            _gm.SceneSettings(1);
        }
    }
    #endregion


}
