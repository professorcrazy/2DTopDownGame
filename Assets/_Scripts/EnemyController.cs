using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 move;
    int nextWaypointIndex = 1;
    public WaypointManager wpManager;
    public float rotationSpeed = 360;
    public bool returnOnSamePath = false;
    int pathDirection = 1;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        transform.position = wpManager.waypoints[0].position;
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate((rotationSpeed * Time.deltaTime) * Vector3.forward);
        if (returnOnSamePath) {
            MoveWithReturn();
        }
        else {
            Move();
        }
    }

    void Move() {
        Vector2 dir = wpManager.waypoints[nextWaypointIndex].position - transform.position; //Finder retningsvektoren mellem fjenden og dens næste waypoint position. 
        if (dir.sqrMagnitude < 0.25f) {
            nextWaypointIndex = (nextWaypointIndex + 1) % wpManager.waypoints.Length; //Vi bruger modulus (%) til at sikre vi ikke prøver at tilgå en plads i arrayet som ikke eksistere
        }
        else {
            rb.velocity = dir.normalized * speed;
        }
    }
    void MoveWithReturn() {

        Vector2 dir = wpManager.waypoints[nextWaypointIndex].position - transform.position;
        if (dir.sqrMagnitude < 0.25f) {
            if (nextWaypointIndex + 1 >= wpManager.waypoints.Length || nextWaypointIndex - 1 < 0) {//undersøger om vi er ved starten eller slutningen af vores waypoint array.
                pathDirection *= -1;
            }
            nextWaypointIndex = (nextWaypointIndex + pathDirection);
        }
        else {
            rb.velocity = dir.normalized * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
            other.gameObject.GetComponent<PlayerController>()?.KillPlayer(); //? undersøger laver et try call så hvis objektet vi rammer har PlayerControlleren som et component vil den kalde KillPlayer.
    }
}
