using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{
    public int velocidade; //define a velocidade de movimenta��o
    public int alturaPulo; //define a for�a do pulo
    private Rigidbody2D rbPlayer; //cria vari�vel para recever os componentes de f�sica    
    private Animator anim;

    public bool sensor; //sensor para verificar se est� colidindo com o ch�o
    public Transform posicaoSensor; //Posi��o onde o sensor ser� posicionado
    public LayerMask layerChao; //Camada de intera��o*

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoX * velocidade, rbPlayer.velocity.y);

        anim.SetInteger("walk", (int)movimentoX);

        if(Input.GetButtonDown("Jump") && sensor == true)
        {
            rbPlayer.AddForce(new Vector2(0, alturaPulo));
        }
        
    }



    private void FixedUpdate()
    {

        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);

    }
}
