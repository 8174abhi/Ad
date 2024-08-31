using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatorscripts : MonoBehaviour
{
   
    Animator animator;
    [SerializeField] private Player player;
    private void Awake()
    {
        animator = GetComponent<Animator>();
       
    }
    private void Update()
    {
        animator.SetBool("Iswalking", player.Is_walking());
    }
}
