using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletGameObject;
    [SerializeField] private float shootingCooldown = 0.5f;
    
    private GameObject playerGameObject;
    private float timeSinceLastShot = 0;
    private int power = 1;

    private void Awake()
    {
        playerGameObject = this.gameObject;
    }

    private void Update()
    {
        RotatePlayerToMouse();
        
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timeSinceLastShot >= shootingCooldown)
        {
            ShootBullet();
            timeSinceLastShot = 0;
        }
    }

    private void RotatePlayerToMouse()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        var x =  mousePosition.x;
        var y =  mousePosition.y;
        
        var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        playerGameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void ShootBullet()
    {
        bulletGameObject.GetComponent<Bullet>().SetDamage(power + 9);
        Instantiate(bulletGameObject, playerGameObject.transform.position, playerGameObject.transform.rotation);
    }

    public int IncreasePower()
    {
        return ++power;
    }

    public int GetPower()
    {
        return power;
    }
}
