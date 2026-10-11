using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Spikes : MonoBehaviour
{
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
            Destroy(other.gameObject);
            StartCoroutine(Reiniciar());
        }
    }

    IEnumerator Reiniciar()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
