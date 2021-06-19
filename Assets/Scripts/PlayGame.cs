using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    private string eleccion;
    private Animator animator;
    public Button buttonT, buttonH, buttonOtravez;
    public GameObject textDisplay, textGanador;
    [SerializeField] AudioClip WinSFX;
    [SerializeField] [Range(0,1)] float WinSFXVolume;

    public void ElegirTails()
    {
        eleccion = "T";
        Resultado();
    }
    public void ElegirHeads()
    {
        eleccion = "H";
        Resultado();
    }

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }
    
    System.Random rd = new System.Random();
    private void Resultado()
    {
        buttonT.GetComponent<Button>().interactable = false;
        buttonH.GetComponent<Button>().interactable = false;
        AudioSource.PlayClipAtPoint(WinSFX, Camera.main.transform.position, WinSFXVolume);
        int coin = rd.Next(0, 2);
        
        if(coin == 1){
            textDisplay.GetComponent<Text>().text = "Gana: Tail";
            animator.SetBool("GanaTail", true);  
            if(eleccion=="T")
            {
                textGanador.GetComponent<Text>().text = "Ganaste!";
            }
            else
            {
                textGanador.GetComponent<Text>().text = "Perdiste!";
            }
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "Gana: Head";
            animator.SetBool("GanaHead", true);
            if(eleccion=="H")
            {
                textGanador.GetComponent<Text>().text = "Ganaste!";
            }
            else
            {
                textGanador.GetComponent<Text>().text = "Perdiste!";
            }
        }
        buttonOtravez.gameObject.SetActive(true);
    }

    public void Otravez()
    {
        buttonT.GetComponent<Button>().interactable = true;
        buttonH.GetComponent<Button>().interactable = true;
        buttonOtravez.gameObject.SetActive(false);
        animator.SetBool("GanaHead", false);
        animator.SetBool("GanaTail", false);
        textGanador.GetComponent<Text>().text = "";
        textDisplay.GetComponent<Text>().text = "Gana: ";
    }
}
