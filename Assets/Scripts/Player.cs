using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    float moveValue;
    float jumpValie;
    public int[] sw = new int [3];
    public int[] vol = new int [2];
    public TextMeshProUGUI debugText;
    int [] swPre = new int [3];

    // Start is called before the first frame update
    void Start()
    {
        moveValue = 0.01f;
        jumpValie = 5f;
        debugText.text = "debug";
        sw[0] = 1;  sw[1] = 1;  sw[2] = 1;
        vol[0] = 2000;
        vol[1] = 2000;
        var current = Keyboard.current;

    }

    // Update is called once per frame
    void Update()
    {
        var current = Keyboard.current;
        if (current == null)
            return;

        if (current.rightArrowKey.isPressed)
            this.transform.position += new Vector3(moveValue, 0f, 0f);

        if (current.leftArrowKey.isPressed)
            this.transform.position += new Vector3(-moveValue, 0f, 0f);

        string str = string.Format("vol:{0} {1}, sw:{2} {3} {4}",vol[0],vol[1],sw[0],sw[1],sw[2]);
        debugText.text = str;

        if (current.rightArrowKey.isPressed || sw[0] == 0 || vol[0] > 2400)
        {
            this.transform.position += new Vector3(moveValue, 0f, 0f);
            if(vol[0] > 3000)
            {
                this.transform.position += new Vector3(moveValue * 2, 0f, 0f);
            }
        }
        if (current.leftArrowKey.isPressed || sw[1] == 0 || vol[0] < 2100)
        {
            this.transform.position -= new Vector3(moveValue, 0f, 0f);
            if (vol[0] < 1000)
            {
                this.transform.position -= new Vector3(moveValue * 2, 0f, 0f);
            }
        }
        if (current.rightArrowKey.isPressed || sw[0] == 0 || vol[1] > 2500)
        {
            this.transform.position += new Vector3(0f, 0f, moveValue);
            if (vol[1] > 3000)
            {
                this.transform.position += new Vector3(0f, 0f,moveValue * 2 );
            }
        }
        if (current.leftArrowKey.isPressed || sw[1] == 0 || vol[1] < 2200)
        {
            this.transform.position -= new Vector3(0f, 0f, moveValue);
            if (vol[1] < 1000)
            {
                this.transform.position -= new Vector3(0f, 0f, moveValue * 2);
            }
        }

        if (Keyboard.current. zKey.wasPressedThisFrame || (sw[2] == 0 && swPre[2] == 1))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpValie;
        }
        
        for (int i = 0; i < swPre.Length; i++)
            swPre[i] = sw[i];

    }
}
