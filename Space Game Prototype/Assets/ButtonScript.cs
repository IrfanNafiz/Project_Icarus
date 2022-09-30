using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    GameObject child;
    private bool showing = false;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        GetComponent<Button>().onClick.AddListener(ShowText);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible() {
        GetComponent<Image>().enabled = false;
    }

    private void OnBecameVisible() {
        GetComponent<Image>().enabled = true;
    }

    public void ShowText() {
        child.SetActive(!showing);
        showing = true;
    }

    public void Deactivate() {
        child.SetActive(false);
    }

    private void OnMouseOver() {
        child.SetActive(true);
    }

    private void OnMouseExit() {
        child.SetActive(false);
    }

    
    
}
