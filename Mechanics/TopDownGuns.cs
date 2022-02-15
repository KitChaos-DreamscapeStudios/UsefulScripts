using UnityEngine;

public class TopDownGunSample : MonoBehaviour{
    [Header("Settings")]
    [SerializeField] private float projectileVelocity; // travel speed of projectile
    [SerializeField] private float raycastRange; // range for raycast weapon
    [SerializeField] private bool isProjectile; // gun will be raycast if set to false

    [Header("Aiming")]
    [SerializeField] private Camera camera;
    [SerializeField] private Vector2 mousePosition;

    private void Update(){
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }
}

public class TopDownProjectileSample{

}