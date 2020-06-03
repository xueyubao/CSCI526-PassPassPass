using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MovableCube : MonoBehaviour
{
    GameObject gameObject;
    Boolean turnRight = false;
    Boolean turnLeft = false;
    Vector3 rotateCenter;
    Vector3[] offset = new Vector3[4] { 
        new Vector3(-5, 5, 0), 
        new Vector3(5, 5, 0),
        new Vector3(-5, -5, 0), 
        new Vector3(5, -5, 0)};
    Vector3[] cubeOffset = new Vector3[8] { 
        new Vector3(-10, 10, 0), 
        new Vector3(0, 10, 0),
        new Vector3(10, 10, 0),
        new Vector3(-10, 0, 0),
        new Vector3(10, 0, 0),
        new Vector3(-10, -10, 0),
        new Vector3(0, -10, 0),
        new Vector3(10, -10, 0)};
    Boolean[] checkExist;
    int rotateAngle;
    int checkAngle = 0;
    public Button leftButton;
    public Button rightButton;
    void Start()
    {
        gameObject = GameObject.Find("MovableCube");
    }

    
    void Update()
    {
        if (turnRight) 
        { 
            
            gameObject.transform.RotateAround(rotateCenter, Vector3.forward, -1);
            checkAngle++;
        }
        else if (turnLeft)
        {
            
            gameObject.transform.RotateAround(rotateCenter, Vector3.forward, 1);
            checkAngle++;
        }
        if (checkAngle == rotateAngle)
        {
            turnRight = false;
            turnLeft = false;
            checkAngle = 0;
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

    }

    Boolean[] GetNear()
    { 
        Boolean[] c = new Boolean[cubeOffset.Length];
        if (gameObject.transform.position.y > 14)
        {
            
            for (int i = 0; i < cubeOffset.Length; i++)
            {
                //                ray[i] = new Ray(Vector3.zero, gameObject.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(gameObject.transform.position + cubeOffset[i] + new Vector3(0, 0, -10), gameObject.transform.position + cubeOffset[i], out hit, 10))
                {
                    /*                    Debug.DrawLine(gameObject.transform.position, hit.point);*/
                    c[i] = true;
                }
                else
                {
                    c[i] = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < cubeOffset.Length - 3; i++)
            {
                RaycastHit hit;
                if (Physics.Raycast(gameObject.transform.position + cubeOffset[i] + new Vector3(0, 0, -10), gameObject.transform.position + cubeOffset[i], out hit, 10))
                {
                    c[i] = true;
                }
                else
                {
                    c[i] = false;
                }
            }
            c[5] = true;
            c[6] = true;
            c[7] = true;
        }
        return c;
    }

    int GetCenter(int[] a)
    {
        if (a[0] != 0)
        {
            return 0;
        }
        if (a[1] != 0)
        {
            return 1;
        }
        if (a[2] != 0)
        {
            return 2;
        }
        if (a[3] != 0)
        {
            return 3;
        }
        return -1;
    }

    int[] GetAngle(Boolean isRight)
    {
        int[] a = new int[4];
        if (isRight)
        {
            if (checkExist[1] && !checkExist[0] && !checkExist[3])
            {
                a[0] = 180;
            }
            else if (checkExist[1] && checkExist[0] && !checkExist[3])
            {
                a[0] = 90;
            }
            else
            {
                a[0] = 0;
            }

            if (checkExist[4] && !checkExist[2] && !checkExist[1])
            {
                a[1] = 180;
            }
            else if (checkExist[4] && checkExist[2] && !checkExist[1])
            {
                a[1] = 90;
            }
            else
            {
                a[1] = 0;
            }

            if (checkExist[3] && !checkExist[5] && !checkExist[6])
            {
                a[2] = 180;
            }
            else if (checkExist[3] && checkExist[5] && !checkExist[6])
            {
                a[2] = 90;
            }
            else
            {
                a[2] = 0;
            }

            if (checkExist[6] && !checkExist[7] && !checkExist[4])
            {
                a[3] = 180;
            }
            else if (checkExist[6] && checkExist[7] && !checkExist[4])
            {
                a[3] = 90;
            }
            else
            {
                a[3] = 0;
            }

        }
        else
        {
            if (checkExist[3] && !checkExist[0] && !checkExist[1])
            {
                a[0] = 180;
            }
            else if (checkExist[3] && checkExist[0] && !checkExist[1])
            {
                a[0] = 90;
            }
            else
            {
                a[0] = 0;
            }

            if (checkExist[1] && !checkExist[2] && !checkExist[4])
            {
                a[1] = 180;
            }
            else if (checkExist[1] && checkExist[2] && !checkExist[4])
            {
                a[1] = 90;
            }
            else
            {
                a[1] = 0;
            }

            if (checkExist[6] && !checkExist[5] && !checkExist[3])
            {
                a[2] = 180;
            }
            else if (checkExist[6] && checkExist[5] && !checkExist[3])
            {
                a[2] = 90;
            }
            else
            {
                a[2] = 0;
            }

            if (checkExist[4] && !checkExist[7] && !checkExist[6])
            {
                a[3] = 180;
            }
            else if (checkExist[4] && checkExist[7] && !checkExist[6])
            {
                a[3] = 90;
            }
            else
            {
                a[3] = 0;
            }

        }
        return a;
    }

    public void RotateRight() 
    {        
        if (turnLeft)
            return;
        leftButton.interactable = false;
        rightButton.interactable = false;
        checkExist = GetNear();
        for (int i = 0; i < checkExist.Length; i++)
        { 
            UnityEngine.Debug.Log(checkExist[i]);
        }
            
        UnityEngine.Debug.Log(GetCenter(GetAngle(true)));
        if (GetCenter(GetAngle(true))==-1)
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
            return;
        } 
        UnityEngine.Debug.Log(GetAngle(true)[GetCenter(GetAngle(true))]);
        rotateCenter = gameObject.transform.position + offset[GetCenter(GetAngle(true))];
        rotateAngle = GetAngle(true)[GetCenter(GetAngle(true))];
        turnRight = true;
        
    }

    public void RotateLeft()
    {
        if (turnRight)
            return;
        leftButton.interactable = false;
        rightButton.interactable = false;
        checkExist = GetNear();
        if (GetCenter(GetAngle(false)) == -1 )
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
            return;
        }
        rotateCenter = gameObject.transform.position + offset[GetCenter(GetAngle(false))];
        rotateAngle = GetAngle(false)[GetCenter(GetAngle(false))];
        turnLeft = true;
    }
}
