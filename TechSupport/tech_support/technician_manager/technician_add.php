<?php 
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: add technician page
Known bugs:
Date: 22/3/18
 */
include '../view/header.php'; ?>
<main id='main'>
    <h1>Add Technician</h1>
    <form action='index.php' method='post'>
        <input type='hidden' name='action' value='add_technician'>
        
        <label id='alignedlabel'>First Name:</label>
        <input type="text" name="firstName" />
        <br>

        <label id='alignedlabel'>Last Name:</label>
        <input type="text" name="lastName" />
        <br>

        <label id='alignedlabel'>Email:</label>
        <input type="text" name="email" />
        <br>

        <label id='alignedlabel'>Phone:</label>
        <input type="text" name="phone" />
        <br>
        
        <label id='alignedlabel'>Password:</label>
        <input type="text" name="password" />
        <br>
        
        <label id='alignedlabel'>&nbsp;</label>
        <input type="submit" value="Add Technician" />
        
        <br>
    </form>
    <p><a href="index.php?action=technician_list">View Technician List</a></p>
</main>

<?php include '../view/footer.php'; ?>
