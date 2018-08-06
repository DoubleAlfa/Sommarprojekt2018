using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class Boosters : MonoBehaviour
{
    //Script som har hanterar boosters i spelet, alltså speedboost och jumpboost för spelaren.

    #region Variabler

    [SerializeField]
    [Header("Behövs endast bestämmas på Speedbooster")] float _speedBoost;
    [SerializeField]
    [Header("Behövs endast bestämmas på Jumppad")] float _springStrength;

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
            if (gameObject.tag == "SpeedBoost")
            {
                _pm.AbleToSprint = false;
                _pm.Speed = _speedBoost; //Får spelaren att springa fortare medans spelaren är i speedlanen
                _pm.Boosted = true;
            }

            if (gameObject.tag == "JumpPad")
            {
                _pm.MoveDirection = new Vector3(0, _springStrength, 0); //Får spelaren att hoppa högre
            }

        }
    }
    void OnTriggerExit(Collider other) //Återställer spelarens hastighet till vanlig
    {
        if (other.tag == "Player" && gameObject.tag == "SpeedBoost") //Den behöver endast komma in i if satsen ifall det är en speedboost
        {
            _pm.AbleToSprint = true;
            _pm.Speed = _pm.NormalSpeed;
            _pm.Boosted = false;
        }
    }

    #endregion
}
