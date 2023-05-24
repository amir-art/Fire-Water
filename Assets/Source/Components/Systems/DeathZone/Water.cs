using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.GetComponent<Player>();
        if(player != null && !player._isWaterProtected)
        {
            player.OnDeath();
            return;
        }
		
        DestroyableItem item = other.GetComponent<DestroyableItem>();
        if(item != null)
        {
            item.DestoryItem();
            return;
        }
    } 
}
