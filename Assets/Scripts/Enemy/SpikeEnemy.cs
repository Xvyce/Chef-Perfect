using UnityEngine;
using System.Collections;

public class SpikeEnemy : MonoBehaviour
{
	private Health player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			player.TakeDamage(3);
		}
	}

}

