using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject stone;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (ItemCollector.foodCollected == 10)
        {
            //anim.SetTrigger("finish");
            stone.SetActive(false);
        }
    }
}
