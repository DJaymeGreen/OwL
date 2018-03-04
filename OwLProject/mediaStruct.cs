using System;

/**
 * Media Structure that associates title, description, and 
 * media together 
 * */
public struct mediaStruct {
    private String mediaTitle;
    private String mediaDescription;
    private byte[] media;
    public String Title {
        get {
            return mediaTitle;
        }
        set {
            mediaTitle = value;
        }
    }
    public String Description {
        get {
            return mediaDescription;
        }
        set {
            mediaDescription = value;
        }
    }
    public byte[] Media {
        get {
            return media;
        }
        set {
            media = value;
        }
    }
}