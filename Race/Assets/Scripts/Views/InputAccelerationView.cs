﻿using JoostenProductions;
using Tools;
using UnityEngine;


namespace Views
{
    public class InputAccelerationView : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void Move()
        {
            Vector3 direction = Vector3.zero;
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;

            if (direction.sqrMagnitude > 1)
                direction.Normalize();

            OnRightMove(direction.sqrMagnitude / 20 * _speed);
        }


        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }
    }
}
