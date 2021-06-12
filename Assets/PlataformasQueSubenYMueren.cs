using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlataformasQueSubenYMueren : MonoBehaviour
    {
        public Vector3 target;

        public float speed;

        private void Update()
        {
            var step = speed * Time.deltaTime; // step size = speed * frame time
            // moves position a step closer to the target position
            if (Vector3.Distance(this.transform.position, target) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, step);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}