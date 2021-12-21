
using UnityEngine;
using UnityEngine.AI;

public class AgentMoveToPlayer : AggroComponent
{
    private const string PlayerTag = "Player";

    [SerializeField] private float _minimalDistance = 6;
    public NavMeshAgent Agent;
    
    private Transform _playerTransform;
    private void Start()
    {
        InitializePlayerTransform();
    }

    private void Update()
    {
        if (PlayerNotReach())
        {
            Agent.destination = _playerTransform.position;
        }
        else
        {
            Agent.transform.LookAt(_playerTransform.position);
            Agent.destination = Agent.transform.position;
        }
    }

    private void InitializePlayerTransform() =>
        _playerTransform =  GameObject.FindWithTag(PlayerTag).transform;
    
    private bool PlayerNotReach()
    {
        return Vector3.Distance(Agent.transform.position, _playerTransform.position) > _minimalDistance;
    }
}