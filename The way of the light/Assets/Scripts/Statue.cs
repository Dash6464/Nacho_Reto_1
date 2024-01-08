using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public float resetcont;
    public GameObject _Arrow;
    public Arrow arrow;
    public bool isLeft;
    private float cont;
    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
        {
            arrow.isLeft = true;
        }
        else
        {
            arrow.isLeft = false;
        }
        if (cont >= resetcont)
        {
            if (isLeft)
            {
                Instantiate(_Arrow, new Vector3(transform.position.x - 1f, transform.position.y + 1.6f, transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(_Arrow, new Vector3(transform.position.x + 1f, transform.position.y + 1.6f, transform.position.z), Quaternion.identity);
            }
            cont = 0;
        }
        else
        {
            cont += Time.deltaTime;
        }
    }
}
