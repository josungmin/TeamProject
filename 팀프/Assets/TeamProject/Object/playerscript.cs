using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscript : MonoBehaviour
{
    float moveSpeed = 5f;
    public Slider ui;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
     

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        /*if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp
                (
                transform.forward,
                direction,
                moveSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );
            transform.LookAt(transform.position + forward);
        }*/

        characterController.Move(direction * moveSpeed * Time.deltaTime);



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="HealthPotion")
        {
            Destroy(other.gameObject);
            AddScore();
        }

        if (other.gameObject.tag == "SkillPotion")
        {
            Destroy(other.gameObject);
            AddScore();
        }

    }

    void AddScore()
    {
        GameObject.Find("HPSlider").GetComponent<HPscript>().value += 0.1f;
        GameObject.Find("SkillSlider").GetComponent<Skillscript>().value += 0.1f;
    }

    

   


}
