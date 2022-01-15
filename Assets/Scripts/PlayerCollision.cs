using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public EnvironmentManager spawnManager;
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.layer == 9)
            spawnManager.SpawnEnvironment();
    }
}