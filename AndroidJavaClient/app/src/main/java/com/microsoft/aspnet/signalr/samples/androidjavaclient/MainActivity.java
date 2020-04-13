package com.microsoft.aspnet.signalr.samples.androidjavaclient;


import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.microsoft.signalr.HubConnection;
import com.microsoft.signalr.HubConnectionBuilder;
import com.microsoft.signalr.HubConnectionState;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private Message msg;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        HubConnection hubConnection = HubConnectionBuilder.create("http://qc.codexen.net/chat").build();
        TextView textView = (TextView)findViewById(R.id.tvMain);
        ListView listView = (ListView)findViewById(R.id.lvMessages);
        Button sendButton = (Button)findViewById(R.id.bSend);
        EditText editText = (EditText)findViewById(R.id.etMessageText);

        List<String> messageList = new ArrayList<String>();
        ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(MainActivity.this,
                android.R.layout.simple_list_item_1, messageList);
        listView.setAdapter(arrayAdapter);

        //SendMessage(Message message);

        msg = new Message();
        msg.Contents = editText.getText().toString();
        msg.Sender = "Android";
        msg.Recipient = "Web";
        msg.SenderConnectionId = hubConnection.getConnectionId();
        msg.RecipientConnectionId = "d0KeDdJWX4McM1yd68EwYw";



        hubConnection.on("ReceiveMessage", (Sender, Contents)-> {
            runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    //Log.e("check", Sender);
                    arrayAdapter.add(Sender + " : " + Contents);
                    arrayAdapter.notifyDataSetChanged();
                }
            });
        }, String.class, String.class);

        sendButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String message = editText.getText().toString();
                editText.setText("");
                try {
                    Log.e("values", msg.toString());
                    hubConnection.send("SendMessage", msg);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });

        new HubConnectionTask().execute(hubConnection);
    }

    class HubConnectionTask extends AsyncTask<HubConnection, Void, Void>{

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected Void doInBackground(HubConnection... hubConnections) {
            HubConnection hubConnection = hubConnections[0];
            hubConnection.start().blockingAwait();
//            if(hubConnection.getConnectionState() == HubConnectionState.CONNECTED){
//                Toast.makeText(MainActivity.this, "connected", Toast.LENGTH_SHORT).show();
//            }

            if(hubConnection.getConnectionState() == HubConnectionState.CONNECTED) {
                Log.e("conn", "connected");
                msg.SenderConnectionId = hubConnection.getConnectionId();
                Log.e("id", "" + hubConnection.getConnectionId());
            }
            return null;
        }
    }
}