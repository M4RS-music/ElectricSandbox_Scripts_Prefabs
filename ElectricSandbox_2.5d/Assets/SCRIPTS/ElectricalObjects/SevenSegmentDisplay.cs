using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenSegmentDisplay : MonoBehaviour
{
    /// <summary>
    /// DEPRECATED
    /// </summary>
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;

    public bool l1on = false;
    public bool l2on = false;
    public bool l3on = false;
    public bool l4on = false;
    public bool l5on = false;
    public bool l6on = false;
    public bool l7on = false;



    public Tags tags = Tags.SSD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightUpdate();
    }

    void lightUpdate()
    {
        if (l1on)
        {
            light1.SetActive(true);
        }
        else
        {
            light1.SetActive(false);
        }

        if (l2on)
        {
            light2.SetActive(true);
        }
        else
        {
            light2.SetActive(false);
        }

        if (l3on)
        {
            light3.SetActive(true);
        }
        else
        {
            light3.SetActive(false);
        }

        if (l4on)
        {
            light4.SetActive(true);
        }
        else
        {
            light4.SetActive(false);
        }

        if (l5on)
        {
            light5.SetActive(true);
        }
        else
        {
            light5.SetActive(false);
        }

        if (l6on)
        {
            light6.SetActive(true);
        }
        else
        {
            light6.SetActive(false);
        }

        if (l7on)
        {
            light7.SetActive(true);
        }
        else
        {
            light7.SetActive(false);
        }
    }
}
