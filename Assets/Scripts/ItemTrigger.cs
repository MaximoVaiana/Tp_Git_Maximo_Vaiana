using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public PhysicsPlayer player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PhysicsPlayer>();
            player.CollectItem();
            Destroy(gameObject);
        }
    }
}
