Unity Text File Utility V1.0

INSTRUCTIONS:

To Create New Text Files:
- Right click inside the desired folder or directory.
- From the drop down select "Create".
- Select "Text File" from the drop down.
- An editor window will appear in which you enter the desired file name and the contents of the file.
- Once you have finished click the "Create" button at the bottom of the window.

To Read Text Files:
- Right click the text asset.
- From the drop down select "Read Text File".
- An editor window will appear displaying the file contents.
- To dismiss the window either click the "Dismiss" button at the bottom of the window or press the 'X' icon at the top right.
- This can also be used to preview scripts.

To Amend Text Files:
- Right click the text asset.
- From the drop down select "Amend Text File".
- An editor window will appear displaying the existing file contents and allowing for new input.
- Amend the file contets and the file name as desired.
- Once you are ready to commit the changes click the "Amend" button at the bottom window.
- To dismiss changes simply press the 'X' icon at the top right of the window.
- Beware there is no validation function preventing you from amending C# scripts! DO NOT use this function on scripts.




KNOWN ISSUES:
- Scroll bars for text areas as well as the file reader presently do not function due to an issue with EditorGUILayout.BeginScrollView() and 
EditorGUILayout.TextArea.
