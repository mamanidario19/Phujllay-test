using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    public float flashDuration = 1f; // Duración del flash en segundos
    private CanvasGroup canvasGroup; // El Canvas Group que controla la opacidad del flash
    public bool isFlashActive = false;
    public string folder = "ScreenshotFlash";
    public Image screenshotImage; // Asigna el componente Image desde el inspector

    void Start()
    {
        //Create the folder
        System.IO.Directory.CreateDirectory(folder);

        // Obtiene el Canvas Group
        canvasGroup = GetComponent<CanvasGroup>();

    }

    void Update()
    {
        // Si se presiona la tecla F, inicia el flash
        if (isFlashActive)
        {
            FlashActive();
            // Asegura de que el booleano solo se active en un solo frame.
            isFlashActive = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            CaptureScreen();
            //StartCoroutine(Flash());
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            DeleteAllScreenshots();
        }
    }

    private void FlashActive()
    {
        StartCoroutine(Flash());
    }

    private void CaptureScreen()
    {
        string name = string.Format("{0}/{1:D03} shot.png", folder, Time.frameCount);
        ScreenCapture.CaptureScreenshot(name);
        // Carga la captura como textura y asígnala al Image
        StartCoroutine(LoadScreenshot(name));
    }

    // Llama a esta función para eliminar todas las capturas en la carpeta
    public void DeleteAllScreenshots()
    {
        DirectoryInfo dirInfo = new DirectoryInfo(folder);
        foreach (FileInfo file in dirInfo.GetFiles())
        {
            file.Delete();
        }
        //Debug.Log("Todas las capturas eliminadas correctamente.");
    }

    IEnumerator LoadScreenshot(string screenshotPath)
    {
        // Espera un frame para asegurarte de que la captura se haya guardado
        yield return null;

        // Carga la captura como textura
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height);
        screenshotTexture.LoadImage(System.IO.File.ReadAllBytes(screenshotPath));

        //// Modifica la textura para saturarla en blanco con menor intensidad
        //float whiteIntensity = 0.5f; // Ajustar valor de intensidad
        //for (int x = 0; x < screenshotTexture.width; x++)
        //{
        //    for (int y = 0; y < screenshotTexture.height; y++)
        //    {
        //        Color pixelColor = screenshotTexture.GetPixel(x, y);
        //        pixelColor.r = 1f - (1f - pixelColor.r) * whiteIntensity;
        //        pixelColor.g = 1f - (1f - pixelColor.g) * whiteIntensity;
        //        pixelColor.b = 1f - (1f - pixelColor.b) * whiteIntensity;
        //        screenshotTexture.SetPixel(x, y, pixelColor);
        //    }
        //}

        // Modifica la textura para saturarla en blanco con menor saturacion
        float saturation = 0.5f; // Ajustar valor de saturacion

        Color[] pixels = screenshotTexture.GetPixels();

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = Color.Lerp(Color.white, pixels[i], saturation);
        }

        screenshotTexture.SetPixels(pixels);
        screenshotTexture.Apply(); // Aplica los cambios

        // Asigna la textura al Image
        screenshotImage.sprite = Sprite.Create(screenshotTexture, new Rect(0, 0, screenshotTexture.width, screenshotTexture.height), Vector2.zero);

        FlashActive();
    }

    IEnumerator Flash()
    {
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(1f);
        // Guarda el tiempo de inicio del flash
        float startTime = Time.time;

        // Mientras no haya pasado el tiempo de duración del flash
        while (Time.time < startTime + flashDuration)
        {
            // Calcula cuánto tiempo ha pasado desde el inicio del flash
            float elapsed = Time.time - startTime;

            // Calcula la opacidad del flash en función del tiempo transcurrido
            canvasGroup.alpha = 1f - (elapsed / flashDuration);

            // Espera hasta el próximo frame
            yield return null;
        }

        // Asegura que la opacidad del flash sea 0 al finalizar
        canvasGroup.alpha = 0f;
    }
}
