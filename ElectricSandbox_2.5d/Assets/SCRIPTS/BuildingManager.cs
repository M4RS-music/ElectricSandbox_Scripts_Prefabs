using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject currentObject;
    private Vector3 pos;
    private RaycastHit hit;
    public bool lmbDown = false;
    public bool rmbDown = false;
    public Vector3 mousePosition;
    public float gridSize;
    bool gridOn = true;
    public bool canPlace = true;
    [SerializeField] private Toggle gridToggle;

 

    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Mouse.current.position.ReadValue()); 
    }
    public void OnLMBDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            lmbDown = true;
           // Debug.Log("LMBD");
        }
        else if (context.canceled)
        {
            lmbDown = false;
           // Debug.Log("LMBU");
        }
    }
    public void OnRMBDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rmbDown = true;
         //   Debug.Log("RMBD");
        }
        else if (context.canceled)
        {
            rmbDown = false;
           // Debug.Log("RMBU");
        }
    }
    public void OnLMBUp(InputAction.CallbackContext context)
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if(currentObject != null)
        {
            
            if (gridOn)
            {
                currentObject.transform.position = new Vector3(RoundToGrid(pos.x), RoundToGrid(pos.y), RoundToGrid(pos.z));
            }
            else
            {
                currentObject.transform.position = pos;
            }
        }

        if (lmbDown && canPlace)
        {
            PlaceObject();
        }
        mousePosition = Mouse.current.position.ReadValue();
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }
    public void SelectObject(int index)
    {
        currentObject = Instantiate(objects[index], pos, transform.rotation);
    }
    public void PlaceObject()
    {
        currentObject = null;
        
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
        {
            gridOn = true;
        }
        else
        {
            gridOn = false;
        }
    }
    float RoundToGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
