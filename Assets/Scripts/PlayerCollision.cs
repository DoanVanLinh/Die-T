using UnityEngine;

public class PlayerCollision : PlayerInfor
{
    public EnvironmentManager spawnManager;
    public PlayerMovement playerMovment;
    private void OnTriggerExit(Collider other)
    {
        //Spawn Environment
        if (other.gameObject.layer == 9)
            spawnManager.SpawnEnvironment();

        
    }
    private void OnTriggerEnter(Collider other) {
        //Collision with Food
        if (other.gameObject.layer == 10&&other.TryGetComponent(out FoodInfor foodInfor))
        {
            base.CurrentBMI += foodInfor.protein; 
            Destroy(other.gameObject);
            playerMovment.UpdateStatusPlayer();
        }
    }
}