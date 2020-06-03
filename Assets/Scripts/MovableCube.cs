using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MovableCube : MonoBehaviour
{
    GameObject gameObject;
    void Start()
    {
        gameObject = GameObject.Find("MovableCube");
    }

    public void RotateRight() 
    {
        //Vector3 offset = new Vector3(gameObject.GetComponent<MeshFilter>().mesh.bounds.size.x, gameObject.GetComponent<MeshFilter>().mesh.bounds.size.x, 0);
        //Vector3 offset = new Vector3(5, 5, 0);
        //Vector3 v = gameObject.transform.position + offset;
        //gameObject.transform.RotateAround(v, Vector3.forward, 45);
        gameObject.transform.Rotate(new Vector3(0, 45, 0));

    }

    public void RotateLeft()
    {
        GameObject gameObject = GameObject.Find("MovableCube");
        gameObject.transform.Rotate(new Vector3(0, 45, 0));
    }
}
