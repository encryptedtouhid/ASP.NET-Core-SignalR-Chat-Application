package com.microsoft.aspnet.signalr.samples.androidjavaclient;

public class Message {

    public String RecipientConnectionId;
    public String Recipient;
    public String SenderConnectionId;
    public String Sender;
    public String Contents;
//    public String DateTime;




    public String getRecipientConnectionId() {
        return RecipientConnectionId;
    }

    public void setRecipientConnectionId(String recipientConnectionId) {
        RecipientConnectionId = recipientConnectionId;
    }

    public String getRecipient() {
        return Recipient;
    }

    public void setRecipient(String recipient) {
        Recipient = recipient;
    }

    public String getSenderConnectionId() {
        return SenderConnectionId;
    }

    public void setSenderConnectionId(String senderConnectionId) {
        SenderConnectionId = senderConnectionId;
    }

    public String getSender() {
        return Sender;
    }

    public void setSender(String sender) {
        Sender = sender;
    }

    public String getContents() {
        return Contents;
    }

    public void setContents(String contents) {
        Contents = contents;
    }

//    public String getDateTime() {
//        return DateTime;
//    }
//
//    public void setDateTime(String dateTime) {
//        DateTime = dateTime;
//    }

    @Override
    public String toString() {
        return "Message{" +
                "RecipientConnectionId='" + RecipientConnectionId + '\'' +
                ", Recipient='" + Recipient + '\'' +
                ", SenderConnectionId='" + SenderConnectionId + '\'' +
                ", Sender='" + Sender + '\'' +
                ", Contents='" + Contents + '\'' +

                '}';
    }
}
