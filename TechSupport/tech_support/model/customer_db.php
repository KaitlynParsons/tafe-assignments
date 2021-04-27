<?php
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Customer Database
Known bugs:
Date: 22/3/18
 */
    
    //searchname function
    function searchname(){
        global $db;
        $search = filter_input(INPUT_POST, 'search');
        $query = "SELECT firstName, lastName, email, city, 
                customerID FROM customers WHERE lastName LIKE '$search%'" ;
        $statement = $db->prepare($query);
        $statement->execute();
        $customers = $statement->fetchAll();
        $statement->closeCursor();
        return $customers;  
    }//end searchname function
    
    //get customers function
    function get_customers(){
        global $db;
        $query = 'SELECT firstName, lastName, email, city FROM customers 
                WHERE lastName LIKE :namesearch ';
        $statement = $db->prepare($query);
        $statement->execute();
        $customers = $statement->fetchAll();
        $statement->closeCursor();
        return $customers;
    }//end get customers function

    //update customer function
    function update_customer($customerID,$firstname, $lastname, $address, 
            $city, $state, $postalCode, $countryCode, $phone, $email, $userpassword){
        global $db;
        $query = "UPDATE customers SET customerID = :customerID,
                firstName = :firstName,lastName = :lastName,address = :address,
                city = :city,state = :state,postalCode = :postalCode,
                countryCode = :countryCode,phone = :phone,email = :email,
                password = :userpassword WHERE customerID = :customerID";
        $statement = $db->prepare($query);
        $statement->bindValue(':customerID',$customerID);
        $statement->bindValue(':firstName',$firstname);
        $statement->bindValue(':lastName',$lastname);
        $statement->bindValue(':address',$address);
        $statement->bindValue(':city',$city);
        $statement->bindValue(':state',$state);
        $statement->bindValue(':postalCode',$postalCode);
        $statement->bindValue(':countryCode',$countryCode);
        $statement->bindValue(':phone',$phone);
        $statement->bindValue(':email',$email);
        $statement->bindValue(':userpassword',$userpassword);
        $statement->execute();
        $statement->closeCursor();
    }//end update customer function
    
    //select customer function
    function select_customer($customerID){
        global $db;
        $query = "SELECT * FROM customers WHERE customerID LIKE '%$customerID%' ";
        $statement = $db->prepare($query);
        $statement->execute();
        $customers = $statement->fetchAll();
        $statement->closeCursor();
        return $customers;
    }//end select customer function  
?>