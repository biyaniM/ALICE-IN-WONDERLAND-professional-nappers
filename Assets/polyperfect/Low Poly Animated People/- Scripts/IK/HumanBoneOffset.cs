using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polyperfect.People
{
    [System.Serializable]
    public class HumanBoneOffset
    {
        public HumanBodyBones bone;
        public Vector3 rotationOffset;
        public bool active;
    }
}
