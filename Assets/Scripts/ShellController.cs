using UnityEngine;

public class ShellController : MonoBehaviour
{
    [Header("��������")]
    public float deleteTime = 3.0f; //

    void Start()
    {
       Destroy(gameObject, deleteTime); //
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //
    }
    void Update()
    {
        
    }
}
