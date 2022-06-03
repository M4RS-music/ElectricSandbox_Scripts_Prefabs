using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRWireDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject root;
    public GameObject end;
    public WireManager wireManager;
    // Start is called before the first frame update
    void Start()
    {
        //wireManager = GameObject.Find("WireManager").GetComponent<WireManager>();
    }

    public void setRootPosition(Vector3 pos)
    {
        root.transform.position = pos;

    }
    public void setEndPosition(Vector3 pos)
    {
        end.transform.position = pos;
        drawConnection(root, end, 0.07f);
    }
    public void drawConnection(GameObject first, GameObject second, float linewidth)
    {

        lineRenderer.SetPosition(0, first.gameObject.transform.position);
        
        lineRenderer.SetPosition(1, second.gameObject.transform.position);

        lineRenderer.startWidth = linewidth;
        lineRenderer.endWidth = linewidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
