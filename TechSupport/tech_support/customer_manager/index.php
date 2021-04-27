<?php
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Customers Controller Page
Known bugs:
Date: 22/3/18
 */
    require('../model/database.php');
    require('../model/customer_db.php');
    $action = filter_input(INPUT_POST, 'action');
/* * ********Controller for Manage Customers Page********* */    
    //list customers
    if($action == 'list_customers' || $action == NULL){
    include('customer_manager.php');
    }//end list customers if
    
    //search customers
    if($action == 'search'){ 
        $customers = searchname($search);
        $firstname = filter_input(INPUT_POST,'firstName');
        $lastname = filter_input(INPUT_POST,'lastName');
        $address = filter_input(INPUT_POST, 'address');
        $city = filter_input(INPUT_POST, 'city');
        $state = filter_input(INPUT_POST, 'state');
        $postalCode = filter_input(INPUT_POST, 'postalCode');
        $countryCode = filter_input(INPUT_POST, 'countryCode');
        $phone = filter_input(INPUT_POST, 'phone');
        $email = filter_input(INPUT_POST, 'email');
        $userpassword = filter_input(INPUT_POST, 'userpassword');
        header('Location: .?action=search'); 
    }//end search customers if
    
    //update customers
    if($action == 'update_customer'){
        $customerID = filter_input(INPUT_POST,'customerID');
        $firstname = filter_input(INPUT_POST,'firstName');
        $lastname = filter_input(INPUT_POST,'lastName');
        $address = filter_input(INPUT_POST, 'address');
        $city = filter_input(INPUT_POST, 'city');
        $state = filter_input(INPUT_POST, 'state');
        $postalCode = filter_input(INPUT_POST, 'postalCode');
        $countryCode = filter_input(INPUT_POST, 'countryCode');
        $phone = filter_input(INPUT_POST, 'phone');
        $email = filter_input(INPUT_POST, 'email');
        $userpassword = filter_input(INPUT_POST, 'password');
        if($firstname == NULL || $lastname == NULL || $phone == NULL || $userpassword == NULL){
            $error = 'Make sure you complete all required fields.';
            include('../errors/error.php');
        }else{
            update_customer($customerID,$firstname, $lastname, $address, 
                    $city, $state, $postalCode, $countryCode, $phone, 
                    $email, $userpassword);
            header('Location: .?action=list_customers');
            //refresh page
        }
    }//end update customers ifelse
    
    //select customer
    if($action == 'select_customer'){
        $customerID = filter_input(INPUT_POST,'customerID',FILTER_VALIDATE_INT);
        if($customerID == NULL || $customerID  == FALSE)
            {
            $error = "Missing or incorrect Customer ID.";
            include('../errors/error.php');
        }else{
            $customers = select_customer($customerID);
            include('customer_update.php');
            //refresh page
        }
    }//end select customer ifelse
/* * ********Controller for Manage Customers Page********* */