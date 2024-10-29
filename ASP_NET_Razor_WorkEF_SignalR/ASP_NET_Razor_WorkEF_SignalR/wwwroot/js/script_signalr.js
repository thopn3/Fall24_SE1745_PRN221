"use strict"

// Build Hub server trong JS (su dung SignalR)
var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();

// Lang nghe su kien khi ham ReloadData duoc goi: Create, Update, Delete
connection.on("ReloadData", () => {
    location.reload();
});

// Khoi dong Hub Server
connection.start().then().catch(err => console.error(err));
