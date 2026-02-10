using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Animator animator;
    private bool isZoomed = false;

    public AudioSource Zoom;
    public AudioSource BackZoom;

    public MovePlayerScript MovePlayerScript;
    private float sensitivity;

    void Start()
    {
        animator = GetComponent<Animator>();
        sensitivity = MovePlayerScript.RotationSercetivity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))  // ЛКМ
        {
            ToggleZoom();
        }
    }

    public void ToggleZoom()
    {
        if (isZoomed)
        {
            animator.SetTrigger("BackZoom");  // ОТДАЛИТЬ
            isZoomed = false;
            BackZoom.Play();
            MovePlayerScript.RotationSercetivity = MovePlayerScript.RotationSercetivity * 2;
        }
        else
        {
            animator.SetTrigger("Zoom");      // ПРИБЛИЗИТЬ
            isZoomed = true;
            Zoom.Play();
            MovePlayerScript.RotationSercetivity = MovePlayerScript.RotationSercetivity/2;
        }
    }
}
