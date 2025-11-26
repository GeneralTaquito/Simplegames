using UnityEngine;

public class Dog_Script : MonoBehaviour
{
    //Misc.
    public ParticleSystem PS;
    public SpriteRenderer SR;
    public AudioSource AS;

    //Movement
    public int decideMove;
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 Dest;
    public float Speed = 2f;

    void Start()
    {
        startPos = transform.position;
        decideMove = Random.Range(1, 3);
        endPos.x = Random.Range(-3, 7);
        endPos.y = startPos.y;
        Dest = endPos;
        
    }
    void Update()
    {
        if (transform.position != Dest)
        {
            transform.position = Vector3.MoveTowards(transform.position, Dest, Speed * Time.deltaTime);
        }
        else
        {
            Dest = startPos;
        }
        //if (transform.position == endPos)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, startPos, Speed * Time.deltaTime);
        //}
    }
}
