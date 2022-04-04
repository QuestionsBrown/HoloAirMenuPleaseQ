using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


//public class UIPanel
//{

//    public GameObject itemUIPanel { get; set; }
//    public GameObject itemTitle { get; set; }
//    public GameObject itemDescription { get; set; }
//    public GameObject itemPrice { get; set; }

//    public string descriptionString { get; set; }
//    public string titleString { get; set; }
//    public string priceString { get; set; }



//    public GameObject itemTitleOrigin { get; set; }
//    public GameObject itemDescriptionOrigin { get; set; }
//    public GameObject itemPriceOrigin { get; set; }


//    public GameObject itemTitleView { get; set; }
//    public GameObject itemDescriptionView { get; set; }
//    public GameObject itemPriceView { get; set; }

//    public float moveDuration { get; set; }
//    public float delay { get; set; }



//    LTDescr movePanelTween = null;
//    LTDescr movePanelBackTween = null;

//    LTDescr moveTitleTween = null;
//    LTDescr moveTitleBackTween = null;
//    LTDescr moveDescriptionTween = null;
//    LTDescr movePriceTween = null;
//    LTDescr moveDescriptionBackTween = null;
//    LTDescr movePriceBackTween = null;


//    int movePanelID;
//    int movePanelBackID;
//    int moveTitleBackID;
//    int moveTitleID;
//    int moveDescriptionBackID;
//    int moveDescriptionID;
//    int movePriceBackID;
//    int movePriceID;



//    public UIPanel(GameObject itemUIPanel, GameObject itemTitle, GameObject itemDescription, GameObject itemPrice)
//    {

//        this.itemUIPanel = itemUIPanel;
//        this.itemTitle = itemTitle;
//        this.itemDescription = itemDescription;
//        this.itemPrice = itemPrice;


//        //this.itemTitleOrigin = itemTitleOrigin;
//        //this.itemDescriptionOrigin = itemDescriptionOrigin;
//        //this.itemPriceOrigin = itemPriceOrigin;
//        //this.itemTitleView = itemTitleView;
//        //this.itemDescriptionView = itemDescriptionView;
//        //this.itemDescriptionView = itemDescriptionView;
//        //this.itemPriceView = itemPriceView;
//        //this.moveDuration = moveDuration;
//        //this.delay = delay;
//    }


//    public void initMovePanel(GameObject itemPanel, Vector3 panelViewSpot, float moveDuration)
//    {
//        LeanTween.cancel(movePanelID);
//        int movepanelID = LeanTween.move(itemPanel, panelViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
//        movePanelTween = LeanTween.descr(movepanelID);
//        movePanelTween.pause();
//    }

//    public void initMovePanelBackTween(GameObject itemTitle, Vector3 titleOrigin, float moveDuration)
//    {
//        LeanTween.cancel(movePanelBackID);
//        int resetPanelID1 = LeanTween.move(itemTitle, titleOrigin, moveDuration).setEaseInOutSine().id;
//        movePanelBackID = resetPanelID1;
//        movePanelBackTween = LeanTween.descr(movePanelBackID);
//        movePanelBackTween.pause();
//    }

//    public void initMoveTitle(GameObject itemTitle, Vector3 titleViewSpot, float moveDuration)
//    {
//        LeanTween.cancel(moveTitleID);
//        int moveID = LeanTween.move(itemTitle, titleViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
//        moveTitleTween = LeanTween.descr(moveID);
//        moveTitleTween.pause();
//    }
//    public void initMoveTitleBackTween(GameObject itemTitle, Vector3 titleOrigin, float moveDuration)
//    {
//        LeanTween.cancel(moveTitleBackID);
//        int resetID1 = LeanTween.move(itemTitle, titleOrigin, moveDuration).setEaseInOutSine().id;
//        moveTitleBackID = resetID1;
//        moveTitleBackTween = LeanTween.descr(moveTitleBackID);
//        moveTitleBackTween.pause();
//    }

//    public void initMoveDescription(GameObject itemDescription, Vector3 descriptionViewSpot, float moveDuration)
//    {
//        LeanTween.cancel(moveDescriptionID);
//        int moveID = LeanTween.move(itemDescription, descriptionViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
//        moveDescriptionTween = LeanTween.descr(moveID);
//        moveDescriptionTween.pause();
//    }
//    public void initMoveDescriptionBackTween(GameObject itemDescription, Vector3 descriptionOrigin, float moveDuration)
//    {
//        LeanTween.cancel(moveDescriptionBackID);
//        int resetID1 = LeanTween.move(itemDescription, descriptionOrigin, moveDuration).setEaseInOutSine().id;
//        moveDescriptionBackID = resetID1;
//        moveDescriptionBackTween = LeanTween.descr(moveDescriptionBackID);
//        moveDescriptionBackTween.pause();
//    }

