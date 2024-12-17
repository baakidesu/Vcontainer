using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class MessagePrinter : MonoBehaviour
{
    private MessageService mService;
    [Inject]
    public void Construct(MessageService mS)
    {
        mService = mS;
    }
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(mService.GetMessage());
            Debug.Log(mService.currentTime);
        }
    }
}
