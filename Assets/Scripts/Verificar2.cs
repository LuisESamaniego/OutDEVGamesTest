using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Verificar2 : MonoBehaviour
{
    private string textinput, textoutput;
    private int countnum,progresonum, countlet,progresolet;
    public GameObject inputField;
    public GameObject textDisplay;
    private char[] vector, vectorNum, vectorLet;
    MatchCollection matches;
    Regex regex;


    public void StoreName()
    {
        textoutput = "";
        progresolet = 0;
        progresonum = 0;
        textDisplay.GetComponent<Text>().text = "";
        textinput = inputField.GetComponent<Text>().text;
        //cuenta número de letras de la a a la z, y de la A a la Z
        regex = new Regex(@"([a-z][A-Z]*)");
        matches = regex.Matches(textinput);
        countlet = matches.Count;

        // cuenta número de dígitos
        regex = new Regex(@"([0-9])");
        matches = regex.Matches(textinput);
        countnum = matches.Count;

        //Validacion de cadena
        if(countnum==countlet || countlet == (countnum+1) ||  (countlet+1) == countnum)
        {
            //Convertir string a string[]
            vector = new char[textinput.Length]; 
            vectorNum = new char[(countnum)]; 
            vectorLet = new char[(countlet)]; 
            string valor;
            
            for (int i = 0; i < textinput.Length; i++) { 
                vector[i] = textinput[i]; 
            } 
            //Cual es el dominante? Numeros o letras
            if(countlet <= countnum)
            {
                valor = "L";
            }
            else
            {
                valor = "N";
            }
            //Separacion de letras y numeros
            for (int i = 0; i < textinput.Length; i++) { 
                if(Regex.IsMatch(vector[i].ToString(), @"^[0-9]+$"))
                {
                    vectorNum[progresonum] = vector[i];
                    progresonum++;
                }
                else
                {
                    vectorLet[progresolet] = vector[i];
                    progresolet++;
                }
            } 

            progresolet=0;
            progresonum=0;

            for (int x = 0; x < vector.Length; x++)
            {
                if(valor=="L")
                {
                    //Numeros
                    textoutput = textoutput + "" + vectorNum[progresonum].ToString();
                    progresonum++;
                    valor="N";
                } 
                else
                {
                    //Letras
                    textoutput = textoutput + "" + vectorLet[progresolet].ToString();
                    progresolet++;
                    valor="L";
                }
            }
            textDisplay.GetComponent<Text>().text = textoutput;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "";
        }
    }
}