//    public void initMovePrice(GameObject itemPrice, Vector3 priceViewSpot, float moveDuration)
//    {
//        LeanTween.cancel(movePriceID);
//        int moveID = LeanTween.move(itemPrice, priceViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
//        movePriceTween = LeanTween.descr(moveID);
//        movePriceTween.pause();
//    }
//    public void initMovePriceBackTween(GameObject itemPrice, Vector3 priceOrigin, float moveDuration)
//    {
//        LeanTween.cancel(movePriceBackID);
//        int resetID1 = LeanTween.move(itemPrice, priceOrigin, moveDuration).setEaseInOutSine().id;
//        movePriceBackID = resetID1;
//        movePriceBackTween = LeanTween.descr(movePriceBackID);
//        movePriceBackTween.pause();
//    }
//}

public class UIPanelGameObject

{
    public GameObject itemUIPanel { get; set; }

    public TextMeshProUGUI itemTitle { get; set; }
    public TextMeshProUGUI itemDescription { get; set; }
    public TextMeshProUGUI itemPrice { get; set; }

    public string titleString { get; set; }
    public string descriptionString { get; set; }
    public string priceString { get; set; }

    public float moveDuration { get; set; }
    public float delay { get; set; }

    LTDescr movePanelTween = null;
    LTDescr movePanelBackTween = null;
    LTDescr moveTitleTween = null;
    LTDescr moveTitleBackTween = null;
    LTDescr moveDescriptionTween = null;
    LTDescr movePriceTween = null;
    LTDescr moveDescriptionBackTween = null;
    LTDescr movePriceBackTween = null;

    int movePanelID;
    int movePanelBackID;
    int moveTitleBackID;
    int moveTitleID;
    int moveDescriptionBackID;
    int moveDescriptionID;
    int movePriceBackID;
    int movePriceID;


    public UIPanelGameObject(GameObject itemUIPanel, TextMeshProUGUI itemTitle, string titleString, TextMeshProUGUI itemDescription, string descriptionString, TextMeshProUGUI itemPrice, string priceString)
    {

        this.itemUIPanel = itemUIPanel;

        this.itemTitle = itemTitle;
        this.titleString = titleString;

        this.itemDescription = itemDescription;
        this.descriptionString = descriptionString;

        this.itemPrice = itemPrice;
        this.priceString = priceString;

    }


    //public void hidePanel(GameObject itemUIPanel)
    //{



    //    if (itemUIPanel.transform.localScale == new Vector3(1, 1, 1))
    //    {
    //        LeanTween.scale(itemUIPanel, new Vector3(0.0f, 0.0f, 0.0f), 2f).setEase(LeanTweenType.easeInOutExpo);
    //    }

    //    else return;
    //}


    public void showPanel(GameObject itemUIPanel)
    {
        //if (itemUIPanel.transform.localScale == new Vector3(0, 0, 0))
        //{
        //    LeanTween.scale(itemUIPanel, new Vector3(1f, 1f, 1f), .75f).setEase(LeanTweenType.easeInOutExpo);

        //}
    }




    public void hidePanel(GameObject itemUIPanel)
    {



        //LeanTween.moveLocal(itemUIPanel, new Vector3(-0, -.043f, 0.2858f), 0f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(itemUIPanel, new Vector3(0, 0, 0), .4f).setEase(LeanTweenType.easeInOutSine);

        changeItemDetails2D(itemTitle, titleString, itemDescription, descriptionString, itemPrice, priceString);
    }


    //public void showPanel(GameObject itemUIPanel)
    //{
    //    //if (itemUIPanel.transform.position != new Vector3(0, 0.008f, 0.28f))
    //    //{

    //    LeanTween.moveLocal(itemUIPanel, new Vector3(-0, .005f, 0.2858f), 0.1f).setEase(LeanTweenType.easeInOutSine);
    //    //LeanTween.scale(itemUIPanel, new Vector3(1, 1, 1), 2f).setEase(LeanTweenType.easeInOutExpo);
    //    //LeanTween.scale(itemUIPanel, new Vector3(1, 1, 1), 2f).setEase(LeanTweenType.easeInOutExpo);
    //    //}
    //}





    public IEnumerator waitToUnhide()
    {

        yield return new WaitForSeconds(1.99f);

        //LeanTween.moveLocal(itemUIPanel, new Vector3(-0, .005f, 0.2858f), 0.88f).setEase(LeanTweenType.easeInOutSine);

    }

    public void initMovePanel(GameObject itemUIPanel, Vector3 panelViewSpot, Vector3 offset, float moveDuration)
    {
        LeanTween.cancel(movePanelID);
        int movepanelID = LeanTween.move(itemUIPanel, panelViewSpot + offset, moveDuration).setEaseInOutQuad().setDelay(delay).id;
        movePanelTween = LeanTween.descr(movepanelID);
        movePanelTween.pause();
        movePanelTween.resume();
    }
    public void initMovePanelBackTween(GameObject itemUIPanel, Vector3 panelOrigin, float moveDuration)
    {
        LeanTween.cancel(movePanelBackID);
        int resetPanelID1 = LeanTween.move(itemUIPanel, panelOrigin, moveDuration).setEaseInOutSine().id;
        movePanelBackID = resetPanelID1;
        movePanelBackTween = LeanTween.descr(movePanelBackID);
        movePanelBackTween.pause();
        movePanelBackTween.resume();
    }

