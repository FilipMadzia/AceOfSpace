using System;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private uint maxHealth = 50;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationSpeed = 12f;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private GameObject sprite;
    
    public EventHandler OnDestroyed;

    private uint health;

    private void Awake()
    {
        health = maxHealth;
    }

    private void Update()
    {
        var currentPosition = transform.position;
        var targetPosition = Vector2.zero;
        
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        sprite.transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }

    public void ApplyDamage(uint damage)
    {
        health -= damage;
        
        var healthPercentage = (float)health / maxHealth;
        healthBar.sizeDelta = new Vector2(healthPercentage * 0.5f, 0.1f);

        if (health <= 0)
        {
            Destroy(gameObject);
            OnDestroyed.Invoke(this, EventArgs.Empty);
        }
    }
}
