using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CatController : MonoBehaviour
{
    public float radius = 1;
    private int catHp = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.MoveLeft();
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.MoveRight();
            
        }
        
    }
    
    //이벤트 함수 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
    public void MoveLeft()
    {
        this.transform.Translate(-3, 0, 0);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -7.6f, 7.6f),-3.5f,0);
    }
    public void MoveRight()
    {
        this.transform.Translate(3, 0, 0);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -7.6f, 7.6f),-3.5f, 0);
    }
}
