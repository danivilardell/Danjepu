using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Game_Control : MonoBehaviour
{
    GameObject token;
    List<int> faceindexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7};
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    public int[] visibleFaces = { -1, -2 };

    GameObject[] list;
    public Sprite back;
    public GameObject first;

    public int matches = 0;
    public int TotalMatches;
    public GameObject completeLevelUI;

    public bool OptionMenu = false;

    void Start()
    {
        int originalLength = faceindexes.Count;
        TotalMatches = originalLength / 2;
        float yPosition = 1.5f;
        float xPosition = -7f;
        for(int i = 0; i < originalLength - 1; ++i)
        {
            shuffleNum = rnd.Next(0, faceindexes.Count);
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition = xPosition + 2;
            //Esto solo esta preparado para 2 filas de cartas.
            if(i == originalLength/2 - 2)
            {
                yPosition = -1.5f;
                xPosition = -7f;
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
        completeLevelUI.SetActive(true); 

    }

    public void OptionButtonOn()
    {
        //Estoy en el menú de opciones. Triggered por botón.
        OptionMenu = true;
    }

    public void OptionButtonOff()
    {
        //Salgo del menú de opciones. Triggered por botón.
        OptionMenu = false;
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
    }
}