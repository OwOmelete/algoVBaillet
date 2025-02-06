using UnityEngine;

public class Selecter : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        Vector3 pos = transform.position;
        pos.x =  Mathf.Clamp(transform.position.x, 0, 6);
        transform.position = pos;
    }
}
