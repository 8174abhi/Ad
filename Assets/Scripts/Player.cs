using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movepeed = 5f;
    [SerializeField] private float rotatespeed = 10f;
    [SerializeField] GameInput gameInput;
    bool iswalking;

    private void Update()
    {
        Vector2 inputvector = gameInput.GetMovenentVectorNormlized();
        Vector3 movedir = new Vector3(inputvector.x, 0, inputvector.y);
        //transform.position += movedir * movepeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, movedir, rotatespeed * Time.deltaTime);
        iswalking = movedir != Vector3.zero;
        float playerradius = .7f;
        float playerheight = 2f;
        float movedistance=movepeed * Time.deltaTime;
        bool canmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerheight, playerradius, movedir, movedistance);
        if(!canmove)
        {
            Vector3 movedirx = new Vector3(movedir.x, 0, 0).normalized;
            canmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerheight, playerradius, movedirx, movedistance);
            if(canmove)
            {
                movedir = movedirx;
            }
            else
            {
                Vector3 movedirz = new Vector3(0, 0, movedir.z);
                canmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerheight, playerradius, movedirz, movedistance);
                if(canmove)
                {
                    movedir = movedirz;
                }
            }


        }
        
        if (canmove)
        {
            transform.position += movedir * movedistance;

        }


    }
    public bool Is_walking()
    {
        return iswalking;
    }
}
