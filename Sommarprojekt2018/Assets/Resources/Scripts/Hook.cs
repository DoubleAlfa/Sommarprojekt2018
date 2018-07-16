using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Av Andreas de Freitas
public class Hook : MonoBehaviour
{

    #region Variabler

    [SerializeField]
    GameObject _player;

    [SerializeField]
    float _speed, _colliderOffset;

    [SerializeField]
    LineRenderer _lr; //Linerenderer ska simulera repet som drar in spelaren

    bool _createRope = false;

    GameObject _destination;

    PlayerMovement _pm;

    #endregion

    #region Properties 

    public GameObject Destination
    {
        get { return _destination; }
        set { _destination = value; }
    }

    public bool CreateRope
    {
        get { return _createRope; }
        set { _createRope = value; }
    }

    public LineRenderer LR
    {
        get { return _lr; }
        set { _lr = value; }
    }

    #endregion

    #region Metoder

    void Start()
    {
        _pm = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    void Update() //Skapar samt uppdaterar repets position
    {
        if (_createRope)
        {
            _lr.SetPosition(0, transform.position); //Sätter repets utgångsposition till hookpistolen
            transform.LookAt(_destination.transform); //Uppdaterar spelarens hookpistolsrotation till att titta på målets position

            _player.transform.position = Vector3.Lerp(_player.transform.position, _destination.transform.position, _speed * Time.deltaTime); //Förflyttar spelarens position till målets position i angiven hastighet

            float distanceToHook = Vector3.Distance(transform.position, _destination.transform.position); //lagrar avståndet mellan hookpistolens position och målpositionen

            if (distanceToHook <= _colliderOffset) //Ifall hookpistolen är "tillräckligt" nära målpositionen så tas repet bort och spelaren faller
            {
                _lr.enabled = false;
                _createRope = false;
            }
        }
        else
        {
            transform.rotation = Quaternion.identity; //Gör så att hookpistolensrotation återställs till att kolla rakt fram
        }
    }
}


#endregion

