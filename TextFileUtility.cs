using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TextFileUtility : EditorWindow
{
	private static string activeFunction = "";
	private static string fileName = "";
	private static string contents = "Add your contents here...";

	private static TextAsset textAsset;

	private Vector2 scroll = Vector2.zero;

	[MenuItem("Assets/Create/Text File", false, 1000)]
	static void CreateWindow ()
	{
		activeFunction = "Create New";

		EditorWindow.GetWindow (typeof(TextFileUtility));
	}

	[MenuItem("Assets/Read Text File", false, 2000)]
	static void ReadWindow ()
	{
		activeFunction = "Read File";

		textAsset = Selection.activeObject as TextAsset;

		EditorWindow.GetWindow (typeof(TextFileUtility));
	}

	[MenuItem("Assets/Amend Text File", false, 2010)]
	static void AmendWindow ()
	{
		textAsset = Selection.activeObject as TextAsset;

		contents = textAsset.text;
		fileName = textAsset.name;
		activeFunction = "Amend File";

		EditorWindow.GetWindow (typeof(TextFileUtility));
	}

	void OnGUI ()
	{
		switch (activeFunction)
		{
		case "Create New":
			fileName = EditorGUILayout.TextField ("File Name: ", fileName);

			scroll = EditorGUILayout.BeginScrollView (scroll);
			contents = EditorGUILayout.TextArea (contents, GUILayout.Height(position.height - 50f));
			EditorGUILayout.EndScrollView ();

			if (fileName != "" && contents != "")
			{
				if (GUILayout.Button("Create"))
				{
					CreateTextFile ();
					this.Close ();
				}
			}
			break;
		case "Read File":
			if (textAsset != null)
			{
				scroll = EditorGUILayout.BeginScrollView (scroll);
				EditorGUILayout.SelectableLabel(textAsset.text, EditorStyles.label, GUILayout.ExpandHeight(true));
				EditorGUILayout.EndScrollView ();

				if (GUILayout.Button("Dismiss"))
				{
					this.Close();
				}
			}
			break;
		case "Amend File":
			fileName = EditorGUILayout.TextField ("File Name: ", fileName);

			scroll = EditorGUILayout.BeginScrollView (scroll);
			contents = EditorGUILayout.TextArea (contents, GUILayout.Height(position.height - 50f));
			EditorGUILayout.EndScrollView ();

			if (fileName != "" && contents != "" && textAsset != null)
			{
				if (GUILayout.Button("Amend"))
				{
					string assetPath = AssetDatabase.GetAssetPath (textAsset).Replace (textAsset.name + ".txt", "");
					AssetDatabase.DeleteAsset (AssetDatabase.GetAssetPath (textAsset));
					CreateTextFile (assetPath); 
					this.Close ();
				}
			}
			break;
		}
	}

	void CreateTextFile ()
	{
		File.WriteAllText (AssetDatabase.GetAssetPath(Selection.activeObject) + "/" + fileName + ".txt", contents);

		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh ();
	}

	void CreateTextFile (string path)
	{
		File.WriteAllText (path + "/" + fileName + ".txt", contents);

		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh ();
	}
}