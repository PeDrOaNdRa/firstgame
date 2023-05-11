using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{
    public int velocidade; //define a velocidade de movimentação
    public int alturaPulo; //define a força do pulo
    private Rigidbody2D rbPlayer; //cria variável para recever os componentes de física

    public bool sensor; //sensor para verificar se está colidindo com o chão
    public Transform posicaoSensor; //Posição onde o sensor será posicionado
    public LayerMask layerChao; //Camada de interação

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoX * velocidade, rbPlayer.velocity.y);

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
