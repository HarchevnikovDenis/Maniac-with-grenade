using UnityEngine;

// FROM: Unity в действии. Мультиплатформенная разработка на C# (Джозеф Хокинг)
public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivityHor;
    [SerializeField] private float sensitivityVert;
    
    private const float MIN_VERT = -45.0f;
    private const float MAX_VERT = 45.0f;
    
    private float rotationX;
    private float rotationY;

    private new Transform transform;

    private void Awake()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    public void RotateToMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        rotationX = Mathf.Clamp(rotationX, MIN_VERT, MAX_VERT);

        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
