using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameJamKit.Scripts.Utils.Attributes;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameJamKit.Scripts.Utils.Editor.CustomInspectors
{
    public class BehaviourButtonsHelper
    {
        private static readonly object[] EmptyParamList = Array.Empty<object>();

        private IList<MethodInfo> _methods = new List<MethodInfo>();
        private Object _targetObject;

        public void Init(Object targetObject)
        {
            this._targetObject = targetObject;
            _methods = targetObject.GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(methodInfo =>
                    methodInfo.GetCustomAttributes(typeof(ButtonAttribute), false).Length == 1 &&
                    methodInfo.GetParameters().Length == 0 &&
                    !methodInfo.ContainsGenericParameters
                ).ToList();
        }

        public void DrawButtons()
        {
            if (_methods.Count > 0)
            {
                EditorGUILayout.HelpBox("Click to execute methods!", MessageType.None);
                ShowMethodButtons();
            }
        }

        private void ShowMethodButtons()
        {
            foreach (var method in _methods)
            {
                var buttonText = ObjectNames.NicifyVariableName(method.Name);
                if (GUILayout.Button(buttonText)) method.Invoke(_targetObject, EmptyParamList);
            }
        }
    }


    [CanEditMultipleObjects]
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class BehaviourButtonsEditor : UnityEditor.Editor
    {
        private readonly BehaviourButtonsHelper _behaviourButtonsHelper = new();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _behaviourButtonsHelper.DrawButtons();
        }

        private void OnEnable()
        {
            _behaviourButtonsHelper.Init(target);
        }
    }
}