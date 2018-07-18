using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Andreas de Freitas
public class Obstacle : MonoBehaviour
{
    //Script som hanterar hinders olika attribut.

    #region Variabler

    [SerializeField]
    [Header("Behövs endast bestämmas på Rotation obstacle")] float _rotationSpeed;
    [SerializeField]
    [Header("Behövs endast bestämmas på Disappearing obstacle")] float _timeLeft;

    float _maxTime;

    bool _rotation, _timer, _dissapearing;

    #endregion

    #region Metoder

    void Start() //Kollar vilken typ av hinder som plattformen ska tilldelas
    {
        if (gameObject.tag == "RotatingObstacle")
        {
            _rotation = true;
        }

        if (gameObject.tag == "DisappearingObstacle")
        {
            _maxTime = _timeLeft;
            _dissapearing = true;
        }
    }

    void Update()
    {
        if (_rotation) //Roterar plattformen i vald hastighet
        {
            transform.Rotate(Vector3.up * _rotationSpeed, Space.World);
        }

        if (_dissapearing && _timer)
        {
            _timeLeft -= Time.deltaTime; //Startar den nedtickande timern

            if (_timeLeft <= 0) //Ifall timern kommer ner till 0 så tas plattformen bort
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "DisappearingObstacle") //Eftersom att den endast behöver komma in i if satsen om objektet är en DisappearingObstacle
        {
            _timer = true; //Sätter timer boolen till true för att sedan börja räkna ner
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag =="DisappearingObstacle") //Eftersom att den endast behöver komma in i if satsen om objektet är en DisappearingObstacle
        {
            _timeLeft = _maxTime; //Sätter tillbaka timern till ursprungstiden ifall spelaren hoppar av plattformen
            _timer = false;
        }
    }

    #endregion



}
