using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] ParticleSystem particleHit;
    [SerializeField] ParticleSystem particleStart;

    [SerializeField] AudioSource audio;
    private RaycastHit2D hit;

    bool sfxIsPlaying, startParticleIsPlaying, endParticlesIsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit) {
            if (!endParticlesIsPlaying) {
                endParticlesIsPlaying = true;
                particleHit.Play();
            }
            float discance = (hit.point - (Vector2)transform.position).magnitude;
            line.SetPosition(1, new Vector3(discance, 0, 0));
            particleHit.transform.position = hit.point;
            //Debug.Log("i hit: " + hit.collider.name);
            hit.collider.GetComponent<PlayerController>()?.KillPlayer();
        }
    }
}
