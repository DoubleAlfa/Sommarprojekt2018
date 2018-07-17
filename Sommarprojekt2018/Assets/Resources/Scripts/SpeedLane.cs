using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class SpeedLane : MonoBehaviour
{
    #region Variabler

    [SerializeField]
    float _speedBoost;

    PlayerMovement _pm;

    #endregion

    #region Metoder

    void Start()
    {
        _pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other) //Får spelaren att springa fortare medans spelaren är i speelanen
    {
        if (other.tag == "Player")
        {
            _pm.AbleToSprint = false;
            _pm.Speed = _speedBoost;
        }
    }
    void OnTriggerExit(Collider other) //Återställer spelarens hastighet till vanlig
    {
        if (other.tag == "Player")
        {
            _pm.AbleToSprint = true;
            _pm.Speed = _pm.NormalSpeed;
        }
    }

    #endregion
}
