using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletGameObject;
    
    private GameObject playerGameObject;

    private void Awake()
    {
        playerGameObject = this.gameObject;
    }

    private void Update()
    {
        RotatePlayerToMouse();
        
        if (Input.GetMouseButtonDown(0))
            ShootBullet();
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
        Instantiate(bulletGameObject, playerGameObject.transform.position, playerGameObject.transform.rotation);
    }
}
