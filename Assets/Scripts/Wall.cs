using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 50;
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(123, 231, -323), speed * Time.deltaTime);
        if (gameObject.transform.localPosition== new Vector3(123, 231, -323) ) 
        {
            if (ifClear())
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, 350);
                CreateShape();
                ChangeFixedObject();
                ChangeMovableCube();
            }
            else 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    
    }

    public void CreateShape()
    {

    }

    public void ChangeFixedObject()
    {

    }

    public void ChangeMovableCube()
    {

    }

    public Boolean ifClear()
    {
        return false;
    }

}
