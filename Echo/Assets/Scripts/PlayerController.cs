using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rbCesar;
    public  float       _spdCesar;
    private Vector2     _directionCesar;



    // Start is called before the first frame update
    void Start()
    {
        _rbCesar = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _directionCesar = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    void FixedUpdate()
    {
        _rbCesar.MovePosition(_rbCesar.position + _directionCesar * _spdCesar * Time.fixedDeltaTime);

    }

}
