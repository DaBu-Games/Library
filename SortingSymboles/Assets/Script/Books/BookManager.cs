using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI; 

public class BookManager : MonoBehaviour
{

    [SerializeField] private List<Book> books = new List<Book>();
    [SerializeField] private Image currentCover;
    [SerializeField] private ShakeBook shakeBook;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private ShakeBook shakeThrophy;

    private int index = 0; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SetBookCover();
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if( books[index].target != null )
        {
            arrow.SetActive( true );
            arrow.transform.LookAt( books[index].target );
        }
        else
        {
            arrow.SetActive( false );
        }
    }

    public void CheckGenre( string genre )
    {
        if( genre == books[index].genre )
        {
            if( index < books.Count -1 )
            {
                index++;
                SetBookCover();
            }
            else
            {
                winScreen.SetActive(true);
                shakeThrophy.StartShake();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            
        }
        else
        {
            shakeBook.StartShake(); 
        }
    }

    private void SetBookCover()
    {
        currentCover.sprite = books[index].cover;
    }
    
}
