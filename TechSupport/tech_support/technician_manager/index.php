<?php
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Technician Controller page
Known bugs:
Date: 22/3/18
 */
require('../model/database.php');
require('../model/technician_db.php');

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
/* * ********Start of controller for Manage Technicians Page********* */
//get tech ID from database
if ($action == 'technician_list') {
    $tech_id = filter_input(INPUT_GET, 'techID', FILTER_VALIDATE_INT);
    if ($tech_id == NULL || $tech_id == FALSE) {
        $tech_id = 1;
    }
    $technicians = get_technicians_by_id();
    $technician = get_technician($tech_id);
    include('technician_list.php');
}
//delete technician from database
else if ($action == 'delete_technician') {
    $tech_id = filter_input(INPUT_POST, 'techID', FILTER_VALIDATE_INT);
    if ($tech_id == NULL || $tech_id == FALSE) {
        $error = "Missing or incorrect tech id.";
        include('..\errors\error.php');
    } else {
        delete_technician($tech_id);
        header("Location: index.php?action=technician_list");
    }
}
//show add technician page
else if ($action == 'show_add_form2') {
    $technicians = get_technicians_by_id();
    include('technician_add.php');
}
//add technician to database
else if ($action == 'add_technician') {
    $firstName = filter_input(INPUT_POST, 'firstName');
    $lastName = filter_input(INPUT_POST, 'lastName');
    $email = filter_input(INPUT_POST, 'email');
    $phone = filter_input(INPUT_POST, 'phone');
    $password = filter_input(INPUT_POST, 'password');
    if ($firstName == NULL || $lastName == NULL || $email == NULL || 
            $email == FALSE || $phone == NULL || $password == NULL) {
        $error = "Invalid technician data. Check all fields and try again.";
        include('..\errors\error.php');
    } else {
        add_technician($firstName, $lastName, $email, $phone, $password);
        header("Location: index.php?action=technician_list");
    }
}
/* * ********End of controller for Manage Technicians Page********* */
?>