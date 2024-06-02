using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screensaver : MonoBehaviour
{

    // ������� ����� ��� ��������� ���� �������� �����
    public string nextSceneName;

    void OnGUI()
    {
        // ������������ ����� ��� ������
        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.alignment = TextAnchor.MiddleCenter; // ��������� ����� �� ������
        style.fontSize = 24; // �������� ����� ������
        style.normal.textColor = Color.black; // ������������ ������ ���� ������

        // ��������� ������� ������ ��������� ������ ������� ������
        float textWidth = 400;
        float textHeight = 50;
        float x = (Screen.width - textWidth) / 2;
        float y = (Screen.height - textHeight) - 50   ;

        // ³��������� �����
        GUI.Label(new Rect(x, y, textWidth, textHeight), "�������� ����-��� ������", style);

        // ����������, �� ��������� ����-��� ������
        if (Event.current.type == EventType.KeyDown)
        {
            // ����������� �������� �����
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
