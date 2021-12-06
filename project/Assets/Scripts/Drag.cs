using UnityEngine;
using System;
using UnityEngine.UI;


public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Vector3 v;
    public int number;
    public Text numberOnCube;

    Singleton SingletonObject;

    void Start()
    {
        SingletonObject = Singleton.GetInstance();
        int[] arr = SingletonObject.blockPositionArray; //FindObjectOfType<GameManager>().blockPositionArray;


        number = arr[(int)transform.position.x + 3 * (int)transform.position.z];
        numberOnCube.text = number.ToString();

    }
        void OnMouseDown()
    {
        //number = GetComponent<ChangeNumber>().number;

        //mouse doesn't have z so we get the gameobject's z 
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPros();
    }

    private Vector3 GetMouseWorldPros()
    {
        //get position of mouse
        Vector3 mousePoint = Input.mousePosition;
        // give the z of gameobject to mouse point
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        v = GetMouseWorldPros() + mOffset;
        v.y = 0;
        //check block does not go out of plane
        //if (v.x < 0)
        //    v.x = 0;
        //else if (v.x > 2)
        //    v.x = 2;

        //if (v.z < 0)
        //    v.z = 0;
        //else if (v.z > 2)
        //    v.z = 2;

        v.x = (float)Math.Round(v.x);
        v.z = (float)Math.Round(v.z);
        //GameManager gm = FindObjectOfType<GameManager>();
        if (v == SingletonObject.emptyPos)
        {
            SingletonObject.NumberOfMoves++;
            
            SingletonObject.emptyPos = transform.position;
            transform.position = v;
            SingletonObject.checkWinCondition();
        }
    }

}
