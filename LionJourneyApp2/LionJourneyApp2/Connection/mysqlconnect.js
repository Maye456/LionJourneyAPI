const mysql = require('mysql');
const dbConfig = require('../Config/db.config');

// A function constructor
// -- starts with a capital letter
// constructors : initialize objects
function MySQLConnect() {
    // Creates an object with two methods: init and acquire
    // and one data member: pool
    this.pool = null;

    // Init MySql Connection Pool  
    this.init = function () {
        let conn = {
            connectionLimit: dbConfig.poolSize,
            host: dbConfig.host,
            port: dbConfig.port,
            user: dbConfig.user,
            password: dbConfig.password,
            database: dbConfig.database,
        };
        this.pool = mysql.createPool(conn);
    };

    // acquire connection and execute query on callbacks  
    this.acquire = function (callback) {

        this.pool.getConnection(function (err, connection) {
            callback(err, connection);
        });
    };
}

module.exports = new MySQLConnect();