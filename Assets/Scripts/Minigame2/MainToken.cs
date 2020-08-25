using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    public GameObject card;
    public float waitingTime = 0.75f;

    public Animator shake;

    Material material;
    public bool isDissolving = false;
    float fade = 1f;

    public void OnMouseDown()
    {
        //Si la carta ya esta emparejada o estamos en el menú de pausa las cartas no deben interactuar.
        if(!matched)
        {
            if (spriteRenderer.sprite == back)
            {
                if(!gameControl.GetComponent<Game_Control>().TwoCardsUp())
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    gameControl.GetComponent<Game_Control>().AddVisibleFace(faceIndex);
                    matched = gameControl.GetComponent<Game_Control>().CheckMatch();

                    if (gameControl.GetComponent<Game_Control>().visibleFaces[1] == -2 && !matched)
                    {
                        gameControl.GetComponent<Game_Control>().first = card;
                    }

                    if(matched)
                    {
                        gameControl.GetComponent<Game_Control>().firstMatched();
                        isDissolving = true;
                    }
                }

                //Si he hecho todas las parejas he ganado el juego.
                if(gameControl.GetComponent<Game_Control>().matches == gameControl.GetComponent<Game_Control>().TotalMatches)
                {
                    gameControl.GetComponent<Game_Control>().CompleteLevel();
                }

                if(gameControl.GetComponent<Game_Control>().NoMatch())
                {
                    //Wait y clean().
                    StartCoroutine(Wait());
                }
            }

            else
            {
                spriteRenderer.sprite = back;
                gameControl.GetComponent<Game_Control>().RemoveVisibleFace(faceIndex);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitingTime);
        gameControl.GetComponent<Game_Control>().clean();
    }

    private void Update()
    {
        if(isDissolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            //Pongo el sprite de la Shadow a null.
            card.GetComponent<DropShadow>().shadowGameobject.GetComponent<SpriteRenderer>().sprite = null;
            material.SetFloat("_Fade", fade);
        }
    }

    private void OnMouseEnter()
    {
        if(!matched)
        {
            card.GetComponent<DropShadow>().shadowGameobject.GetComponent<SpriteRenderer>().sprite = card.GetComponent<SpriteRenderer>().sprite;
        }
        if (spriteRenderer.sprite == back)
        {
            shake.SetTrigger("Start_Shake");
        }
    }

    private void OnMouseExit()
    {
        card.GetComponent<DropShadow>().shadowGameobject.GetComponent<SpriteRenderer>().sprite = null;
        shake.SetTrigger("Stop_Shake");
    }

    private void Awake()
    {
        gameControl = GameObject.Find("GameControl");
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
    }
}