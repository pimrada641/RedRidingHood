using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    // Start is called before the first frame update
   void Update(){

       if(ChraracterScript.gamestarted == true){
           if(this.gameObject.name == "Parallex1"){
               transform.position += new Vector3(-4 * Time.deltaTime,0);
           }
           else if(this.gameObject.name == "Parallex4"){
               transform.position += new Vector3(-3 * Time.deltaTime,0);
           }
           else if(this.gameObject.name == "Parallex2"){
               transform.position += new Vector3(-2 * Time.deltaTime,0);
           }
           else if(this.gameObject.name == "Parallex3"){
               transform.position += new Vector3(-1 * Time.deltaTime,0);
           }
           else if(this.gameObject.name == "Parallex5"){
               transform.position += new Vector3(-0.5f * Time.deltaTime,0);
           }
           else if(this.gameObject.name == "Parallex6"){
               transform.position += new Vector3(-0.2f * Time.deltaTime,0);
           }
           else{
               transform.position += new Vector3(-5 * Time.deltaTime,0);
           }


           if(this.gameObject.CompareTag("Decolations")){
                if(transform.position.x < -48){
                    Destroy(this.gameObject);
                }
            }
            else if(this.gameObject.CompareTag("Ground")){
                if(transform.position.x < -44.5){
                    transform.position = new Vector3(123.1f, transform.position.y);
                }
            }
            else if(this.gameObject.name == "TutorialItem"){
                if(transform.position.x < -50){
                    Destroy(this.gameObject);
                    Tutorial.TutorialComplete = true;
                }
            }
            else if(this.gameObject.name == "Parallex1"){
                    if(transform.position.x <= -50){
                    transform.position = new Vector3(35f, transform.position.y);
                    
                }
            }
            else{
                if(transform.position.x <= -70){
                    transform.position = new Vector3(70f, transform.position.y);
                    
                }
            }
           
       }
   }
}
