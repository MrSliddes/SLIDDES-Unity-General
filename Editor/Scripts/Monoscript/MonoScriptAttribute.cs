using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*****
 * This is part of a simple PropertyDrawer for string variables to allow drag
 * and drop of MonoScripts in the inspector of the Unity3d editor.
 * 
 * NOTE: This is a runtime script and MUST NOT be placed in a folder named "editor".
 *       It also requires another editor file named "MonoScriptPropertyDrawer.cs"
 * 
 * Copyright (c) 2016 Bunny83
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to
 * deal in the Software without restriction, including without limitation the
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 * 
 *****/

namespace SLIDDES.Editor
{
    /// <summary>
    /// 
    /// </summary>
    /// <credit>// https://answers.unity.com/questions/1462909/assign-a-variable-of-type-type-on-the-inspector-or.html</credit>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class MonoScriptAttribute : PropertyAttribute
    {
        public System.Type type;
    }
}
