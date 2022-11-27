using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using Polyperfect.Common;

#if UNITY_EDITOR
namespace Polyperfect.People
{
    [CustomEditor(typeof(People_WanderScript))]
    [CanEditMultipleObjects]
    public class People_WanderScriptEditor : Common_WanderScriptEditor { }
}
#endif