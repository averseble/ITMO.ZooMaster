using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using System.Collections; 

public class PlayersPet : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _nma;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _nma = GetComponent<NavMeshAgent>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_nma.pathPending && 
            _nma.remainingDistance <= _nma.stoppingDistance && 
            (!_nma.hasPath || _nma.velocity.sqrMagnitude == 0f))
        {
            _animator.SetBool("isMoving", false);      
            _animator.SetTrigger("jump");
        }
    }

    public void goToSelectrion(Vector3 pos)
    {       
        _animator.SetBool("isMoving", true);
        Vector3 destination = pos - (pos - this.transform.position).normalized * 5;
        _nma.SetDestination(destination);
        
    }

}
