﻿namespace pogorock
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEditor;
	using Newtonsoft.Json;
	using System.IO;
	using UniRx;
	using System.Linq;
	using System;

	public partial class PogoAdsXManager : EditorWindow
	{
		void InfoItemLayout (PogoAdInfo info)
		{
			EditorGUILayout.BeginVertical ("box");
			EditorGUILayout.BeginHorizontal ();

			EditorGUILayout.Space ();
			EditorGUILayout.BeginVertical (GUILayout.Width (100f));
			EditorGUILayout.Space ();
			if (info.Enable) {
				GUILayout.Label (gizmo_enabled);
			} else {
				GUILayout.Label (gizmo_disabled);
			}

			EditorGUILayout.BeginHorizontal ();
			if (info.HasTest) {
				info.IsTest = GUILayout.Toggle (info.IsTest, "测试模式");
			}

			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			if (info.Enable) {
				if (GUILayout.Button ("禁用")) {
					info.Enable = false;
				}
			} else {
				if (GUILayout.Button ("启用")) {
					info.Enable = true;
				}
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			if (info.SetInEditor) {
				if (GUILayout.Button ("预设置")) {
					PogoAdsX_PreSet.PreSet (info.Key);
				}
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.EndVertical ();

			EditorGUILayout.Space ();

			fixedInfoContent (info);

			EditorGUILayout.EndHorizontal ();

//			multiPaths (info);

			EditorGUILayout.EndVertical ();
		}

		void fixedInfoContent (PogoAdInfo info)
		{
			float total_width = 460f;
			EditorGUILayout.BeginVertical (GUILayout.Width (total_width));

			string title = string.Format ("{0} - ({1})", info.Key, info.Title);
			GUILayout.Label (title, EditorStyles.largeLabel);

			float key_split = .3f;

//			Dictionary<string, string> change = new Dictionary<string, string> ();

			foreach (var kvp in info.Params) {
				EditorGUILayout.BeginHorizontal ();

//				if (kvp.Key == "order") {
//					int ori_value = Convert.ToInt32 (kvp.Value);
//					int value = EditorGUILayout.DelayedIntField (kvp.Key, ori_value, GUILayout.ExpandWidth (true));
//					info.Params [kvp.Key] = value.ToString ();
//				} else {
				string value = EditorGUILayout.DelayedTextField (kvp.Key, kvp.Value, GUILayout.ExpandWidth (true));
				if (value != kvp.Value) {
					info.Params [kvp.Key] = value;
					break;
				}
//				}
				EditorGUILayout.EndHorizontal ();
			}

			EditorGUILayout.EndVertical ();
		}
	}
}