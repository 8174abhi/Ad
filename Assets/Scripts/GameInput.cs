using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private InputActions inputactions;
    private void Awake()
    {
         inputactions = new InputActions();
        inputactions.Enable();

    }
    public Vector2 GetMovenentVectorNormlized()
    {

        Vector2 inputvector = inputactions.PlayerMovement.Movement.ReadValue<Vector2>();
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    inputvector.x = -1;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    inputvector.x = +1;
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    inputvector.y = +1;
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    inputvector.y = -1;
        //}
        inputvector = inputvector.normalized;
        return inputvector;
    }
}
