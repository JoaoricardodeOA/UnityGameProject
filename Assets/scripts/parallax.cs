using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.1f;
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime,0);
     }
}
