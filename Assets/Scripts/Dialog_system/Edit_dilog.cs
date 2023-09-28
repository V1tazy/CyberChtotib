// using UnityEditor;
// using UnityEngine;

// //Этим атрибутом мы объявляем какой компонент подвергнется редактированию
// [CustomEditor( typeof(Dialog) )]
// [CanEditMultipleObjects]

// public class Editor_dilog : Editor 
// {
// 	Dialog subject;

//     // // For miner
//     SerializedProperty number_line;
//     SerializedProperty list_unswers;

// 	// //Передаём этому скрипту компонент и необходимые в редакторе поля
// 	void OnEnable () 
// 	{
// 		subject = target as Dialog;
		
//         number_line = serializedObject.FindProperty ("numbers_line");
// 		list_unswers = serializedObject.FindProperty ("unswers");
// 	}
	
// 	//Переопределяем событие отрисовки компонента
// 	public override void OnInspectorGUI() 
// 	{
// 		//Метод обязателен в начале. После него редактор компонента станет пустым и
// 		//далее мы с нуля отрисовываем его интерфейс.
// 		serializedObject.Update ();
	
//         EditorGUILayout.PropertyField(number_line);
//         EditorGUILayout.PropertyField(list_unswers);
		
// 		//Метод обязателен в конце
// 		serializedObject.ApplyModifiedProperties ();
// 	}
// }