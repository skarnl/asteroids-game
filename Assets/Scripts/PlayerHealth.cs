using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [Range(0, 1000)]
    public float dropPerFrame = 0f;

    private Health playersHealth;

    private void Awake()
    {
        playersHealth = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        playersHealth.TakeHit(dropPerFrame);
    }
}