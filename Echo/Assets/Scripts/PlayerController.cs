using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rbCesar;
    public  float       _spdCesar = 3;
    private Vector2     _directionCesar;
    private bool        _facingR = true;



    // Start is called before the first frame update
    void Start()
    {
        _rbCesar = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _directionCesar = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if((_directionCesar.x < 0) && (_facingR == true))
        {
            Flip();
        }

        else if((_directionCesar.x > 0) && (_facingR == false))
        {
            Flip();
        }
        
    }

    void FixedUpdate()
    {
        _rbCesar.MovePosition(_rbCesar.position + _directionCesar * _spdCesar * Time.fixedDeltaTime);

    }

        private void Flip()
    {
        _facingR = !_facingR;
        transform.Rotate(0, 180, 0);
    }

}
