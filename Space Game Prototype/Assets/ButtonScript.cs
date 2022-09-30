using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    GameObject child;
    private bool showing = false;
    public TMP_Text InfoText = null;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        if(SceneManager.GetActiveScene().name == "a") {
            GetComponent<Button>().onClick.AddListener(LaunchPOI);
        }
        else GetComponent<Button>().onClick.AddListener(ShowText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchPOI(){
        InfoText.text = child.GetComponent<TMP_Text>().text;
    }

    private void OnBecameInvisible() {
        GetComponent<Image>().enabled = false;
    }

    private void OnBecameVisible() {
        GetComponent<Image>().enabled = true;
    }

    public void ShowText() {
        child.SetActive(!showing);
        showing = !showing;
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
