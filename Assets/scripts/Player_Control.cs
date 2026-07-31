using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public GameObject ground;
    Movement input_control;
    Vector2 move;
    float movement_force = 2500;
    Rigidbody rb;
    bool isgrounded=true;
    float jumpforce = 25;
    void Start()
    {
        input_control=new Movement();
        input_control.Player_Map.Enable();
        rb=GetComponent<Rigidbody>();
        move=Vector2.zero;
    }

    void FixedUpdate()
    {
       groundcheck();
       playermove();
       if(isgrounded && input_control.Player_Map.Jump.ReadValue<float>()>0)
       {
         Playerjump();
       } 

       

    }
    void groundcheck()
    {
         if(transform.position.y-ground.transform.position.y>1.5)
        {
            isgrounded=false;

            rb.linearDamping=0.1f;
        }
        else{
            isgrounded=true;
            rb.linearDamping=3f;
        }

    }
    void playermove()
    {
        move=input_control.Player_Map.Movement.ReadValue<Vector2>();
        float forcez=move.x*movement_force*Time.deltaTime;    
        float forcex=move.y*movement_force*Time.deltaTime;    
        rb.AddForce(transform.forward*forcex,ForceMode.Force);
        rb.AddForce(transform.right*forcez,ForceMode.Force);

    }
    void Playerjump()
    {
       rb.AddForce(Vector3.up*jumpforce,ForceMode.Impulse); 
    }
}