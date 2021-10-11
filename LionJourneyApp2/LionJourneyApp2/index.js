const express = require("express");
const mySqlConnect = require("./Connection/mysqlconnect");
const app = express();
const postRoutes = require("./Routes/PostRoutes");

// Initialize the MySQl connection pool
mySqlConnect.init();

// prepare to parse request body
app.use(express.json());
app.use(express.urlencoded({
    extended: true
}));

app.use("/api", postRoutes);


app.listen(3000, () => {
    console.log("listening...");
});