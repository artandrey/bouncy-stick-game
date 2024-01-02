using System;
using System.Collections;
using UnityEngine;

public class EnemyStickScript : MonoBehaviour
{

    [Range(0,3)]
    public short moveType;

    [Range(-1,1)]
    public short rotationSide;

    [Range(0f, 5f)]
    public float rotationSpeed;
    [Range(0f, 5f)]
    public float movingSpeed;


    [Range(0f, 5f)]
    public float movingUpRange;
    [Range(0f, 5f)]
    public float movingDownRange;

    [Range(0f, 5f)]
    public float movingRightRange;
    [Range(0f, 5f)]
    public float movingLeftRange;

   
    private int sideX = 1;
    private int sideY = 1;


    delegate void MoveDelegate();

    private MoveDelegate moveMethod;

    void Awake()
    {
        switch (moveType)
        {
            case 0:
                moveMethod = MoveStay;
                break;
            case 1:
                moveMethod = MoveX;
                break;
            case 2:
                moveMethod = MoveY;
                break;
            case 3:
                moveMethod = MoveStayXY;
                break;
        }
        if(movingRightRange == 0 && movingLeftRange == 0 || movingUpRange == 0 && movingDownRange == 0)
            moveMethod = MoveStay;
    }

    void Update()
    {
        transform.Rotate((new Vector3(0f, 0f, 360f) * Time.deltaTime * rotationSpeed * rotationSide),Space.Self);
        moveMethod();
    }

    void MoveStay()
    {
        //please do anything...
        return;
        //no.
    }

    void MoveX()
    {
        if (transform.position.x >= movingRightRange)
            sideX = -1;
        else if (transform.position.x <= -movingLeftRange)
            sideX = 1;
        transform.Translate((new Vector3(movingSpeed, 0f, 0f) * Time.deltaTime * movingSpeed * sideX),Space.World);

        return;
    }

    void MoveY()
    {

        if (transform.position.y >= movingUpRange)
            sideY = -1;
        else if (transform.position.y <= -movingDownRange)
            sideY = 1;
        transform.Translate((new Vector3(0f,movingSpeed, 0f) * Time.deltaTime  * sideY), Space.World);

        return;
    }

    void MoveStayXY()
    {
        if (transform.position.x >= movingRightRange)
            sideX = -1;
        else if (transform.position.x <= -movingLeftRange)
            sideX = 1;

        if (transform.position.y >= movingUpRange)
            sideY = -1;
        else if (transform.position.y <= -movingDownRange)
            sideY = 1;

        transform.Translate((new Vector3(movingSpeed * sideX, movingSpeed * sideY, 0f) * Time.deltaTime), Space.World);

        return;
    }

   
}
