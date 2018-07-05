using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class CameraFollow : MonoBehaviour
{
    #region Variabler
    [SerializeField]
    GameObject _player;

    Vector3 _offset;
    #endregion

    #region Metoder
    void Start()
    {
        _offset = transform.position - _player.transform.position; //Räknar ut offset värdet genom att ta differensen mellan spelarensposition och kameransposition
    }

    void LateUpdate() //Sätter kameransposition till samma som spelarensposition fast med uträknad offset
    {
        transform.position = _player.transform.position + _offset;
    }
    #endregion
}
