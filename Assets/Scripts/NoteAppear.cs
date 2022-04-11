using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteAppear : MonoBehaviour
{

    [SerializeField] public Image image;
    [SerializeField] private string textValue;
    [SerializeField] private Text textElement;
    private bool isNextToNote;
    private bool showText;
    private bool isVisibleToCamera;

    void Start()
    {
        textElement.text = textValue;
    }
    void Update()
    {
        ToggleImage();
        ToggleText();
        textElement.gameObject.SetActive(showText);
        isVisibleToCamera = GetComponent<Renderer>().isVisible;
    }


    //Player is in note range
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isNextToNote = true;
        }
    }

    // Player leaves from note range
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            image.enabled = false;
            isNextToNote = false;
            showText = false;
        }
    }

    public void ToggleImage()
    {
        if(!isVisibleToCamera)
        {
            image.enabled = false;
            return;
        }

        if (Input.GetKeyDown("e") && isNextToNote && isVisibleToCamera)
        {
            image.enabled = !image.enabled;
        }
    }

    public void ToggleText()
    {
        if (isNextToNote && isVisibleToCamera && !image.enabled)
        {
            showText = true;
        }else
        {
            showText = false;
        } 
    }

}
