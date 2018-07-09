using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Av Andreas de Freitas
public class Hook : MonoBehaviour
{

    #region Variabler

    [SerializeField]
    GameObject _rope, _player;

    [SerializeField]
    float _ropeWidth;

    bool _createRope = false;

    GameObject _destination;

    #endregion

    #region Properties 

    public GameObject Rope
    {
        get
        {
            return _rope;
        }
    }

    public GameObject Destination
    {
        get
        {
            return _destination;
        }

        set
        {
            _destination = value;
        }
    }

    public bool CreateRope
    {
        get
        {
            return _createRope;
        }

        set
        {
            _createRope = value;
        }
    }

    #endregion

    #region Metoder


    void Update() //Skapar samt uppdaterar repets position
    {
        if (_createRope)
        {
            var between = (_destination.transform.position - transform.position); //Kollar avståndet mellan "hooken" och dit spelaren "hookar"
            var distance = between.magnitude; //Räknar ut längden mellan objekten
            _rope.transform.localScale = new Vector3(_ropeWidth, _ropeWidth, distance); //Skapar repet i de angivna skalorna
            _rope.transform.position = _destination.transform.position - (between / 2.0f); //Placerar ut repet mellan spelarens "hookpistol" och objektet spelaren vill hook till

            _rope.transform.LookAt(transform.position); //Får repet att rikta sig emot "hookpistolen"
            transform.LookAt(_destination.transform.position); //Får "hookpistolen" att rikta sig emot objektet

            if (Input.GetButton("Fire2")) //Får spelaren att klättra på repet
            {
                float speed = 0.2f;
                _player.transform.position = Vector3.MoveTowards(_player.transform.position, _destination.transform.position, speed);

                if (Input.GetButtonDown("Jump")) //Tar bort repet när spelaren är i luften
                {
                    _createRope = false;
                    _rope.transform.position = new Vector3(-60, -60, -60);

                }

            }

        }
    }




}

#endregion

