using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] private string textValue;
    [SerializeField] private Text textElement;
    private bool isNextToElement;
    private bool isVisibleToCamera;
    private bool showText;
    void Start()
    {
        textElement.text = textValue;
    }
    void Update()
    {
        ToggleText();
        textElement.gameObject.SetActive(showText);
        isVisibleToCamera = GetComponent<Renderer>().isVisible;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isNextToElement = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isNextToElement = false;
            showText = false;
        }
    }

    public void ToggleText()
    {
        if (isNextToElement && isVisibleToCamera)
        {
            showText = true;
        }else
        {
            showText = false;
        } 
    }
}
