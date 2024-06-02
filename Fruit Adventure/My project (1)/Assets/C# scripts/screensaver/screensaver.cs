using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screensaver : MonoBehaviour
{

    // Публічна змінна для зберігання імені наступної сцени
    public string nextSceneName;

    void OnGUI()
    {
        // Встановлюємо стиль для тексту
        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.alignment = TextAnchor.MiddleCenter; // Вирівнюємо текст по центру
        style.fontSize = 24; // Збільшуємо розмір шрифту
        style.normal.textColor = Color.black; // Встановлюємо чорний колір тексту

        // Визначаємо позицію тексту посередині нижньої частини екрана
        float textWidth = 400;
        float textHeight = 50;
        float x = (Screen.width - textWidth) / 2;
        float y = (Screen.height - textHeight) - 50   ;

        // Відображаємо текст
        GUI.Label(new Rect(x, y, textWidth, textHeight), "Натисніть будь-яку кнопку", style);

        // Перевіряємо, чи натиснута будь-яка кнопка
        if (Event.current.type == EventType.KeyDown)
        {
            // Завантажуємо наступну сцену
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
