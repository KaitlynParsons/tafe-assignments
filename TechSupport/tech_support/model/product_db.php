<?php
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Product Database
Known bugs:
Date: 22/3/18
 */
//get all products
function get_products(){
    global $db;
    $query = 'SELECT * FROM products ORDER BY productID';
    $statement = $db->prepare($query);
    $statement->execute();
    $products = $statement->fetchAll();
    $statement->closeCursor();
    return $products;
}
//get products
function get_product($product_id) {
    global $db;
    $query = 'SELECT * FROM products WHERE productID = :productID';
    $statement = $db->prepare($query);
    $statement->bindValue(":productID", $product_id);
    $statement->execute();
    $product = $statement->fetch();
    $statement->closeCursor();
    return $product;
}
//delete product
function delete_product($product_id) {
    global $db;
    $query = 'DELETE FROM products WHERE productID = :productID';
    $statement = $db->prepare($query);
    $statement->bindValue(':productID', $product_id);
    $statement->execute();
    $statement->closeCursor();
}
//add product
function add_product($code, $name, $version, $releaseDate) {
    global $db;
    $query = 'INSERT INTO products
                 (productCode, name, version, releaseDate)
              VALUES
                 (:productCode, :productName, :version, :releaseDate)';
    $statement = $db->prepare($query);
    $statement->bindValue(':productCode', $code);
    $statement->bindValue(':productName', $name);
    $statement->bindValue(':version', $version);
    $statement->bindValue(':releaseDate', $releaseDate);
    $statement->execute();
    $statement->closeCursor();
}
