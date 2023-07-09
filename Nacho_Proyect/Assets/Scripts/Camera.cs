using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Link;
    // Start is called before the first frame update
    void Start()
    {
        Link = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Link.transform.position.x, Link.transform.position.y + 4.5f, -2.5f);

    }
}
