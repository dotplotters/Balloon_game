using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveKey : MonoBehaviour
{
    //Initialize Variables
    GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    float xmax, xmin, zmax, zmin;

    // Use this for initialization
    void Start()
    {
        xmax = 4.5f;
        xmin = -4.5f;
        zmax = 3f;
        zmin = -5f;
    }

    void Update()
    {

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if (getTarget != null)
            {
                isMouseDragging = true;
                //Converting world position to screen position.
                positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }

        //Is mouse Moving
        if (isMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

            //converting screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            
            if(currentPosition.x > xmax)
            {
                currentPosition.x = xmax;
            }
            if (currentPosition.x < xmin)
            {
                currentPosition.x = xmin;
            }
            if (currentPosition.z > zmax)
            {
                currentPosition.z = zmax;
            }
            if (currentPosition.z < zmin)
            {
                currentPosition.z = zmin; ;
            }

            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
        }


    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        if(target.tag == "key")
        {
            return target;
        }
        else
        {
            return null;
        }
    }
}