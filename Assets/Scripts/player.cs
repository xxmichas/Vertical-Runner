using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    Transform groundCheck;

    private bool jumped;

    private int currentlevel;
    public Transform level0;
    public Transform level1;
    public Transform level2;

    // Start is called before the first frame update
    void Start()
    {
        jumped = false;
        currentlevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!colision.pause)
        {
            if (Input.GetKey("w") && !jumped || Input.GetKey("up") && !jumped)
            {
                if (currentlevel == 0)
                {
                    this.transform.position = level1.transform.position;
                    jumped = true;
                    currentlevel = 1;
                }
                else
                {
                    if (currentlevel == 1)
                    {
                        this.transform.position = level2.transform.position;
                        jumped = true;
                        currentlevel = 2;
                    }
                }
            }

            if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
            {
                jumped = false;
            }

            if (Input.GetKey("s") && !jumped || Input.GetKey("down") && !jumped)
            {
                if (currentlevel == 1)
                {
                    this.transform.position = level0.transform.position;
                    jumped = true;
                    currentlevel = 0;
                }
                else
                {
                    if (currentlevel == 2)
                    {
                        this.transform.position = level1.transform.position;
                        jumped = true;
                        currentlevel = 1;
                    }
                }
            }

            if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
            {
                jumped = false;
            }
        }
    }
}
