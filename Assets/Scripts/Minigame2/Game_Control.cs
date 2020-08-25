using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;


//Hacer que los 9 niveles pasen por este código. Poner un tutorial. 

public class Game_Control : MonoBehaviour
{
    GameObject token;
    List<int> faceindexes = new List<int> {0, 0, 0, 0, 1, 1, 1, 1};
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    public int[] visibleFaces = { -1, -2 };

    GameObject[] list;
    public Sprite back;
    public GameObject first;

    public int matches = 0;
    public int TotalMatches;

    //Quizá no poner esto en el Start y llamarlo a cada nivel. Poner un faceindexes para cada nivel.
    //Poner la posición inicial para las cartas en función de la cantidad de ellas.
    //Limpiar visibleFaces una vez se cambie de nivel.

    void Start()
    {
        //Puedo obligar a que el toquen original esté en una posición concreta. 6 1.5 con 8.
        int originalLength = faceindexes.Count;
        TotalMatches = originalLength / 2;
        float yPosition = 1.5f;
        float xPosition = -6f;
        for (int i = 0; i < originalLength - 1; ++i)
        {
            shuffleNum = rnd.Next(0, faceindexes.Count);
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition = xPosition + 4;
            //Esto solo esta preparado para 2 filas de cartas.
            if (i == originalLength / 2 - 2)
            {
                yPosition = -2f;
                xPosition = -6f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceindexes[0];

        //Cojo todos los GameObjects de la partida y los pongo en un array.
        list = GameObject.FindGameObjectsWithTag("Carta");
    }

    public bool TwoCardsUp()
    {
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            return true;
        }
        return false;
    }

    public void AddVisibleFace(int index)
    {
        if(visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }

        else if(visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }

        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        if(visibleFaces[0] == visibleFaces[1])
        {
            //FindObjectOfType<AudioManagerScript>().PlaySound("Campanilla");
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            ++matches;
            return true;
        }

        return false;
    }

    public bool NoMatch()
    {
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0 && visibleFaces[0] != visibleFaces[1])
        {
            return true;
        }

        return false;
    }

    public void clean()
    {
        foreach(GameObject card in list)
        {
            if(card.GetComponent<MainToken>().matched == false)
            {
               card.GetComponent<SpriteRenderer>().sprite = back;
            }
        }
        visibleFaces[0] = -1;
        visibleFaces[1] = -2;
    }

    public void firstMatched()
    {
        first.GetComponent<MainToken>().matched = true;
        first.GetComponent<MainToken>().isDissolving = true;
    }

    public void CompleteLevel()
    {
        //FindObjectOfType<AudioManager>().PlaySound("Aplausos");

        //Al activar "completeLevelUI" se dispara su transición y esta activa el cambio de escena al final.
        //completeLevelUI.SetActive(true);

        //Volver al "menu" de niveles.

        Debug.Log("Congrats!");

    }

    public void Start00()
    {
        //Puedo obligar a que el toquen original esté en una posición concreta. (x = 5)
        int originalLength = faceindexes.Count;
        TotalMatches = originalLength / 2;
        float yPosition = 1.5f;
        float xPosition = -5f;
        for (int i = 0; i < originalLength - 1; ++i)
        {
            shuffleNum = rnd.Next(0, faceindexes.Count);
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition = xPosition + 5;
            //Esto solo esta preparado para 2 filas de cartas.
            if (i == originalLength / 2 - 2)
            {
                yPosition = -2f;
                xPosition = -5f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceindexes[0];

        //Cojo todos los GameObjects de la partida y los pongo en un array.
        list = GameObject.FindGameObjectsWithTag("Carta");
    }

    public void Start01()
    {
        //Poner en una posición concreta el token original 8 1.5 con 10 limites.
        int originalLength = faceindexes.Count;
        TotalMatches = originalLength / 2;
        float yPosition = 1.5f;
        float xPosition = -8f;
        for (int i = 0; i < originalLength - 1; ++i)
        {
            shuffleNum = rnd.Next(0, faceindexes.Count);
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition = xPosition + 4;
            //Esto solo esta preparado para 2 filas de cartas.
            if (i == originalLength / 2 - 2)
            {
                yPosition = -2f;
                xPosition = -8f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceindexes[0];

        //Cojo todos los GameObjects de la partida y los pongo en un array.
        list = GameObject.FindGameObjectsWithTag("Carta");
    }

    public void Start02()
    {
        //Colocar el original en la posición 5 -4.5 y 16 cartas.
        int originalLength = faceindexes.Count;
        TotalMatches = originalLength / 2;
        float yPosition = 4.5f;
        float xPosition = -5f;
        for (int i = 0; i < 3; ++i)
        {
            shuffleNum = rnd.Next(0, faceindexes.Count);
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition = xPosition + 5;
        }
        yPosition = 1.5f;
        xPosition = -8f;
        for (int i = 0; i < originalLength - 6; ++i)
        {
            shuffleNum = rnd.Next(0, faceindexes.Count);
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition = xPosition + 4;
            //Esto solo esta preparado para 2 filas de cartas.
            if (i == originalLength / 2 - 4)
            {
                yPosition = -1.5f;
                xPosition = -8f;
            }
        }
        yPosition = -4.5f;
        xPosition = -5f;
        for (int i = 0; i < 2; ++i)
        {
            shuffleNum = rnd.Next(0, faceindexes.Count);
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition = xPosition + 5;
        }

        token.GetComponent<MainToken>().faceIndex = faceindexes[0];

        //Cojo todos los GameObjects de la partida y los pongo en un array.
        list = GameObject.FindGameObjectsWithTag("Carta");
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
    }
}