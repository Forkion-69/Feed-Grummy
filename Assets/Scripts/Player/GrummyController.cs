using UnityEngine;

public class GrummyController : MonoBehaviour
{
    //References

    private Rigidbody2D rb;

    //value vars
    public float directionAngle;

    #region Runtime

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // Debug.Log(directionAngle);
        RotateTowardsMouse();
    }

    #endregion

    private void RotateTowardsMouse()
    {

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(InputHandler.MousePosition);

        mouseWorldPosition.z = transform.position.z; 

        Vector3 direction = mouseWorldPosition - transform.position;

        directionAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0, 0, directionAngle + 90);
    }


}


