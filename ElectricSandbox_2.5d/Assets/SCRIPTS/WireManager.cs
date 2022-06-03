using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class WireManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject currentObject;
    private Vector3 pos;
    private RaycastHit hit;
    public bool lmbDown = false;
    public bool rmbDown = false;
    public Vector3 mousePosition;
    public float gridSize;
    //bool gridOn = true;
    public bool canPlace = true;
    bool selectOutput = false;
    bool selectInput = false;
    [SerializeField] private Toggle gridToggle;

    public GameObject gate;

    public GameObject wirePrefab;


    public Canvas wireCanvas;

    public ElectricObject selectedOutput;
    public ElectricObject selectedInput;
 



    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Mouse.current.position.ReadValue());
    }

    public void StartWireDraw()
    {
        selectOutput = true;
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
           // Debug.Log("RMBD");
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
        if (currentObject != null)
        {

            MovementUpdate();
        }

        if (lmbDown && selectOutput)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage    
                if (hit.collider.gameObject.CompareTag("Output"))
                {

                    ElectricObject z = hit.collider.gameObject.GetComponentInParent<ElectricObject>();
                    selectedOutput = z;
                    Debug.Log("Hit an output");
                    
                    PlaceStart();
                }
            }
        }
        if (lmbDown && selectInput)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage    
                if (hit.collider.gameObject.CompareTag("Input"))
                {

                    ElectricObject z = hit.collider.gameObject.GetComponentInParent<ElectricObject>();
                    selectedInput = z;
                    Debug.Log("Hit an input");
                    PlaceEnd();
                }
                if (hit.collider.gameObject.CompareTag("Gate"))
                {

                    ElectricObject z = hit.collider.gameObject.GetComponentInParent<ElectricObject>();
                    selectedInput = z;
                    Debug.Log("Hit a gate");
                    gate = hit.collider.gameObject;
                    PlaceEnd();
                }
            }
        }
        makeConnection();
        mousePosition = Mouse.current.position.ReadValue();
    }

    private void makeConnection()
    {
        if(selectedInput != null)
        {
            if (selectedOutput != null)
            {
                selectedOutput.outputs.Add(selectedInput.gameObject);
                selectedInput.inputs.Add(selectedOutput.gameObject);
               // drawConnection(selectedInput.gameObject, selectedOutput.gameObject);
                if (gate != null)
                {
                    drawConnection(gate, selectedOutput.gameObject);
                }
                else
                {
                    drawConnection(selectedInput.gameObject, selectedOutput.gameObject);
                }
                Debug.Log("Connected output to input");
                selectedOutput = null;
                selectedInput = null;
            }
        }
    }

    public void drawConnection(GameObject first, GameObject second)
    {
        GameObject wire = GameObject.Instantiate(wirePrefab);
        selectedOutput.wires.Add(wire);
        selectedInput.wires.Add(wire);
        LRWireDrawer lr = wire.GetComponent<LRWireDrawer>();
       
        lr.setRootPosition(second.GetComponent<ElectricObject>().opos.transform.position);

        lr.setEndPosition(first.GetComponent<ElectricObject>().ipos.transform.position);
        if(gate != null)
        {
            lr.setEndPosition(gate.transform.position);
        }
        else
        {
            lr.setEndPosition(first.GetComponent<ElectricObject>().ipos.transform.position);
        }



    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void MovementUpdate()
    {
        if (selectOutput)
        {
            currentObject.transform.position = pos;
        } else if (selectInput)
        {
            currentObject = null; //TEMP
        }
    }
    public void SelectObject(int index)
    {
        selectOutput = true;
        currentObject = Instantiate(objects[index], pos, transform.rotation);
    }
    public void PlaceObject()
    {
        currentObject = null;

    }
    public void PlaceStart()
    {
        selectOutput = false;
        selectInput = true;
    }
    public void PlaceEnd()
    {
        selectOutput = false;
        selectInput = false;
    }


    float RoundToGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
