using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LaghtBarScript : MonoBehaviour
{
    [SerializeField] private GameObject healthbar;
    private float maxlagh = 1.45f;
    private float corentlagh = 0.0f;
    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        t = healthbar.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        t.position = t.position + new Vector3(0, corentlagh, 0);
        
    }
}

