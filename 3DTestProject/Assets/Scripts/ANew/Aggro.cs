﻿
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public AggroComponent aggroComponent;

        public float Cooldown;
        private Coroutine _aggroCoroutine;
        private bool _hasAggroTarget;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            SwitchFollowOff();
        }

        private void TriggerEnter(Collider obj)
        {
            if (!_hasAggroTarget)
            {
                _hasAggroTarget = true;
                StopAggroCoroutine();
                SwitchFollowOn();
            }
        }

        private void TriggerExit(Collider obj)
        {

            if (_hasAggroTarget)
            {
                _hasAggroTarget = false;
                _aggroCoroutine = StartCoroutine(SwitchFollowOffAfterCooldown());
            }
        }

        private void StopAggroCoroutine()
        {
            if (_aggroCoroutine != null)
            {
                StopCoroutine(_aggroCoroutine);
                _aggroCoroutine = null;
            }
        }

        private IEnumerator SwitchFollowOffAfterCooldown()
        {
            yield return new  WaitForSeconds(Cooldown);
            
            SwitchFollowOff();
        }

        private void SwitchFollowOn() => 
            aggroComponent.enabled = true;

        private void SwitchFollowOff() => 
            aggroComponent.enabled = false;
    }
}