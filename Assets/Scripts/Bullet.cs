using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private uint damage = 10;
	[SerializeField] private float lifeTimeInSeconds = 3f;

	private void Update()
	{
		if (lifeTimeInSeconds < 0)
			Destroy(gameObject);
		
		transform.position += transform.right * (speed * Time.deltaTime);
		lifeTimeInSeconds -= Time.deltaTime;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			collision.gameObject.GetComponent<Meteor>().ApplyDamage(damage);
			Destroy(gameObject);
		}
	}
}
