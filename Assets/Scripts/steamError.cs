using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class steamError : MonoBehaviour, IPointerEnterHandler
{
    public GameObject ErrorMsg, RetryButton;


    public void OnPointerEnter(PointerEventData eventData)
    {
        print("test");
        ErrorMsg.SetActive(true);
        RetryButton.SetActive(true);
    }
}
