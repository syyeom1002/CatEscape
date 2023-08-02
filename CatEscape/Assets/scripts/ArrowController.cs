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

        //�� �� ������ �Ÿ�
        
    }
    private bool isCollide()
    {
        var dis = Vector3.Distance(this.transform.position, this.catGo.transform.position);

        //�������� ��
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
            Debug.Log("�浹");
            GameObject gameDirectorGo = GameObject.Find("GameDirector");
            GameDirector gameDirector = gameDirectorGo.GetComponent<GameDirector>();
            gameDirector.DecreasHp();
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("�浹X");
        }
    }
    public float radius = 1;
    //�̺�Ʈ �Լ� 
    private void OnDrawGizmos()// �� ����
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius); // this.transform.position�� ���� ����
    }

}
