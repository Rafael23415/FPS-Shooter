using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;

    public bool requiresKey;
    public bool reqRed, reqBlue, reqGreen;

    public GameObject areaToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(requiresKey)
            {
                if(reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    //abrir
                    doorAnim.SetTrigger("OpenDoor");
                    //spawna inimigos
                    areaToSpawn.SetActive(true);
                }

                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    //abrir
                    doorAnim.SetTrigger("OpenDoor");
                    //spawna inimigos
                    areaToSpawn.SetActive(true);
                }

                if (reqGreen && other.GetComponent<PlayerInventory>().hasGreen)
                {
                    //abrir
                    doorAnim.SetTrigger("OpenDoor");
                    //spawna inimigos
                    areaToSpawn.SetActive(true);
                }
            }
            else
            {
                //abrir
                doorAnim.SetTrigger("OpenDoor");
                //spawna inimigos
                areaToSpawn.SetActive(true);
            }

            

            
        }
    }
}
