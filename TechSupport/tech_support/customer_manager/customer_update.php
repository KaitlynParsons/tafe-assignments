<?php 
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Customer View/Update Page
Known bugs:
Date: 22/3/18
 */
include('../view/header.php'); 
//require('../model/database.php');
//require('../model/customer_db.php');
//USE ID TO PUSH CUSTOMER FROM SELECT FORM TO THIS FORM and then foreach
$customers = select_customer($customerID);
//print_r($customers); 
?>
<main><section>
    <div id="main"> <h1>View/Update Customer</h1>
        
    <form action="." method="post" id="aligned">
        <?PHP foreach($customers as $customer): ?>

         <input type="hidden" name="customerID" 
                value="<?PHP echo $customer["customerID"]; ?>">
        <label id="alignedlabel">First Name:</label>
        <input id="alignedinput" type="text" name="firstName" 
               value="<?PHP echo $customer["firstName"]; ?>">
        <br>
        <label id="alignedlabel">Last Name:</label>
        <input id="alignedinput" type="text" name="lastName" 
               value="<?PHP echo $customer['lastName']; ?>">
        <br>
        <label id="alignedlabel">Address:</label>
        <input id="alignedinputtext" type="text" name="address" 
               value="<?PHP echo $customer['address']; ?>">
        <br>
        <label id="alignedlabel">City:</label>
        <input id="alignedinput" type="text" name="city" 
               value="<?PHP echo $customer['city']; ?>">
        <br>
        <label id="alignedlabel">State:</label>
        <input id="alignedinput" type="text" name="state" 
               value="<?PHP echo $customer['state']; ?>">
        <br>
        <label id="alignedlabel">Postal Code:</label>
        <input id="alignedinput" type="text" name="postalCode" 
               value="<?PHP echo $customer['postalCode']; ?>">
        <br>
        <label id="alignedlabel">Country Code:</label>
        <input id="alignedinput" type="text" name="countryCode" 
               value="<?PHP echo $customer['countryCode']; ?>">
        <br>
        <label id="alignedlabel">Phone:</label>
        <input id="alignedinput" type="text" name="phone" 
               value="<?PHP echo $customer['phone']; ?>">
        <br>
        
        <label id="alignedlabel">Email:</label>
        <input id="alignedinputtext" type="text" name="email" 
               value="<?PHP echo $customer['email']; ?>">
        <br>
        <label id="alignedlabel">Password:</label>
        <input id="alignedinput" type="text" name="password" 
               value="<?PHP echo $customer['password']; ?>">
        <br>
        <input type="hidden" name="action" value="update_customer">
        <label id="alignedlabel">&nbsp;</label>
        <input type="submit" value="Update Customer">
        <br>
        <?PHP endforeach; ?>
    </form>
    <p class="last_paragraph">
        <a href="index.php">Search Customers</a>
    </p>
    </div>
        </section>
</main>
<?php include('../view/footer.php');
?>