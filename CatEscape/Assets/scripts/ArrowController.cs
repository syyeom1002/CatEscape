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

        
        return dis < sumradius;
    }
    // Update is called once per frame
    void Update()
    {
        
        this.transform.Translate(this.speed * Vector3.down * Time.deltaTime);

        if (this.transform.position.y <= -4.08)
        {
            Destroy(this.gameObject);
            GameObject gameDirectorGo = GameObject.Find("GameDirector");
            GameDirector gameDirector = gameDirectorGo.GetComponent<GameDirector>();
            
        }
        if (this.isCollide())
        {
            Debug.Log("충돌");
            GameObject gameDirectorGo = GameObject.Find("GameDirector");
            GameDirector gameDirector = gameDirectorGo.GetComponent<GameDirector>();
            gameDirector.DecreasHp();
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("충돌X");
        }
    }
    public float radius = 1;
    //이벤트 함수 
    private void OnDrawGizmos()// 원 생김
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius); // this.transform.position은 원의 중점
    }

}
