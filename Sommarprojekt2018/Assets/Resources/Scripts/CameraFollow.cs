using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class CameraFollow : MonoBehaviour
{
    //Script som hanterar kamerans rörelsemönster efter spelaren

    #region Variabler

    [SerializeField]
    GameObject _player;

    Vector3 _offset;

    float _smoothTime = 0.2F;

    Vector3 _velocity = Vector3.zero;
    #endregion

    #region Metoder
    void Start()
    {
        _offset = transform.position - _player.transform.position; //Räknar ut offset värdet genom att ta differensen mellan spelarensposition och kameransposition
    }

    void Update() //Sätter kameransposition till samma som spelarensposition fast med uträknad offset
    {
        transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position + _offset, ref _velocity, _smoothTime);
    }

    #endregion
}
