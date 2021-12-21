using UnityEngine;

public class RotateToHero : AggroComponent
{
    public float Speed;

    private Transform _playerTransform;
   // private IGameFactory _gameFactory;
    private Vector3 _positionToLook;

   /* private void Start()
    {
        _gameFactory = AllServices.Container.Single<IGameFactory>();
        
        if (HeroExists())
            InitializePlayerTransform();
        else
            _gameFactory.HeroCreated += InitializePlayerTransform;
    }
    */

    private void Update()
    {
        if (Initialized())
            RotateTowardsToPlayer();
    }

    private void RotateTowardsToPlayer()
    {
        UpdatePositionToLookAt();

        transform.rotation = SmoothedRotation(transform.rotation, _positionToLook);
    }

    private void UpdatePositionToLookAt()
    {
        Vector3 positionDiff = _playerTransform.position - transform.position;
        _positionToLook = new Vector3(positionDiff.x, transform.position.y, positionDiff.z);
    }

    private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) => 
        Quaternion.Lerp(rotation, TargetRotation(positionToLook), SpeedFactor());
    
    private Quaternion TargetRotation(Vector3 position) => 
        Quaternion.LookRotation(position);

    private float SpeedFactor() => 
        Speed * Time.deltaTime;

    
    private bool Initialized() =>
        _playerTransform != null;
    
  /*  private bool HeroExists() =>
        _gameFactory.HeroGameObject != null;
    
    private void InitializePlayerTransform() =>
        _playerTransform = _gameFactory.HeroGameObject.transform;
        */
}