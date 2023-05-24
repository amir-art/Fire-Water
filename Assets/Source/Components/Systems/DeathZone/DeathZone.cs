using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
	{
		Player player = other.GetComponent<Player>();
		if(player != null)
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
