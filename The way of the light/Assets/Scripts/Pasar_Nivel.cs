using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pasar_Nivel : MonoBehaviour
{
    public string escena;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(escena);
    }
}
