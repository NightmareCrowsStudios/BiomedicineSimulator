using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raio : MonoBehaviour
{
    float distance = 2f;
    //public Animator animMove;
    //public GameObject chave; 
    //public static bool looking;


    //float timeAnimation;
    //float timeAnimationFinal = 1f;
    //public bool activeTimeAnimation;
    //public static bool activeAction;

    //bool pegouItem;
    //float timePegouItem;
    //float timePegouItemFinal = 0.4f;

    //public static bool key;

    void Start()
    {
        
    }
    void Update()
    {


      /*if(activeTimeAnimation)
      {
        timeAnimation += Time.deltaTime;
        if(timeAnimation >= timeAnimationFinal)
        {
          activeAction = true;
          timeAnimation = 0;
          activeTimeAnimation = false;
        }
      }

      if(pegouItem)
      {
        timePegouItem += Time.deltaTime;
        if(timePegouItem >= timePegouItemFinal)
        {
            chave.SetActive(true);
            pegouItem = false;
            timePegouItem = 0;
        }
      }*/

      

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
          RaycastHit hit = new RaycastHit();
          Vector3 dir = transform.TransformDirection(Vector3.forward);

          if(Physics.Raycast(transform.position,dir,out hit,distance))
          {
            if(hit.collider.gameObject.tag == "balao")
            {
                //animMove.Play("pegarItens");
                Destroy(hit.collider.gameObject);
                //pegouItem = true;
                //key = true;
                //chave.SetActive(true);
            }
          }
        }
    }
}
