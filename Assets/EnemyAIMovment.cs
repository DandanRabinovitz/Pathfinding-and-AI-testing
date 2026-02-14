using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMovment : MonoBehaviour
{
    public float speed = 4;
    public float stopping_distance = 3;
    public float retreat_distance = 1;
    public Transform player;
    private float time_BTWshots;
    public float start_time_BTWshots = 2;

    public GameObject projectile;
    [SerializeField] Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        time_BTWshots = start_time_BTWshots;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Vector2.Distance(transform.position, player.position) < stopping_distance &&  Vector2.Distance(transform.position, player.position) > retreat_distance)
        {
            agent.SetDestination(transform.position);
        }
        else if(Vector2.Distance(transform.position, player.position) > stopping_distance)
        {
            agent.SetDestination(target.position);
        }

        Vector2 oppositeDirection = (transform.position - target.position).normalized;
        Vector3 goBack = transform.position + new Vector3(oppositeDirection.x, oppositeDirection.y, 0f) * Time.deltaTime * speed;
        if(Vector2.Distance(transform.position, player.position) < retreat_distance)
        {
            agent.SetDestination(goBack);
        }
        if(time_BTWshots <= 0)
        {
            Instantiate(projectile,transform.position, Quaternion.identity);
            time_BTWshots = start_time_BTWshots;
        } else {
            time_BTWshots -= Time.deltaTime;
        }
    }
}
