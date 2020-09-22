using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardSpeed = 8000f;
    public float lateralSpeed = 120f;

    //comand text object
    public Text commandDisplay;


    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);


        if (Input.GetKey("d"))
        {
            Command _moveRight = new MoveRight(rb, lateralSpeed);
            Invoker invoker = new Invoker();
            invoker.SetCommand(_moveRight);

            invoker.ExecuteCommand();
            //commandDisplay.text += "\n" + _moveRight.ToString();
        }

        if (Input.GetKey("a"))
        {
            Command _moveLeft = new MoveLeft(rb, lateralSpeed);
            Invoker invoker = new Invoker();
            invoker.SetCommand(_moveLeft);
            //commandDisplay.text += "\n" + _moveLeft.ToString(); 
            invoker.ExecuteCommand();
        }

        if (Input.GetKey("w"))
        {
            Command _moveUp = new MoveUp(rb, lateralSpeed);
            Invoker invoker = new Invoker();
            invoker.SetCommand(_moveUp);
            //commandDisplay.text += "\n" + _moveUp.ToString();
            invoker.ExecuteCommand();
        }

        if (Input.GetKey("s"))
        {
            //loacal _moveDown  //calling the command in commmand
            Command _moveDown = new MoveDown(rb, lateralSpeed);
            Invoker invoker = new Invoker();
            invoker.SetCommand(_moveDown);
            //commandDisplay.text += "\n" + _moveDown.ToString();
            invoker.ExecuteCommand();
        }

        if (rb.position.y < -1f)
        {

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
