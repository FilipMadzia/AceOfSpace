using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletGameObject;
    [SerializeField] private float shootingCooldown = 0.3f;
    
    public EventHandler OnDamageReceived;

    private float timeSinceLastShot = 0;
    private bool canShoot = true;

    private void Update()
    {
        RotateToMouse();
        HandleShooting();
    }

    private void HandleShooting()
    {
        timeSinceLastShot += Time.deltaTime;
        
        if (timeSinceLastShot >= shootingCooldown)
            canShoot = true;
        
        if (canShoot && Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletGameObject, transform.position, transform.rotation);
            
            canShoot = false;
            timeSinceLastShot = 0;
        }
    }

    private void RotateToMouse()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mousePositionRelativeToPlayer = mousePosition - transform.position;
        
        var x = mousePositionRelativeToPlayer.x;
        var y = mousePositionRelativeToPlayer.y;
        
        var angleInDeg = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleInDeg, Vector3.forward);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            OnDamageReceived.Invoke(this, EventArgs.Empty);
        }
    }
}
