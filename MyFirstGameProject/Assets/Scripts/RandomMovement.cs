using UnityEngine;

namespace Assets.Scripts
{
    public class RandomMovement : MonoBehaviour
    {
        public int Force = 20;
    
        void Start()
        {
            var rb = gameObject.GetComponent<Rigidbody2D>();

            //If first dial move down-left
            if (transform.position.x > 0 && transform.position.y > 0)
            {
                float directionX = Force * Random.Range(-1.0f, 0);
                float directionY = Force * Random.Range(-1.0f, 0);
                rb.velocity = new Vector2(directionX, directionY);
            }

            //If second third move up-right
            if(transform.position.x < 0 && transform.position.y < 0)
            {
                float directionX = Force * Random.Range(0, 1.0f);
                float directionY = Force * Random.Range(0, 1.0f);
                rb.velocity = new Vector2(directionX, directionY);
            }

            //If forth dial move up-left
            if (transform.position.x > 0 && transform.position.y < 0)
            {
                float directionX = Force * Random.Range(-1.0f, 0);
                float directionY = Force * Random.Range(0, 1.0f);
                rb.velocity = new Vector2(directionX, directionY);
            }

            //If second dial move down-right
            if (transform.position.x < 0 && transform.position.y > 0)
            {
                float directionX = Force * Random.Range(0, 1.0f);
                float directionY = Force * Random.Range(-1.0f, 0);
                rb.velocity = new Vector2(directionX, directionY);
            }
        }
    }
}
