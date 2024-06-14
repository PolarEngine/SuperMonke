using GorillaLocomotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SuperMonkee
{
    public class SuperPhysics : MonoBehaviour
    {
        Player player = Player.Instance;
        private Rigidbody rb;
        private float speed = 1;

        private void Awake()
        {
            Console.WriteLine("SuperMonke has came back with a new fly! He will now save the city like bat man,");
            rb = player.GetComponent<Rigidbody>();
        }

        public void Update()
        {
            if (Mod.IsAllowed())
            {
                bool isLeft = ControllerInputPoller.instance.leftGrab && ControllerInputPoller.instance.leftControllerPrimaryButton && ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f;
                bool isRight = ControllerInputPoller.instance.rightGrab && ControllerInputPoller.instance.rightControllerPrimaryButton && ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
                Vector3 bodyToLeft = player.leftControllerTransform.position - player.bodyCollider.transform.position;
                Vector3 bodyToRight = player.rightControllerTransform.position - player.bodyCollider.transform.position;
                if (isLeft && isRight)
                {
                    if (speed < 32)
                        speed = (speed * 2) / 1.5f;
                    rb.useGravity = false;
                    rb.velocity = ((bodyToLeft + bodyToRight) / 2) * speed;
                }
                else
                {
                    rb.useGravity = true;
                    if (rb.velocity.magnitude > 2)
                        speed = rb.velocity.magnitude;
                }
            }
        }
    }
}
