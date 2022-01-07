using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    public float speed = 2f;
    public Animator anim;

    
    void Start()
    {
        StartCoroutine(Eat());
        StartCoroutine(MoveChicken());
    }
    
    IEnumerator MoveChicken()
    {  
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            anim.SetBool("Turn Head", false);
            anim.SetBool("Run", true);
            while (transform.position.z < 6)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
                yield return null;
            }
            anim.SetBool("Run", false);
            anim.SetBool("Turn Head", true);
            yield return new WaitForSeconds(5f);
            
            transform.Rotate(Vector3.up * 180f);
            anim.SetBool("Turn Head", false);
            
            anim.SetBool("Run", true);
            while (transform.position.z > 0)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
                yield return null;
            }
            
            anim.SetBool("Run", false);
            StartCoroutine(Eat());
             
            yield return new WaitForSeconds(5f);
            transform.Rotate(Vector3.up * 180f);
            anim.SetBool("Turn Head", true);
            
        }
    }


    IEnumerator Eat()
    {
        anim.SetBool("Eat", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Eat", false);
        anim.SetBool("Turn Head", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Turn Head", false);
    }
    
    
}
