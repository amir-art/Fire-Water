using UnityEngine;

[RequireComponent(typeof(Explodable))]
public class DestroyableItem : MonoBehaviour
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _shutterLifeTime;
    
    private Explodable _explodable;
    private Rigidbody2D[] _shutterRigidbodies;

    private void Awake()
    {
        _explodable = GetComponent<Explodable>();
        _shutterRigidbodies = GetComponentsInChildren<Rigidbody2D>(true);
    }
    

    public void DestoryItem()
    {
        foreach (GameObject shutter in _explodable.fragments)
        {
            Destroy(shutter, _shutterLifeTime);
        }

        if(_shutterLifeTime > 0)
        {
            _explodable.explode();
        }

        foreach (Rigidbody2D rb in _shutterRigidbodies)
        {
            rb.WakeUp();
            Vector2 attackForce = (rb.position - new Vector2(0,-1)).normalized * _attackForce;
            rb.AddForce(attackForce);
        }
    }
}