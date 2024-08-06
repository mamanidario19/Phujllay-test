using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;  
    public GameObject player; 
    //private MonoBehaviour playerMovement;
    //private MonoBehaviour playerInventory;

    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer no asignado en el inspector.");
            return;
        }

        if (player == null)
        {
            Debug.LogError("Player no asignado en el inspector.");
            return;
        }

        // Obtener los componentes de movimiento e inventario del jugador
        //playerMovement = player.GetComponent<PlayerMovement>();
        //playerInventory = player.GetComponent<PlayerInventory>();

        //if (playerMovement == null || playerInventory == null)
       // {
        //    Debug.LogError("PlayerMovement o PlayerInventory no encontrados en el objeto Player.");
       //     return;
       // }

        // Asegurarse de que el VideoPlayer tenga el método OnVideoEndListener para cuando termine el video
        videoPlayer.loopPointReached += OnVideoEndListener;

        // VideoPlayer deshabilitado al iniciar
        videoPlayer.enabled = false;
    }

    void Update()
    {
        // Activador provisional de video
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayVideo();
        }
    }

    public void PlayVideo()
    {
    //    if (playerMovement == null || playerInventory == null || videoPlayer == null)
    //    {
    //        Debug.LogError("Componentes no asignados");
    //        return;
    //    }

        // Desactivar los scripts de movimiento e inventario del jugador
        //playerMovement.enabled = false;
        //playerInventory.enabled = false;

        // Habilitar el VideoPlayer
        videoPlayer.enabled = true;

        // Reproducir el video
        videoPlayer.Play();
    }

    private void OnVideoEndListener(VideoPlayer vp)
    {
    //    if (playerMovement == null || playerInventory == null || videoPlayer == null)
    //    {
    //        Debug.LogError("Componentes no asignados");
    //        return;
    //    }

        // Volver a activar los scripts de movimiento e inventario del jugador
    //    playerMovement.enabled = true;
    //    playerInventory.enabled = true;

        // Deshabilitar el VideoPlayer
        videoPlayer.enabled = false;
    }
}