    public void initShowDescritpion(GameObject itemDescription, float moveDuration)
    {
        if (itemDescription.transform.localScale == new Vector3(0, 0, 0))
        {
            LeanTween.scale(itemDescription, new Vector3(1, 1, 1), moveDuration).setEase(LeanTweenType.easeInOutSine);
        }
    }
    public void inithideDescription(GameObject itemDescription, float moveDuration)
    {
        if (itemDescription.transform.localScale == new Vector3(1, 1, 1))
        {
            LeanTween.scale(itemDescription, new Vector3(0.0f, 0.0f, 0.0f), moveDuration).setEase(LeanTweenType.easeInOutSine);
        }
    }


    public void initShowPrice(GameObject itemPrice,  float moveDuration)
    {
        if (itemPrice.transform.localScale == new Vector3(0, 0, 0))
        {
            LeanTween.scale(itemPrice, new Vector3(1, 1, 1), moveDuration).setEase(LeanTweenType.easeInOutSine);
        }
    }
    public void inithidePrice(GameObject itemPrice, float moveDuration)
    {
        if (itemPrice.transform.localScale == new Vector3(1, 1, 1))
        {
            LeanTween.scale(itemPrice, new Vector3(0.0f, 0.0f, 0.0f), moveDuration).setEase(LeanTweenType.easeInOutSine);
        }
    }


    public void initShowImage(GameObject itemImage, float moveDuration)
    {
        if (itemImage.transform.localScale == new Vector3(0, 0, 0))
        {
            LeanTween.scale(itemImage, new Vector3(1, 1, 1), moveDuration).setEase(LeanTweenType.easeInOutSine);
        }
    }
    public void inithideImage(GameObject itemImage, float moveDuration)
    {
        if (itemImage.transform.localScale == new Vector3(1, 1, 1))
        {
            LeanTween.scale(itemImage, new Vector3(0.0f, 0.0f, 0.0f), moveDuration).setEase(LeanTweenType.easeInOutSine);
        }
    }


    public void changeItemDetails(TextMeshPro itemTitle, string itemString, TextMeshPro itemDescription, string descriptionString, TextMeshPro itemPrice, string priceString)

    {
        itemTitle.text = itemString;
        itemPrice.text = priceString;
        itemDescription.text = descriptionString;
    }


    public void changeItemDetails2D(TextMeshProUGUI itemTitle, string itemString, TextMeshProUGUI itemDescription, string descriptionString, TextMeshProUGUI itemPrice, string priceString)

    {
        itemTitle.text = itemString;
        itemPrice.text = priceString;
        itemDescription.text = descriptionString;
     
    }



    //public void initMoveTitle(GameObject itemTitle, Vector3 titleViewSpot, float moveDuration)
    //{
    //    LeanTween.cancel(moveTitleID);
    //    int moveID = LeanTween.move(itemTitle, titleViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
    //    moveTitleTween = LeanTween.descr(moveID);
    //    moveTitleTween.pause();
    //}
    //public void initMoveTitleBackTween(GameObject itemTitle, Vector3 titleOrigin, float moveDuration)
    //{
    //    LeanTween.cancel(moveTitleBackID);
    //    int resetID1 = LeanTween.move(itemTitle, titleOrigin, moveDuration).setEaseInOutSine().id;
    //    moveTitleBackID = resetID1;
    //    moveTitleBackTween = LeanTween.descr(moveTitleBackID);
    //    moveTitleBackTween.pause();
    //}

    //public void initMoveDescription(GameObject itemDescription, Vector3 descriptionViewSpot, float moveDuration)
    //{
    //    LeanTween.cancel(moveDescriptionID);
    //    int moveID = LeanTween.move(itemDescription, descriptionViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
    //    moveDescriptionTween = LeanTween.descr(moveID);
    //    moveDescriptionTween.pause();
    //}
    //public void initMoveDescriptionBackTween(GameObject itemDescription, Vector3 descriptionOrigin, float moveDuration)
    //{
    //    LeanTween.cancel(moveDescriptionBackID);
    //    int resetID1 = LeanTween.move(itemDescription, descriptionOrigin, moveDuration).setEaseInOutSine().id;
    //    moveDescriptionBackID = resetID1;
    //    moveDescriptionBackTween = LeanTween.descr(moveDescriptionBackID);
    //    moveDescriptionBackTween.pause();
    //}

    //public void initMovePrice(GameObject itemPrice, Vector3 priceViewSpot, float moveDuration)
    //{
    //    LeanTween.cancel(movePriceID);
    //    int moveID = LeanTween.move(itemPrice, priceViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
    //    movePriceTween = LeanTween.descr(moveID);
    //    movePriceTween.pause();
    //}
    //public void initMovePriceBackTween(GameObject itemPrice, Vector3 priceOrigin, float moveDuration)
    //{
    //    LeanTween.cancel(movePriceBackID);
    //    int resetID1 = LeanTween.move(itemPrice, priceOrigin, moveDuration).setEaseInOutSine().id;
    //    movePriceBackID = resetID1;
    //    movePriceBackTween = LeanTween.descr(movePriceBackID);
    //    movePriceBackTween.pause();
    //}

}
