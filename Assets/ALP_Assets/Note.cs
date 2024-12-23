
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Note : MonoBehaviour
{
    public string noteTextstr;
    public GameObject notice;
    public GameObject noteUI;
    public Text text;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        text.text = noteTextstr;
        if (Input.GetKey(KeyCode.E))
        {
            noteUI.SetActive(true);
        }
        if (Input.GetKey(KeyCode.T))
        {
            noteUI.SetActive(false);
        }
        notice.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        notice.SetActive(false);
        noteUI.SetActive(false);
    }
}

