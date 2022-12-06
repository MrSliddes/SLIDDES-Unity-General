using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SLIDDES.Attributes;

[CustomPropertyDrawer(typeof(LabelAttribute))]
public class LabelDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        try
        {
            var propertyAttribute = this.attribute as LabelAttribute;
            if(!SerializedPropertyIsArray(property))
            {
                label.text = propertyAttribute.label;
            }
            else
            {
                Debug.LogWarningFormat( "{0}(\"{1}\") doesn't support arrays ", typeof(LabelAttribute).Name, propertyAttribute.label);
            }
        }
        catch(System.Exception ex) { Debug.LogException(ex); }
    }

    bool SerializedPropertyIsArray(SerializedProperty property)
    {
        string path = property.propertyPath;
        int idot = path.IndexOf('.');
        if(idot == -1) return false;
        string propName = path.Substring(0, idot);
        SerializedProperty p = property.serializedObject.FindProperty(propName);
        return p.isArray;
        //CREDITS: https://answers.unity.com/questions/603882/serializedproperty-isnt-being-detected-as-an-array.html
    }
}
