using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class animationControl : MonoBehaviour
{
    public float speed;
    private Vector2 start;
    public GameObject target;
    public GameObject self;
    public SkeletonAnimation _animation;
    private int state;
    Vector2 target2d;
    // Start is called before the first frame update
    void Start()
    {
        _animation.AnimationName = "idle";
        start = self.transform.position;
        state = 0;
        target2d = new Vector2(target.transform.position.x, target.transform.position.y);
    }

    private void Update()
    {
        if(state==1)
        {
            Move();
        }
        else if(state==-1)
        {
            Back();
        }
    }
    public void Move()
    {
        _animation.AnimationName = "walk";
        self.transform.position = Vector2.MoveTowards(self.transform.position, target.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(self.transform.position,target2d)<100)
        {
            state = -1;
            Vector3 scale = self.transform.localScale;
            scale.x = scale.x * -1;
            self.transform.localScale = scale;
        }
        /*manager.Initiate.startFight();*/

    }
    public void Back()
    {
        _animation.AnimationName = "walk";
        self.transform.position = Vector2.MoveTowards(self.transform.position, start, speed * Time.deltaTime);
        if (Vector2.Distance(self.transform.position, start) < 0.1f)
        {
            state = 0;
            Vector3 scale = self.transform.localScale;
            scale.x = scale.x * -1;
            self.transform.localScale = scale;
            _animation.AnimationName = "idle";
            if (manager.Initiate.get_gameState() != 0)
            { manager.Initiate.set_gameState(1); }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collise");
        if(state!=0)
        {
            manager.Initiate.attack(self, collision.gameObject);
        }
        
    }

    public void set_state(int a)
    {
        state=a;
    }
}
