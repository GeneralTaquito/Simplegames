using NUnit.Framework.Internal;
using UnityEditor.Build.Content;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using JetBrains.Annotations;

public class Dog_Script : MonoBehaviour
{
    //Sound
    public AudioSource AS;
    public AudioClip[] Barks;

    //sprites
    public SpriteRenderer SR;
    public Sprite cheerful;
    public Sprite normal;

    //Food System
    public Food_script food_script;
    public int maxHunger = 100;
    public int CurrentHunger;
    public Bowl_Script Bowlisfull;
    public bool Nothungry;

    //Movement
    public float Speed = 2f;
    public float goingX;
    public Vector3 Dest;
    public Vector3 startpos;
    public Vector3 Bowldes;
    public Vector3 Rotate = new Vector3(0f, 0f, 0f);

    void Start()
    {
        //Hunger stuff
        CurrentHunger = maxHunger;
        food_script.HungerMax(maxHunger);
        InvokeRepeating("Starve", 0f, 3f);

        //Move stuff
        startpos = transform.position;
        Dest.y = startpos.y;
        Bowldes.y = startpos.y;
        goingX = Random.Range(-7, 7);
        Dest.x = goingX;
        Bowldes.x = 7;

        //Food stuff
        Bowlisfull.BowlFull += gotoFood;
        Nothungry = true;
    }
    void Update()
    {
        // TLDR: random movement every moment and once the bowl is full the dog will move towards the bowl 
        // then the dog will eat some food and resume its randomized pathing 
        if (Nothungry)
        {
            if (transform.position == Dest)
            {
                goingX = Random.Range(-7, 7);
                Dest.x = goingX;
                transform.Rotate(0, 180, 0);
            }
            else if (transform.position != Dest)
            {
                transform.position = Vector3.MoveTowards(transform.position, Dest, Speed * Time.deltaTime);
            }
        }
        else if (Nothungry == false)
        {
            Debug.Log("walking");
            if (transform.position != Bowldes)
            {
                transform.localEulerAngles = Rotate;
                transform.position = Vector3.MoveTowards(transform.position, Bowldes, Speed * Time.deltaTime);
            }
            else
            {
                CurrentHunger += 20;
                Benormal();
            }
            food_script.HungerValue(CurrentHunger);
        }


        // Dying
        if (CurrentHunger == 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    // Clicking makes the dog bark and gives it a happy facial expression
    public void OnMouseDown()
    {
        AudioClip randomclip = Barks[Random.Range(0, 4)];
        AS.PlayOneShot(randomclip);
        SR.sprite = cheerful;
        StartCoroutine(NoCheer());
    }
    // It will wait after the sprite has changed to go back
    IEnumerator NoCheer()
    {
        yield return new WaitForSeconds(1);
        SR.sprite = normal;
    }

    // Stuff called in other chunks
    void Starve()
    {
        CurrentHunger -= 10;
        food_script.HungerValue(CurrentHunger);
    }
    void gotoFood()
    {
        Nothungry = false;
    }
    void Benormal()
    {
        Nothungry = true;
        Bowlisfull.Lickedclean();
    }
    

}
