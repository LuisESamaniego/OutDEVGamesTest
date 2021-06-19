using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Verificar : MonoBehaviour
{
    private string textinput;
    private string textoutput;
    private int countnum;
    private int countlet;
    public GameObject inputField;
    public GameObject textDisplay;
    private char[] vector;
    MatchCollection matches;
    Regex regex;


    public void StoreName()
    {
        textoutput = "";
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
            string valor;
            
                for (int i = 0; i < textinput.Length; i++) { 
                    vector[i] = textinput[i]; 
                } 
            
            if(countnum==countlet)
            {
                //El primero es Numero o Letra
                if(Regex.IsMatch(vector[0].ToString(), @"^[0-9]+$"))
                {
                    valor = "N";
                }
                else
                {
                    valor = "L";
                }
                textoutput = vector[0].ToString();

                for (int x = 0; x < vector.Length-1; x++)
                {
                    //Numeros
                    if(valor=="L")
                    {
                        if(Regex.IsMatch(vector[x].ToString(), @"^[0-9]+$"))
                        {
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "N";
                        }
                        else
                        {
                            int contadorY = x;
                            bool encontrado = true;
                            string temporal;
                            //Buscador
                            do
                            {
                                if(Regex.IsMatch(vector[contadorY].ToString(), @"^[0-9]+$"))
                                {
                                    temporal = vector[contadorY].ToString();
                                    for (int z = x; z >= x; z--)
                                    {
                                        vector[contadorY] = vector[contadorY-1];
                                    }
                                    vector[x] = temporal[0];
                                    encontrado = false;
                                }
                                contadorY++;
                            } while(encontrado);
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "N";
                        }
                    }
                    else
                    {
                        //Letras
                        if(Regex.IsMatch(vector[x].ToString(), @"^[0-9]+$"))
                        {
                            int contadorY = x;
                            bool encontrado = true;
                            string temporal;
                            //Buscador
                            do
                            {
                                contadorY++;
                                if(Regex.IsMatch(vector[contadorY].ToString(), @"^[0-9]+$"))
                                {
                                    
                                }
                                else
                                {
                                    temporal = vector[contadorY].ToString();
                                    for (int z = x; z >= x; z--)
                                    {
                                        vector[contadorY] = vector[contadorY-1];
                                    }
                                    vector[x] = temporal[0];
                                    encontrado = false;
                                }
                            } while(encontrado);
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "L";
                        }
                        else
                        {
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "L";
                        }
                    }
                    Debug.Log(""+x);
                }
                //output
                textDisplay.GetComponent<Text>().text = textoutput;
            }
            else
            {
                //Cual es el dominante? Numeros o letras
                if(countlet < (countnum))
                {
                    valor = "L";
                }
                else
                {
                    valor = "N";
                }

                for (int x = 0; x < vector.Length; x++)
                {
                    //Numeros
                    if(valor=="L")
                    {
                        if(Regex.IsMatch(vector[x].ToString(), @"^[0-9]+$"))
                        {
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "N";
                        }
                        else
                        {
                            int contadorY = x;
                            bool encontrado = true;
                            string temporal;
                            //Buscador
                            do
                            {
                                if(Regex.IsMatch(vector[contadorY].ToString(), @"^[0-9]+$"))
                                {
                                    temporal = vector[contadorY].ToString();
                                    for (int z = x; z >= x; z--)
                                    {
                                        vector[contadorY] = vector[contadorY-1];
                                    }
                                    vector[x] = temporal[0];
                                    encontrado = false;
                                }
                                contadorY++;
                            } while(encontrado);
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "N";
                        }
                    }
                    else
                    {
                        //Letras
                        if(Regex.IsMatch(vector[x].ToString(), @"^[0-9]+$"))
                        {
                            int contadorY = x;
                            bool encontrado = true;
                            string temporal;
                            //Buscador
                            do
                            {
                                contadorY++;
                                if(Regex.IsMatch(vector[contadorY].ToString(), @"^[0-9]+$"))
                                {
                                    
                                }
                                else
                                {
                                    temporal = vector[contadorY].ToString();
                                    for (int z = x; z >= x; z--)
                                    {
                                        vector[contadorY] = vector[contadorY-1];
                                    }
                                    vector[x] = temporal[0];
                                    encontrado = false;
                                }
                            } while(encontrado);
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "L";
                        }
                        else
                        {
                            textoutput = textoutput + "" + vector[x].ToString();
                            valor = "L";
                        }
                    }
                    Debug.Log(""+x);
                }
                //output
                textDisplay.GetComponent<Text>().text = textoutput;
            } 
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "";
        }
    }
}
