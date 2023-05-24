using UnityEngine;

public class CoinBonus : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter2D(Collider2D col)
    {
        IBonusCollector collector = col.GetComponent<IBonusCollector>();
        if (collector != null)
        {
            collector.Collect(_value);
            Destroy(gameObject);
        }
    }
}