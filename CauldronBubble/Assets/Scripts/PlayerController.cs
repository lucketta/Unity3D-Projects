using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float cursorPosX;
    public float cursorPosY;
    public float cursorPosZ;
    public float posZOffset = 3;

    public float playerPosX;
    public float playerPosY;
    Vector3 cursorPos;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = cursorPos;*/

        cursorPos = Input.mousePosition;
        cursorPos.z = Camera.main.nearClipPlane + posZOffset;
        cursorPosX = cursorPos.x;
        cursorPosY = cursorPos.y;
        cursorPosZ = cursorPos.z;

        transform.position = Camera.main.ScreenToWorldPoint(cursorPos);
        playerPosX = transform.position.x;
        playerPosY = transform.position.y;
    }
}