using NUnit.Framework.Internal;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Dog_Script : MonoBehaviour
{
    //Misc.
    public ParticleSystem PS;
    public SpriteRenderer SR;
    public AudioSource AS;

    //Movement
    public float Speed = 2f;
    public float goingX;
    public Vector3 Dest;
    public Vector3 startpos;

    void Start()
    {
        startpos = transform.position;
        Dest.y = startpos.y;
        goingX = Random.Range(-7, 7);
        Dest.x = goingX;
    }
    void Update()
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
}
