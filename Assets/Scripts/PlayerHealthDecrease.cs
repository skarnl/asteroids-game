using UnityEditor;
using UnityEngine;
using Managers;

public class PlayerHealthDecrease : MonoBehaviour {

    [Range(0, 50)]
    public int dropPerFrame = 20;

    private Health playersHealth;

    private void Awake()
    {
        playersHealth = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        HealthManager.Instance.AddHealth(-dropPerFrame);
    }
}