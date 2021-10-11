const posts = require("../Service/DataService/PostDAO");

// List All Posts
exports.getPost = (req, res, next) => {
    // Validation area
    posts.getPost(req, (error, results) => {
        if (error) {
            return res.status(400).send({ success: 0, data: "Bad request" });
        }
        return res.status(200).send({
            success: 1,
            data: results,
        });
    });
};

// Search Posts By Title
exports.getPostByTitle = (req, res, next) => {
    // Validation area
    posts.getPostByTitle(req, (error, results) => {
        if (error) {
            return res.status(400).send({ success: 0, data: "Bad request" + error});
        }
        return res.status(200).send({
            success: 1,
            data: results,
        });
    });
};

// Delete Posts
exports.deletePost = (req, res, next) => {
    // Validation area
    posts.deletePost(req, (error, results) => {
        if (error) {
            return res.status(400).send({ success: 0, data: "Bad request" + error});
        }
        return res.status(200).send({
            success: 1,
            data: results,
        });
    });
};

// Search Post By ID
exports.getPostByID = (req, res, next) => {
    // Validation area
    posts.getPostByID(req, (error, results) => {
        if (error) {
            return res.status(400).send({ success: 0, data: "Bad request" });
        }
        return res.status(200).send({
            success: 1,
            data: results,
        });
    });
};

// Create Post
exports.createPost = (req, res, next) => {
    // Validation area
    if (!(req.body.title && req.body.content)) {
        return res.status(400).send({ success: 0, data: "Request must specify all values" })
    }

    posts.createPost(req.body, (error, results) => {
        if (error) {
            return res.status(400).send({ success: 0, data: "Bad Request" + error });
        }
        return res.status(200).send({
            success: 1,
            data: results,
        });
    });
};

// Update Post
exports.updatePost = (req, res, next) => {
    // Validation area
    if (!(req.body.title && req.body.content)) {
        return res.status(400).send({ success: 0, data: "Request must specify all values" })
    }

    posts.updatePost(req.body, (error, results) => {
        if (error) {
            return res.status(400).send({ success: 0, data: "Bad Request" + error });
        }
        return res.status(200).send({
            success: 1,
            data: results,
        });
    });
};