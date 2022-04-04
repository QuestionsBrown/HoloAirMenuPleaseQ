using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //public void testArray()
    //{
    //    ArtRoom1 artRoom1 = new ArtRoom1();
    //    Art art1 = new Art();




    //    foreach (ArtDisplay artName in art1)
    //    {

    //        artName.BindText();

    //    }



    // foreach (Art art in artRoom1)
    //{
    //   art.printArtName();

    // }

//}

//}


class ArtRoom1 : IEnumerable<Art>
{


    public List<Art> art;

    public ArtRoom1()
    {

        art = new List<Art>
        {
            //Insert Updated Firebase Info

            new Art("Penthouse Sweet", true, null),
            new Art("Cannoli", false, null),
            new Art("Make Sense", false, null),
            new Art("Bean", true, null)
        };



    }


    IEnumerator<Art> IEnumerable<Art>.GetEnumerator()
    {
        return art.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}


















public class Art : IEnumerable<ArtDisplay>

{

    public string artName { get; set; }
    public bool onSale { get; set; }
    public ArtDisplay artDisplayRef { get; set; }



    public Art(string artName, bool onSale, string textName)
    {

        this.artName = artName;
        this.onSale = onSale;

    }



    public List<ArtDisplay> artDisplay;


    public Art()
    {


        artDisplay = new List<ArtDisplay>
            {
                new ArtDisplay("PentHouse"),
                new ArtDisplay("Cannoli"),
                new ArtDisplay("Make Sense"),
                new ArtDisplay("Bean"),
            };

    }





    public void printArtName()
    {

        Debug.Log(artDisplay);

    }



    IEnumerator<ArtDisplay> IEnumerable<ArtDisplay>.GetEnumerator()
    {
        return artDisplay.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

}




public class ArtDisplay
{

    public string textName { get; set; }



    public ArtDisplay(string textName)
    {
        this.textName = textName;
    }



    public void BindText()
    {
        Debug.Log(textName);

    }

}