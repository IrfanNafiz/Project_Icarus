using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    GameObject child0, child1;
    private bool showing = false;
    public TMP_Text InfoText = null;
    // Start is called before the first frame update
    void Start()
    {
        
        if(SceneManager.GetActiveScene().name == "Venus Flyby") {
            GetComponent<Button>().onClick.AddListener(Fly);
            child0 = transform.GetChild(0).gameObject;
        }
        else{
            GetComponent<Button>().onClick.AddListener(ShowText);
            child0 = transform.GetChild(0).gameObject;
            child1 = transform.GetChild(1).gameObject;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fly(){
        child0.SetActive(!showing);
        showing = !showing;
    }

    private void OnBecameInvisible() {
        GetComponent<Image>().enabled = false;
    }

    private void OnBecameVisible() {
        GetComponent<Image>().enabled = true;
    }

    public void ShowText() {
        child0.SetActive(!showing);
        child1.SetActive(!showing);
        showing = !showing;
    }

    public void Deactivate() {
        child0.SetActive(false);
    }

    private void OnMouseOver() {
        child0.SetActive(true);
    }

    private void OnMouseExit() {
        child0.SetActive(false);
    }

    
    
}
