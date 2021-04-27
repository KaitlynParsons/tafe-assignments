<?php
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Technician database
Known bugs:
Date: 22/3/18
 */
//get all technicians by techID
function get_technicians_by_id(){
    global $db;
    $query = 'SELECT * FROM technicians ORDER BY techID';
    $statement = $db->prepare($query);
    $statement->execute();
    $technicians = $statement->fetchAll();
    $statement->closeCursor();
    return $technicians;
}
//get technicians
function get_technician($tech_id) {
    global $db;
    $query = 'SELECT * FROM technicians WHERE techID = :techID';
    $statement = $db->prepare($query);
    $statement->bindValue(":techID", $tech_id);
    $statement->execute();
    $technician = $statement->fetch();
    $statement->closeCursor();
    return $technician;
}
//delete technician
function delete_technician($tech_id) {
    global $db;
    $query = 'DELETE FROM technicians WHERE techID = :techID';
    $statement = $db->prepare($query);
    $statement->bindValue(':techID', $tech_id);
    $statement->execute();
    $statement->closeCursor();
}
//add technician
function add_technician($firstName, $lastName, $email, $phone, $password) {
    global $db;
    $query = 'INSERT INTO technicians
                 (firstName, lastName, email, phone, password)
              VALUES
                 (:firstName, :lastName, :email, :phone, :password)';
    $statement = $db->prepare($query);
    $statement->bindValue(':firstName', $firstName);
    $statement->bindValue(':lastName', $lastName);
    $statement->bindValue(':email', $email);
    $statement->bindValue(':phone', $phone);
    $statement->bindValue(':password', $password);
    $statement->execute();
    $statement->closeCursor();
}
?>

