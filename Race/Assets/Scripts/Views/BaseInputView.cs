﻿using Tools;
using UnityEngine;


namespace Views
{
    public abstract class BaseInputView : MonoBehaviour
    {

        #region Fields

        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;

        protected float _speed;

        #endregion


        #region Methods

        public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _speed = speed;
        }

        protected virtual void OnLeftMove(float value)
        {
            _leftMove.Value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            _rightMove.Value = value;
        }

        #endregion

    }
}
