using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class JumpPlatform : MonoBehaviour
{
    #region Variabler

    [SerializeField]
    float _springStrength;

    PlayerMovement _pm;

    #endregion

    #region Metoder

    void Start()
    {
        _pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _pm.MoveDirection = new Vector3(0, _springStrength, 0); //Får spelaren att hoppa högre
        }
    }
    #endregion
}
