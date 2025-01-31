using UnityEngine;
using UnityEngine.InputSystem;

public class CheckGenre : MonoBehaviour
{

    [SerializeField] private GameObject pressE;
    [SerializeField] private BookManager bookManager;

    private int triggerCount = 0;
    private Transform genre; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pressE.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if ( other.CompareTag("GenreArea") )
        {
            triggerCount++; 
            pressE.SetActive(true); 
            genre = other.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if ( other.CompareTag("GenreArea") )
        {
            triggerCount--; 

            if ( triggerCount <= 0 ) 
            {
                pressE.SetActive(false);
                genre = null; 
                triggerCount = 0; 
            }
        }

    }

    public void CheckInput( InputAction.CallbackContext context )
    {

        if ( context.started && genre != null ) 
        {
            bookManager.CheckGenre( genre.parent.name );
        }
    }

}
