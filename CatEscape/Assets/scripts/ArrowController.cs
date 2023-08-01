using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameObject catGo;
    // Start is called before the first frame update
    void Start()
    {
        this.catGo = GameObject.Find("cat");
        Debug.Log("catGo:{0}", this.catGo);

        //두 원 사이의 거리
        
    }
    private bool isCollide()
    {
        var dis = Vector3.Distance(this.transform.position, this.catGo.transform.position);

        //반지름의 합
        CatController catController = this.catGo.GetComponent<CatController>();
        var sumradius = this.radius + catController.radius;

        // 두 원사이의 거리가 두 원의 반지름의 합보다 크면 false (부딪히지 않았다)
        return dis < sumradius;
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.deltaTime);
        // this.gameObject.transform.Translate(0, -1, 0);
        //시간기반 이동
        //속도 방향 시간
        //1f*new Vector3(0,-1,0)*Time.deltaTime
        this.transform.Translate(this.speed * Vector3.down * Time.deltaTime);

        if (this.transform.position.y <= -4.08)
        {
            Destroy(this.gameObject);
        }
        if (this.isCollide())
        {
            Debug.Log("충돌");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("충돌X");
        }
    }
    public float radius = 1;
    //이벤트 함수 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }

}
