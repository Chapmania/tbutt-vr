﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

namespace TButt
{
    /// <summary>
    /// Waits for a controller node, then parents the controller underneath that node.
    /// </summary>
    public class TBTrackedNodeHelper : MonoBehaviour
    {
        public TBNode nodeToAttachWith;

        public Vector3 positionOffset;
        public Vector3 rotationOffset;

        private Vector3 _startingScale;

        void OnEnable()
        {
            TBTracking.OnNodeCreated += AttachToNode;
            _startingScale = transform.localScale;
            Transform target = TBTracking.GetTransformForNode(nodeToAttachWith);
            if (target != null)
            {
                AttachToNode(nodeToAttachWith, target);
            }
        }

        void OnDisable()
        {
            TBTracking.OnNodeCreated -= AttachToNode;
        }

        void AttachToNode(TBNode node, Transform t)
        {
            if (node == nodeToAttachWith)
            {
                transform.SetParent(t);
                transform.localPosition = positionOffset;
                transform.localEulerAngles = rotationOffset;
                transform.localScale = _startingScale;
                this.enabled = false;
            }
        }
    }
}

