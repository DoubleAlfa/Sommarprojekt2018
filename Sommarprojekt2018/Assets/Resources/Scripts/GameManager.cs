using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Script som hanterar olika händelser i spelet

    #region Variabler

    [SerializeField]
    Collider maxFallingDistance;

    GameObject _player;
    Scene _activeScene;
    #endregion

    #region Metoder

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _activeScene = SceneManager.GetActiveScene(); //sparar den aktiva scenen spelaren befinner sig i
    }

    public void SceneSettings(int alternative)
    {
        switch (alternative)
        {
            case 1:
                SceneManager.LoadScene(_activeScene.name); //Laddar om scenen
                break;

            case 2:
                SceneManager.LoadScene(_activeScene.buildIndex + 1); //Laddar nästa scene
                break;
        }
    }
    #endregion
}
