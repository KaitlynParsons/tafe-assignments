<?php
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Product Controller page
Known bugs:
Date: 22/3/18
 */
require('../model/database.php');
require('../model/product_db.php');


if (isset($_POST['action'])) {
    $action = $_POST['action'];
} else if (isset($_GET['action'])) {
    $action = $_GET['action'];
} else {
    $action = 'under_construction';
}

if ($action == 'under_construction') {
    include('../under_construction.php');
}
/* * ********Controller for Manage Products Page********* */
//get product ID from database
if ($action == 'product_list') {
    $product_id = filter_input(INPUT_GET, 'productID', FILTER_VALIDATE_INT);
    if ($product_id == NULL || $product_id == FALSE) {
        $product_id = 1;
    }
    $products = get_products();
    $product = get_product($product_id);
    include('product_list.php');
}
//delete product from database
else if ($action == 'delete_product') {
    $product_id = filter_input(INPUT_POST, 'productID', FILTER_VALIDATE_INT);
    if ($product_id == NULL || $product_id == FALSE) {
        $error = "Missing or incorrect product id.";
        include('..\errors\error.php');
    } else {
        delete_product($product_id);
        header("Location: index.php?action=product_list");
    }
}
//show add product page
else if ($action == 'show_add_form') {
    $products = get_products();
    include('product_add.php');
}
//add product to database
else if ($action == 'add_product') {
    $code = filter_input(INPUT_POST, 'productCode');
    $name = filter_input(INPUT_POST, 'productName');
    $version = filter_input(INPUT_POST, 'version');
    $releaseDate = filter_input(INPUT_POST, 'releaseDate');
    if ($code == NULL ||
            $name == NULL || $version == NULL ||
            $releaseDate == NULL || $releaseDate == FALSE) {
        $error = "Invalid product data. Check all fields and try again.";
        include('..\errors\error.php');
    } else {
        add_product($code, $name, $version, $releaseDate);
        header("Location: index.php?action=product_list");
    }
}
/* * ********End of controller for Manage Product Page******** */
?>