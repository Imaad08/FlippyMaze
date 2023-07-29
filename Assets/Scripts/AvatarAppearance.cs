using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AvatarAppearance : MonoBehaviour
{
    [Header("Color for the Avatar's costume and skin")]
    public Color color = new Color(0.9f, 0.23f, 0.5f, 1f);
    public Color skin = new Color(0.9f, 0.8f, 0.6f, 1f);

    [System.Serializable]
    public enum HatPart
    {
        none,
        Bow,
        GreenHeadband,
        RedHeadband,
        YellowHeadband,
        HardHat,
        CowboyHat,
        Headphones,
        Crown,
        ChefHat,
        PirateHat,
        Robot,
        ModernHelmet,
        TopHat,
        CarmenMiranda,
        PartyHat,
        Unicorn,
        Clown,
        Halo,
        Tiara,
        PonyTail,
        CatEars,
        PinkElf,
        GreenElf,
        Santa,
        Reindeer
    }    

    [System.Serializable]
    public enum FacePart
    {
        none,
        RoundGlasses,
        HypnoGlasses,
        RedGoggles,
        RedNose,
        Mustache,
        Sunglasses,
        Eyepatch,
        HeroMask,
        WhiteBeard,
        RedBandana,
        RobotVisor,
        PinkGlasses,
        ScubaMask,
        GasMask
    }    

    [System.Serializable]
    public enum HandPart
    {
        none,
        Shuriken,
        Sword,
        Banana,
        SmartPhone,
        IceCream,
        Key,
        MagicWand,
        Microphone,
        Pizza,
        Hamburger,
        Potion,
        Baseballbat,
        Blueprints,
        PaintBrush,
        CandyCane,
        Hammer
    }    

    [System.Serializable]
    public enum UpperBodyPart
    {
        none,
        CodeNinjasTee,
        Tuxedo,
        RedSash,
        CrossBelts,
        GreenScarf,
        YellowWings,
        FastTee,
        JetPack,
        BackPack,
        ScubaTank,
        Jersey,
        Astronaut,
        Knight,
        Robot,
        PinkElf,
        GreenElf,
        Santa,
        Reindeer
    }    

    [System.Serializable]
    public enum LowerBodyPart
    {
        none,
        TropicalTrunks,
        WhiteBelt,
        YellowBelt,
        OrangeBelt,
        GreenBelt,
        BlueBelt,
        PurpleBelt,
        RedBelt,
        BrownBelt,
        BlackBelt,
        Robot,
        BlackPants,
        Astronaut,
        Knight,
        GreenTail,
        Apron,
        WrestlingBelt,
        GoldBuckledBlackBelt,
        GoldBuckledRedBelt
    }

    [Header("Avatar Accessories")]
    public HatPart hatPartNumber = 0;
    public FacePart facePartNumber = 0;
    public HandPart handPartNumber = 0;
    public UpperBodyPart upperBodyPartNumber = 0;
    public LowerBodyPart lowerBodyPartNumber = 0;

    private GameObject childSprite;
    private string[] costumeParts;
    private GameObject hatPart;
    private GameObject facePart;
    private GameObject handPart;
    private GameObject upperBodyPart;
    private GameObject lowerBodyPart;
    private string partNumber;
    private int maxHat = 25;
    private int maxFace = 14;
    private int maxHand = 16;
    private int maxUpperBody = 18;
    private int maxLowerBody = 19;

    // Start is called before the first frame update
    void Start()
    {
        resetParts();

        costumeParts = new string[] { "Head", "LArm", "LLeg", "RArm", "RLeg", "Body" };

        foreach (string part in costumeParts)
        {
            childSprite = GameObject.Find(part);
            childSprite.GetComponent<SpriteRenderer>().color = color;
        }

        childSprite = GameObject.Find("Face");
        childSprite.GetComponent<SpriteRenderer>().color = skin;

        setParts();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setParts()
    {
        //lower body parts
        if (lowerBodyPartNumber != 0)
        {
            int lbpartNumber = (int)lowerBodyPartNumber;
            lowerBodyPart = GameObject.Find("LowerBody" + lbpartNumber.ToString("00"));
            lowerBodyPart.GetComponent<SpriteRenderer>().enabled = true;
        }

        //hat parts
        if (hatPartNumber != 0)
        {
            int hpartNumber = (int)hatPartNumber;
            hatPart = GameObject.Find("HatPart" + hpartNumber.ToString("00"));
            hatPart.GetComponent<SpriteRenderer>().enabled = true;
        }

        //face parts
        if (facePartNumber != 0)
        {
            int fpartNumber = (int)facePartNumber;
            facePart = GameObject.Find("FaceParts" + fpartNumber.ToString("00"));
            facePart.GetComponent<SpriteRenderer>().enabled = true;
        }

        //hand parts
        if (handPartNumber != 0)
        {
            int hdpartNumber = (int)handPartNumber;
            handPart = GameObject.Find("HandPart" + hdpartNumber.ToString("00"));
            handPart.GetComponent<SpriteRenderer>().enabled = true;
        }

        //upper body parts
        if (upperBodyPartNumber != 0)
        {
            int ubpartNumber = (int)upperBodyPartNumber;
            upperBodyPart = GameObject.Find("UpperBody" + ubpartNumber.ToString("00"));
            upperBodyPart.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void resetParts()
    {
        //lower body parts
        for (var lower = 1; lower <= maxLowerBody; lower++)
        {
            partNumber = lower.ToString("00");
            lowerBodyPart = GameObject.Find("LowerBody" + partNumber);
            lowerBodyPart.GetComponent<SpriteRenderer>().enabled = false;
        }

        //hat parts
        for (var hat = 1; hat <= maxHat; hat++)
        {
            partNumber = hat.ToString("00");
            hatPart = GameObject.Find("HatPart" + partNumber);
            hatPart.GetComponent<SpriteRenderer>().enabled = false;
        }

        //face parts
        for (var face = 1; face <= maxFace; face++)
        {
            partNumber = face.ToString("00");
            facePart = GameObject.Find("FaceParts" + partNumber);
            facePart.GetComponent<SpriteRenderer>().enabled = false;
        }

        //hand parts
        for (var hand = 1; hand <= maxHand; hand++)
        {
            partNumber = hand.ToString("00");
            handPart = GameObject.Find("HandPart" + partNumber);
            handPart.GetComponent<SpriteRenderer>().enabled = false;
        }

        //upper body parts
        for (var upper = 1; upper <= maxUpperBody; upper++)
        {
            partNumber = upper.ToString("00");
            upperBodyPart = GameObject.Find("UpperBody" + partNumber);
            upperBodyPart.GetComponent<SpriteRenderer>().enabled = false;
        }

        //setParts();
    }

}
